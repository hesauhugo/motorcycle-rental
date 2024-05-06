using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorcycleRental.Infrastructure.Persistence.Migrations
{
    public partial class motorcycleId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "motorcycle",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "motorcycle",
                newName: "Id");
        }
    }
}
