using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorcycleRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Infrastructure.Persistence.Configurations
{
    public class MotorcycleConfigurations : IEntityTypeConfiguration<Motorcycle>
    {
        public void Configure(EntityTypeBuilder<Motorcycle> builder)
        {
            builder.ToTable("motorcycle");
            
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p=>p.Id)
                .HasColumnName("id")
                .HasColumnType("integer")
                .UseIdentityColumn();

            builder
                .Property(p => p.Model)
                .IsRequired(true)
                .HasColumnName("model")
                .HasColumnType("varchar(100)");

            builder
                .Property(p => p.Year)
                .IsRequired(true)
                .HasColumnName("year")
                .HasColumnType("integer");

            builder
                .Property(p => p.LicensePlate)
                .IsRequired(true)
                .HasColumnName("license_plate")
                .HasColumnType("varchar(20)");

        }
    }
}
