using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop_Videogiochi.Migrations
{
    public partial class relazioni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Videogiochi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VideogiocoId",
                table: "Ordini",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Videogiochi_CategoriaId",
                table: "Videogiochi",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordini_VideogiocoId",
                table: "Ordini",
                column: "VideogiocoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordini_Videogiochi_VideogiocoId",
                table: "Ordini",
                column: "VideogiocoId",
                principalTable: "Videogiochi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Videogiochi_Categoria_CategoriaId",
                table: "Videogiochi",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordini_Videogiochi_VideogiocoId",
                table: "Ordini");

            migrationBuilder.DropForeignKey(
                name: "FK_Videogiochi_Categoria_CategoriaId",
                table: "Videogiochi");

            migrationBuilder.DropIndex(
                name: "IX_Videogiochi_CategoriaId",
                table: "Videogiochi");

            migrationBuilder.DropIndex(
                name: "IX_Ordini_VideogiocoId",
                table: "Ordini");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Videogiochi");

            migrationBuilder.DropColumn(
                name: "VideogiocoId",
                table: "Ordini");
        }
    }
}
