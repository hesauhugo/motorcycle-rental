using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorcycleRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Infrastructure.Persistence.Configurations
{
    public class RentalConfiguration : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder
                .ToTable("rental");

            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("integer")
                .UseIdentityColumn();

            builder
                .Property(p => p.CreateAt)
                .HasColumnName("create_at")
                .HasColumnType("date")
                .IsRequired();

            builder
                .Property(p => p.EndDate)
                .HasColumnName("end_date")
                .HasColumnType("date");

            builder
                .Property(p => p.Plan)
                .HasColumnName("plan")
                .HasColumnType("integer");

            builder
                .Property(p => p.IdCustomer)
                .HasColumnName("id_customer")
                .HasColumnType("integer");

            builder
                .Property(p => p.IdMotorcycle)
                .HasColumnName("id_motorcycle")
                .HasColumnType("integer");

            builder
                .HasOne(p => p.Customer)
                .WithMany()
                .HasForeignKey(p => p.IdCustomer)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Motorcycle)
                .WithMany()
                .HasForeignKey(p => p.IdMotorcycle)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
