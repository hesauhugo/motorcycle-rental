using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorcycleRental.Infrastructure.Persistence.Migrations
{
    public partial class customerBirthDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cnh",
                table: "customer",
                newName: "cnh");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "customer",
                newName: "birth_date");

            migrationBuilder.RenameIndex(
                name: "IX_customer_Cnh",
                table: "customer",
                newName: "IX_customer_cnh");

            migrationBuilder.AlterColumn<DateTime>(
                name: "birth_date",
                table: "customer",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cnh",
                table: "customer",
                newName: "Cnh");

            migrationBuilder.RenameColumn(
                name: "birth_date",
                table: "customer",
                newName: "BirthDate");

            migrationBuilder.RenameIndex(
                name: "IX_customer_cnh",
                table: "customer",
                newName: "IX_customer_Cnh");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "customer",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
