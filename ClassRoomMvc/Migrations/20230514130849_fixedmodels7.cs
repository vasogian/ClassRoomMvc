using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassRoomMvc.Migrations
{
    public partial class fixedmodels7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassRoom_Teacher_TeacherId1",
                table: "ClassRoom");

            migrationBuilder.DropIndex(
                name: "IX_ClassRoom_TeacherId1",
                table: "ClassRoom");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "ClassRoom");

            migrationBuilder.RenameColumn(
                name: "TeacherId1",
                table: "ClassRoom",
                newName: "Capacity");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ClassRoom",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AssignmentStudent",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(type: "int", nullable: false),
                    StudentsStudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentStudent", x => new { x.AssignmentId, x.StudentsStudentId });
                    table.ForeignKey(
                        name: "FK_AssignmentStudent_Assignment_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignment",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignmentStudent_Student_StudentsStudentId",
                        column: x => x.StudentsStudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_ClassRoomId",
                table: "Teacher",
                column: "ClassRoomId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentStudent_StudentsStudentId",
                table: "AssignmentStudent",
                column: "StudentsStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_ClassRoom_ClassRoomId",
                table: "Teacher",
                column: "ClassRoomId",
                principalTable: "ClassRoom",
                principalColumn: "ClassRoomId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_ClassRoom_ClassRoomId",
                table: "Teacher");

            migrationBuilder.DropTable(
                name: "AssignmentStudent");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_ClassRoomId",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ClassRoom");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "ClassRoom",
                newName: "TeacherId1");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "ClassRoom",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ClassRoom_TeacherId1",
                table: "ClassRoom",
                column: "TeacherId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRoom_Teacher_TeacherId1",
                table: "ClassRoom",
                column: "TeacherId1",
                principalTable: "Teacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
