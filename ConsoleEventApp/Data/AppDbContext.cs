using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleEventApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ConsoleEventApp.AppDbContext;

public class AppDbContextt : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //Update-database
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(@"server=(localdb)\Local;database=EventDB;trusted_connection=true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) //Add-migration
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<EventUserEnrollment>().HasKey(e => new { e.EventId, e.UserId });
    }

    public DbSet<Event> Events { get; set; }
    public DbSet<User> users { get; set; }
    public DbSet<EventUserEnrollment> EventUserEnrollments { get; set; }
}
