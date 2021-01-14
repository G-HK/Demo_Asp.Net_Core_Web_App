using Microsoft.EntityFrameworkCore.Migrations;

namespace HsPXL.Migrations
{
    public partial class update_Sublists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentID",
                table: "Cursus",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cursus_StudentID",
                table: "Cursus",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursus_Student_StudentID",
                table: "Cursus",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursus_Student_StudentID",
                table: "Cursus");

            migrationBuilder.DropIndex(
                name: "IX_Cursus_StudentID",
                table: "Cursus");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "Cursus");
        }
    }
}
