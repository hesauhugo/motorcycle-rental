using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorcycleRental.Infrastructure.Persistence.Migrations
{
    public partial class motorcycleSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "motorcycle",
                columns: new[] { "Id", "license_plate", "model", "year" },
                values: new object[,]
                {
                    { -3, "GHM3G27", "Honda CBX", 2023 },
                    { -2, "BHM3G26", "Honda CBX", 2022 },
                    { -1, "AHM3G25", "Honda CBX", 2020 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "motorcycle",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "motorcycle",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "motorcycle",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
