using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassManagementWebApi.Migrations
{
    /// <inheritdoc />
    public partial class mudandoLogicaAulas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeacherIdDay1",
                table: "ClassTimes");

            migrationBuilder.DropColumn(
                name: "TeacherIdDay2",
                table: "ClassTimes");

            migrationBuilder.DropColumn(
                name: "TeacherIdDay3",
                table: "ClassTimes");

            migrationBuilder.DropColumn(
                name: "TeacherIdDay4",
                table: "ClassTimes");

            migrationBuilder.DropColumn(
                name: "TeacherIdDay5",
                table: "ClassTimes");

            migrationBuilder.AddColumn<int>(
                name: "TeacherIdDay",
                table: "ClassTimes",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeacherIdDay",
                table: "ClassTimes");

            migrationBuilder.AddColumn<int>(
                name: "TeacherIdDay1",
                table: "ClassTimes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherIdDay2",
                table: "ClassTimes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherIdDay3",
                table: "ClassTimes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherIdDay4",
                table: "ClassTimes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherIdDay5",
                table: "ClassTimes",
                type: "integer",
                nullable: true);
        }
    }
}
