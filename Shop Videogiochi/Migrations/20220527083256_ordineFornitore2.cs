using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop_Videogiochi.Migrations
{
    public partial class ordineFornitore2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Videogame_id",
                table: "Ordini");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Videogame_id",
                table: "Ordini",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
