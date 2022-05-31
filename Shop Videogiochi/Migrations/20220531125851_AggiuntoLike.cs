using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop_Videogiochi.Migrations
{
    public partial class AggiuntoLike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videogiochi_Categoria_CategoriaId",
                table: "Videogiochi");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Videogiochi",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Like",
                table: "Videogiochi",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Videogiochi_Categoria_CategoriaId",
                table: "Videogiochi",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videogiochi_Categoria_CategoriaId",
                table: "Videogiochi");

            migrationBuilder.DropColumn(
                name: "Like",
                table: "Videogiochi");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Videogiochi",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Videogiochi_Categoria_CategoriaId",
                table: "Videogiochi",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
