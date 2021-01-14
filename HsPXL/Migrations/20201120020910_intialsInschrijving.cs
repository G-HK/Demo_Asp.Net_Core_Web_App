using Microsoft.EntityFrameworkCore.Migrations;

namespace HsPXL.Migrations
{
    public partial class intialsInschrijving : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InschrijvingID",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InschrijvingID",
                table: "Cursus",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Inschrijving",
                columns: table => new
                {
                    InschrijvingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(nullable: false),
                    CursusID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inschrijving", x => x.InschrijvingID);
                    table.ForeignKey(
                        name: "FK_Inschrijving_Cursus_CursusID",
                        column: x => x.CursusID,
                        principalTable: "Cursus",
                        principalColumn: "CursusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inschrijving_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_InschrijvingID",
                table: "Student",
                column: "InschrijvingID");

            migrationBuilder.CreateIndex(
                name: "IX_Cursus_InschrijvingID",
                table: "Cursus",
                column: "InschrijvingID");

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijving_CursusID",
                table: "Inschrijving",
                column: "CursusID");

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijving_StudentID",
                table: "Inschrijving",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursus_Inschrijving_InschrijvingID",
                table: "Cursus",
                column: "InschrijvingID",
                principalTable: "Inschrijving",
                principalColumn: "InschrijvingID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Inschrijving_InschrijvingID",
                table: "Student",
                column: "InschrijvingID",
                principalTable: "Inschrijving",
                principalColumn: "InschrijvingID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursus_Inschrijving_InschrijvingID",
                table: "Cursus");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Inschrijving_InschrijvingID",
                table: "Student");

            migrationBuilder.DropTable(
                name: "Inschrijving");

            migrationBuilder.DropIndex(
                name: "IX_Student_InschrijvingID",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Cursus_InschrijvingID",
                table: "Cursus");

            migrationBuilder.DropColumn(
                name: "InschrijvingID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "InschrijvingID",
                table: "Cursus");
        }
    }
}
