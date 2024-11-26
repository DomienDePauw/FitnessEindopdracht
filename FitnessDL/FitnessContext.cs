using FitnessDL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDL;

public class FitnessContext : DbContext
{
    public DbSet<Member> Members;
    public DbSet<FitnessProgram> FitnessProgram;
    public DbSet<Reservation> Reservation;
    public DbSet<TimeSlot> TimeSlot;
    public DbSet<Equipment> Equipment;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=MSI\SQLEXPRESS01;Initial Catalog=FitnessDb;Integrated Security=True;Trust Server Certificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Member>()
            .ToTable("Members")
            .HasMany(m => m.FitnessPrograms)
            .WithMany(m => m.Members);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Member)
            .WithMany(m => m.Reservations)
            .HasForeignKey(r => r.MemberId);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Equipment)
            .WithMany(e => e.Reservations)
            .HasForeignKey(r => r.EquipmentId);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.TimeSlot)
            .WithMany(ts => ts.Reservations)
            .HasForeignKey(r => r.TimeSlotId);

        modelBuilder.Entity<FitnessProgram>()
            .ToTable("Program");
    }
}
