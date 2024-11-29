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
    public DbSet<Member> Members { get; set; }
    public DbSet<FitnessProgram> FitnessProgram { get; set; }
    public DbSet<Reservation> Reservation { get; set; }
    public DbSet<TimeSlot> TimeSlot { get; set; }
    public DbSet<Equipment> Equipment { get; set; }
    public DbSet<RunningSession> RunningSession { get; set; }
    public DbSet<RunningSessionDetail> RunningSessionDetail { get; set; }
    public DbSet<CyclingSession> CyclingSession { get; set; }

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
        

        //Reservaties definiëren die zijn geowned door member dus hierbinnen configureren.
        modelBuilder.Entity<Member>()
            .OwnsMany(m => m.Reservations, ReservationBuilder =>
            {
                ReservationBuilder
                .HasOne(r => r.Equipment)
                .WithMany()
                .HasForeignKey("EquipementId");

                ReservationBuilder
                    .HasOne(r => r.TimeSlot)
                    .WithMany()
                    .HasForeignKey("TimeSlotId");
                ReservationBuilder.WithOwner().HasForeignKey("MemberId");

            });

        modelBuilder.Entity<FitnessProgram>()
            .ToTable("Program");

        modelBuilder.Entity<Member>()
             .OwnsMany(m => m.CyclingSessions)
             .WithOwner().HasForeignKey("MemberId");


        //OwnsMany => RunningSessionDetail kan niet bestaan zonder RunningSessions
        //HasMany => Reference naar een ander object dat alleen kan bestaan
        modelBuilder.Entity<Member>()
            .OwnsMany(m => m.RunningSessions, RunningSessionBuilder => {
                RunningSessionBuilder.OwnsMany(r => r.Details).WithOwner().HasForeignKey("RunningSessionId");
                RunningSessionBuilder.WithOwner().HasForeignKey("MemberId");
            });
    }
}
