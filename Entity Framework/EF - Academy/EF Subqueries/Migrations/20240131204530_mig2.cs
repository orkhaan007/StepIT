using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Subqueries.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Faculty_FacultyId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Group_Department_DepartmentId",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupCurators_Curator_CuratorId",
                table: "GroupCurators");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupCurators_Group_GroupId",
                table: "GroupCurators");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupLectures_Group_GroupId",
                table: "GroupLectures");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupLectures_Lecture_LectureId",
                table: "GroupLectures");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupStudents_Group_GroupId",
                table: "GroupStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecture_Subjects_SubjectId",
                table: "Lecture");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecture_Teachers_TeacherId",
                table: "Lecture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lecture",
                table: "Lecture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                table: "Group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Faculty",
                table: "Faculty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Curator",
                table: "Curator");

            migrationBuilder.RenameTable(
                name: "Lecture",
                newName: "Lecturies");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "Groups");

            migrationBuilder.RenameTable(
                name: "Faculty",
                newName: "Faculties");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");

            migrationBuilder.RenameTable(
                name: "Curator",
                newName: "Curators");

            migrationBuilder.RenameIndex(
                name: "IX_Lecture_TeacherId",
                table: "Lecturies",
                newName: "IX_Lecturies_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Lecture_SubjectId",
                table: "Lecturies",
                newName: "IX_Lecturies_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Group_Name",
                table: "Groups",
                newName: "IX_Groups_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Group_DepartmentId",
                table: "Groups",
                newName: "IX_Groups_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Faculty_Name",
                table: "Faculties",
                newName: "IX_Faculties_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Department_Name",
                table: "Departments",
                newName: "IX_Departments_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Department_FacultyId",
                table: "Departments",
                newName: "IX_Departments_FacultyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lecturies",
                table: "Lecturies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Faculties",
                table: "Faculties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Curators",
                table: "Curators",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Faculties_FacultyId",
                table: "Departments",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupCurators_Curators_CuratorId",
                table: "GroupCurators",
                column: "CuratorId",
                principalTable: "Curators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupCurators_Groups_GroupId",
                table: "GroupCurators",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLectures_Groups_GroupId",
                table: "GroupLectures",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLectures_Lecturies_LectureId",
                table: "GroupLectures",
                column: "LectureId",
                principalTable: "Lecturies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Departments_DepartmentId",
                table: "Groups",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupStudents_Groups_GroupId",
                table: "GroupStudents",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturies_Subjects_SubjectId",
                table: "Lecturies",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturies_Teachers_TeacherId",
                table: "Lecturies",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Faculties_FacultyId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupCurators_Curators_CuratorId",
                table: "GroupCurators");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupCurators_Groups_GroupId",
                table: "GroupCurators");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupLectures_Groups_GroupId",
                table: "GroupLectures");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupLectures_Lecturies_LectureId",
                table: "GroupLectures");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Departments_DepartmentId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupStudents_Groups_GroupId",
                table: "GroupStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecturies_Subjects_SubjectId",
                table: "Lecturies");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecturies_Teachers_TeacherId",
                table: "Lecturies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lecturies",
                table: "Lecturies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Faculties",
                table: "Faculties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Curators",
                table: "Curators");

            migrationBuilder.RenameTable(
                name: "Lecturies",
                newName: "Lecture");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Group");

            migrationBuilder.RenameTable(
                name: "Faculties",
                newName: "Faculty");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");

            migrationBuilder.RenameTable(
                name: "Curators",
                newName: "Curator");

            migrationBuilder.RenameIndex(
                name: "IX_Lecturies_TeacherId",
                table: "Lecture",
                newName: "IX_Lecture_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Lecturies_SubjectId",
                table: "Lecture",
                newName: "IX_Lecture_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_Name",
                table: "Group",
                newName: "IX_Group_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_DepartmentId",
                table: "Group",
                newName: "IX_Group_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Faculties_Name",
                table: "Faculty",
                newName: "IX_Faculty_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_Name",
                table: "Department",
                newName: "IX_Department_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_FacultyId",
                table: "Department",
                newName: "IX_Department_FacultyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lecture",
                table: "Lecture",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Faculty",
                table: "Faculty",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Curator",
                table: "Curator",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Faculty_FacultyId",
                table: "Department",
                column: "FacultyId",
                principalTable: "Faculty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Department_DepartmentId",
                table: "Group",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupCurators_Curator_CuratorId",
                table: "GroupCurators",
                column: "CuratorId",
                principalTable: "Curator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupCurators_Group_GroupId",
                table: "GroupCurators",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLectures_Group_GroupId",
                table: "GroupLectures",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLectures_Lecture_LectureId",
                table: "GroupLectures",
                column: "LectureId",
                principalTable: "Lecture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupStudents_Group_GroupId",
                table: "GroupStudents",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lecture_Subjects_SubjectId",
                table: "Lecture",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lecture_Teachers_TeacherId",
                table: "Lecture",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
