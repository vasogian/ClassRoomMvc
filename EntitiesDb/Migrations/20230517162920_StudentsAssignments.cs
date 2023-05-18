using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassRoomMvc.Migrations
{
    public partial class StudentsAssignments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Student_StudentId",
                table: "Assignment");

            migrationBuilder.DropIndex(
                name: "IX_Assignment_StudentId",
                table: "Assignment");

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
                name: "IX_AssignmentStudent_StudentsStudentId",
                table: "AssignmentStudent",
                column: "StudentsStudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignmentStudent");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_StudentId",
                table: "Assignment",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Student_StudentId",
                table: "Assignment",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "StudentId");
        }
    }
}
