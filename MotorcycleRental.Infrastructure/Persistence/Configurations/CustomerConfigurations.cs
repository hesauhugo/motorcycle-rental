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
    public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .ToTable("customer");
            
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("integer")
                .UseIdentityColumn();

            builder
                .Property(p => p.FullName)
                .IsRequired()
                .HasColumnName("full_name")
                .HasColumnType("text");

            builder
                .Property(p => p.Cnpj)
                .IsRequired()
                .HasColumnName("cnpj")
                .HasColumnType("text");

            builder
                .HasIndex(p => p.Cnpj)
                .IsUnique();

            builder
                .Property(p => p.CnhKind)
                .IsRequired()
                .HasColumnName("cnh_kind")
                .HasColumnType("text");


            builder
                .Property(p => p.Cnh)
                .IsRequired()
                .HasColumnName("cnh")
                .HasColumnType("text");

            builder
                .HasIndex(p => p.Cnh)
                .IsUnique();

            builder
                .Property(p => p.BirthDate)
                .IsRequired()
                .HasColumnName("birth_date")
                .HasColumnType("date");

            builder
                .Property(p => p.Password)
                .IsRequired()
                .HasColumnName("password")
                .HasColumnType("text");

        }
    }
}
