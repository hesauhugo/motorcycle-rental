using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorcycleRental.Infrastructure.Persistence.Migrations
{
    public partial class customerFixNames2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tipo_cnh",
                table: "customer",
                newName: "cnh_kind");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cnh_kind",
                table: "customer",
                newName: "tipo_cnh");
        }
    }
}
