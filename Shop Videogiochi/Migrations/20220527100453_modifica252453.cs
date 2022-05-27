using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop_Videogiochi.Migrations
{
    public partial class modifica252453 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Videogame_id",
                table: "OrdiniFornitore");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Videogame_id",
                table: "OrdiniFornitore",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
