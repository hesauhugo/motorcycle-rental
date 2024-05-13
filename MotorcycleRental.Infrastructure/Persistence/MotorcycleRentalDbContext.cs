using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MotorcycleRental.Core.Entities;
using System;
using System.Reflection;

namespace MotorcycleRental.Infrastructure.Persistence
{
    public class MotorcycleRentalDbContext : DbContext
    {
        public MotorcycleRentalDbContext(DbContextOptions<MotorcycleRentalDbContext> options):base(options)
        {
            
        }

        public DbSet<Motorcycle> Motorcycles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MotorcycleRentalDbContext).Assembly);

            Motorcycle[] motorcycles = new Motorcycle[]
            {
              new Motorcycle (-1,2020, "Honda CBX","AHM3G25" ),
              new Motorcycle (-2,2022, "Honda CBX","BHM3G26"),
              new Motorcycle (-3,2023, "Honda CBX","GHM3G27")
            };

            modelBuilder.Entity<Motorcycle>().HasData(motorcycles);
        }

    }
}
