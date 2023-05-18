using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassRoomMvc.Migrations
{
    public partial class RemoveFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignmentId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Assignment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssignmentId",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Assignment",
                type: "int",
                nullable: true);
        }
    }
}
