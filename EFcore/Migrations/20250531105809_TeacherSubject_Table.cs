using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFcore.Migrations
{
    /// <inheritdoc />
    public partial class TeacherSubject_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeacher_Subjects_SubjectsId",
                table: "SubjectTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeacher_Teachers_TeachersId",
                table: "SubjectTeacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectTeacher",
                table: "SubjectTeacher");

            migrationBuilder.RenameTable(
                name: "SubjectTeacher",
                newName: "TeachersSubjects");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectTeacher_TeachersId",
                table: "TeachersSubjects",
                newName: "IX_TeachersSubjects_TeachersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeachersSubjects",
                table: "TeachersSubjects",
                columns: new[] { "SubjectsId", "TeachersId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TeachersSubjects_Subjects_SubjectsId",
                table: "TeachersSubjects",
                column: "SubjectsId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeachersSubjects_Teachers_TeachersId",
                table: "TeachersSubjects",
                column: "TeachersId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeachersSubjects_Subjects_SubjectsId",
                table: "TeachersSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_TeachersSubjects_Teachers_TeachersId",
                table: "TeachersSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeachersSubjects",
                table: "TeachersSubjects");

            migrationBuilder.RenameTable(
                name: "TeachersSubjects",
                newName: "SubjectTeacher");

            migrationBuilder.RenameIndex(
                name: "IX_TeachersSubjects_TeachersId",
                table: "SubjectTeacher",
                newName: "IX_SubjectTeacher_TeachersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectTeacher",
                table: "SubjectTeacher",
                columns: new[] { "SubjectsId", "TeachersId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_Subjects_SubjectsId",
                table: "SubjectTeacher",
                column: "SubjectsId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_Teachers_TeachersId",
                table: "SubjectTeacher",
                column: "TeachersId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
