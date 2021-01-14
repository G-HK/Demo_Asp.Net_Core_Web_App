using Microsoft.EntityFrameworkCore.Migrations;

namespace HsPXL.Migrations
{
    public partial class update_SublistsV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursus_Inschrijving_InschrijvingID",
                table: "Cursus");

            migrationBuilder.DropForeignKey(
                name: "FK_Cursus_Student_StudentID",
                table: "Cursus");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Inschrijving_InschrijvingID",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_InschrijvingID",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Cursus_InschrijvingID",
                table: "Cursus");

            migrationBuilder.DropIndex(
                name: "IX_Cursus_StudentID",
                table: "Cursus");

            migrationBuilder.DropColumn(
                name: "InschrijvingID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "InschrijvingID",
                table: "Cursus");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "Cursus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InschrijvingID",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InschrijvingID",
                table: "Cursus",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentID",
                table: "Cursus",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_InschrijvingID",
                table: "Student",
                column: "InschrijvingID");

            migrationBuilder.CreateIndex(
                name: "IX_Cursus_InschrijvingID",
                table: "Cursus",
                column: "InschrijvingID");

            migrationBuilder.CreateIndex(
                name: "IX_Cursus_StudentID",
                table: "Cursus",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursus_Inschrijving_InschrijvingID",
                table: "Cursus",
                column: "InschrijvingID",
                principalTable: "Inschrijving",
                principalColumn: "InschrijvingID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cursus_Student_StudentID",
                table: "Cursus",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Inschrijving_InschrijvingID",
                table: "Student",
                column: "InschrijvingID",
                principalTable: "Inschrijving",
                principalColumn: "InschrijvingID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
