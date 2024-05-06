﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MotorcycleRental.Infrastructure.Persistence;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MotorcycleRental.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(MotorcycleRentalDbContext))]
    [Migration("20240506034532_motorcycleSeed")]
    partial class motorcycleSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MotorcycleRental.Core.Entities.Motorcycle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("license_plate");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("model");

                    b.Property<int>("Year")
                        .HasColumnType("integer")
                        .HasColumnName("year");

                    b.HasKey("Id");

                    b.ToTable("motorcycle", (string)null);

                    b.HasData(
                        new
                        {
                            Id = -1,
                            LicensePlate = "AHM3G25",
                            Model = "Honda CBX",
                            Year = 2020
                        },
                        new
                        {
                            Id = -2,
                            LicensePlate = "BHM3G26",
                            Model = "Honda CBX",
                            Year = 2022
                        },
                        new
                        {
                            Id = -3,
                            LicensePlate = "GHM3G27",
                            Model = "Honda CBX",
                            Year = 2023
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
