using FitnessBeheerEFlayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerEFlayer;

public class FitnessContext : DbContext
{
    public DbSet<MemberEF> members { get; set; }
    public DbSet<FitnessProgramEF> program { get; set; }
    public DbSet<ReservationEF> reservation { get; set; }
    public DbSet<TimeSlotEF> time_slot { get; set; }
    public DbSet<EquipmentEF> equipment { get; set; }
    public DbSet<RunningSessionEF> runningsession_main { get; set; }
    public DbSet<RunningSessionDetailEF> runningsession_detail { get; set; }
    public DbSet<CyclingSessionEF> cyclingsession { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=MSI\SQLEXPRESS01;Initial Catalog=FitnessDb;Integrated Security=True;Trust Server Certificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}
