using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassRoomMvc.Migrations
{
    public partial class changedmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignmentId",
                table: "ClassRoom");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "ClassRoom");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssignmentId",
                table: "ClassRoom",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "ClassRoom",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
