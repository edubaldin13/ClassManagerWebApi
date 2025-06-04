using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassManagementWebApi.Migrations
{
    /// <inheritdoc />
    public partial class removendoTeacherDayDoCurso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeacherIdDay1",
                table: "GraduationCourses");

            migrationBuilder.DropColumn(
                name: "TeacherIdDay2",
                table: "GraduationCourses");

            migrationBuilder.DropColumn(
                name: "TeacherIdDay3",
                table: "GraduationCourses");

            migrationBuilder.DropColumn(
                name: "TeacherIdDay4",
                table: "GraduationCourses");

            migrationBuilder.DropColumn(
                name: "TeacherIdDay5",
                table: "GraduationCourses");

            migrationBuilder.DropColumn(
                name: "TeacherIdDay6",
                table: "GraduationCourses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherIdDay1",
                table: "GraduationCourses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherIdDay2",
                table: "GraduationCourses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherIdDay3",
                table: "GraduationCourses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherIdDay4",
                table: "GraduationCourses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherIdDay5",
                table: "GraduationCourses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherIdDay6",
                table: "GraduationCourses",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
