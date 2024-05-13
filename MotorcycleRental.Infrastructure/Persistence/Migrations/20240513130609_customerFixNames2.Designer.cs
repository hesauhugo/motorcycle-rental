﻿// <auto-generated />
using System;
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
    [Migration("20240513130609_customerFixNames2")]
    partial class customerFixNames2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MotorcycleRental.Core.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnName("birth_date");

                    b.Property<string>("Cnh")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cnh");

                    b.Property<string>("CnhKind")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cnh_kind");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cnpj");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("full_name");

                    b.HasKey("Id");

                    b.HasIndex("Cnh")
                        .IsUnique();

                    b.HasIndex("Cnpj")
                        .IsUnique();

                    b.ToTable("customer", (string)null);
                });

            modelBuilder.Entity("MotorcycleRental.Core.Entities.Motorcycle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

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

                    b.HasIndex("LicensePlate")
                        .IsUnique();

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

            modelBuilder.Entity("MotorcycleRental.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean")
                        .HasColumnName("active");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnName("birth_date");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("date")
                        .HasColumnName("create_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("full_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("role");

                    b.HasKey("Id");

                    b.ToTable("user", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
