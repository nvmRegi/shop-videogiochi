using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop_Videogiochi.Migrations
{
    public partial class ordineFornitore3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrdiniFornitore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Videogame_id = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantità = table.Column<int>(type: "int", nullable: false),
                    NomeFornitore = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VideogiocoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdiniFornitore", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdiniFornitore_Videogiochi_VideogiocoId",
                        column: x => x.VideogiocoId,
                        principalTable: "Videogiochi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdiniFornitore_Id",
                table: "OrdiniFornitore",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrdiniFornitore_VideogiocoId",
                table: "OrdiniFornitore",
                column: "VideogiocoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdiniFornitore");
        }
    }
}
