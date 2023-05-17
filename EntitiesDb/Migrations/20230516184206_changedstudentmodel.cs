using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassRoomMvc.Migrations
{
    public partial class changedstudentmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssignmentId",
                table: "Student",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignmentId",
                table: "Student");
        }
    }
}
