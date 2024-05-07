using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MotorcycleRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Infrastructure.Persistence.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder
                .HasKey(s => s.Id);

            builder
                .Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("integer")
                .UseIdentityColumn();

            builder
                .Property(p => p.FullName)
                .IsRequired(true)
                .HasColumnName("full_name")
                .HasColumnType("text");

            builder
                .Property(p => p.Email)
                .IsRequired(true)
                .HasColumnName("email")
                .HasColumnType("text");

            builder
                .Property(p => p.BirthDate)
                .HasColumnName("birth_date")
                .HasColumnType("date");

            builder
                .Property(p => p.CreatedAt)
                .HasColumnName("create_at")
                .HasColumnType("date");

            builder
                .Property(p => p.Active)
                .HasColumnName("active")
                .HasColumnType("boolean");

            builder
                .Property(p => p.Password)
                .IsRequired(true)
                .HasColumnName("password")
                .HasColumnType("text");

            builder
                .Property(p => p.Role)
                .IsRequired(true)
                .HasColumnName("role")
                .HasColumnType("text");
        }
    }
}
