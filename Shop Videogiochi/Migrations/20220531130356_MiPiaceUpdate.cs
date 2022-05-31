using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop_Videogiochi.Migrations
{
    public partial class MiPiaceUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Like",
                table: "Videogiochi",
                newName: "MiPiace");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MiPiace",
                table: "Videogiochi",
                newName: "Like");
        }
    }
}
