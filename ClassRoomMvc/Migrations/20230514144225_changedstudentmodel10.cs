using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassRoomMvc.Migrations
{
    public partial class changedstudentmodel10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_ClassRoom_ClassRoomId",
                table: "Student");

            migrationBuilder.AlterColumn<int>(
                name: "ClassRoomId",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_ClassRoom_ClassRoomId",
                table: "Student",
                column: "ClassRoomId",
                principalTable: "ClassRoom",
                principalColumn: "ClassRoomId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_ClassRoom_ClassRoomId",
                table: "Student");

            migrationBuilder.AlterColumn<int>(
                name: "ClassRoomId",
                table: "Student",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_ClassRoom_ClassRoomId",
                table: "Student",
                column: "ClassRoomId",
                principalTable: "ClassRoom",
                principalColumn: "ClassRoomId");
        }
    }
}
