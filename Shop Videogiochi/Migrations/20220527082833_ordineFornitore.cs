using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop_Videogiochi.Migrations
{
    public partial class ordineFornitore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria_id",
                table: "Videogiochi");

            migrationBuilder.DropColumn(
                name: "Like",
                table: "Videogiochi");

            migrationBuilder.DropColumn(
                name: "NomeFornitore",
                table: "Ordini");

            migrationBuilder.CreateIndex(
                name: "IX_Videogiochi_Id",
                table: "Videogiochi",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ordini_Id",
                table: "Ordini",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Videogiochi_Id",
                table: "Videogiochi");

            migrationBuilder.DropIndex(
                name: "IX_Ordini_Id",
                table: "Ordini");

            migrationBuilder.AddColumn<int>(
                name: "Categoria_id",
                table: "Videogiochi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Like",
                table: "Videogiochi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NomeFornitore",
                table: "Ordini",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
