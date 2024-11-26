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
    public DbSet<Members> Members;
    public DbSet<FitnessProgram> FitnessPrograms;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Members>()
            .HasMany(m => m.FitnessPrograms)
            .WithMany(m => m.Members);
    }
}
