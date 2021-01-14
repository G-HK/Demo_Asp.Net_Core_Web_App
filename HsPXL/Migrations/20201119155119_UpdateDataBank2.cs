using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HsPXL.Migrations
{
    public partial class UpdateDataBank2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HandBoek",
                columns: table => new
                {
                    HandBoekID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    KostPrijs = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    UitgiftDatum = table.Column<DateTime>(nullable: false),
                    Afbeelding = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    CursusID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HandBoek", x => x.HandBoekID);
                });

            migrationBuilder.CreateTable(
                name: "Cursus",
                columns: table => new
                {
                    CursusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CursusName = table.Column<string>(nullable: false),
                    Studiepunten = table.Column<int>(nullable: false),
                    HandboekID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursus", x => x.CursusID);
                    table.ForeignKey(
                        name: "FK_Cursus_HandBoek_HandboekID",
                        column: x => x.HandboekID,
                        principalTable: "HandBoek",
                        principalColumn: "HandBoekID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cursus_HandboekID",
                table: "Cursus",
                column: "HandboekID");

            migrationBuilder.CreateIndex(
                name: "IX_HandBoek_CursusID",
                table: "HandBoek",
                column: "CursusID");

            migrationBuilder.AddForeignKey(
                name: "FK_HandBoek_Cursus_CursusID",
                table: "HandBoek",
                column: "CursusID",
                principalTable: "Cursus",
                principalColumn: "CursusID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursus_HandBoek_HandboekID",
                table: "Cursus");

            migrationBuilder.DropTable(
                name: "HandBoek");

            migrationBuilder.DropTable(
                name: "Cursus");
        }
    }
}
