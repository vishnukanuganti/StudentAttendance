using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAttendance.Migrations
{
    /// <inheritdoc />
    public partial class file5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentID",
                table: "Classes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classes_StudentID",
                table: "Classes",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Students_StudentID",
                table: "Classes",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Students_StudentID",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_StudentID",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "Classes");
        }
    }
}
