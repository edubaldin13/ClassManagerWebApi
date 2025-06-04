using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassManagementWebApi.Migrations
{
    /// <inheritdoc />
    public partial class adicionandoMateriaNoHorarioAula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassSubjectId",
                table: "ClassTimes",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassTimes_ClassSubjectId",
                table: "ClassTimes",
                column: "ClassSubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassTimes_ClassSubjects_ClassSubjectId",
                table: "ClassTimes",
                column: "ClassSubjectId",
                principalTable: "ClassSubjects",
                principalColumn: "ClassSubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassTimes_ClassSubjects_ClassSubjectId",
                table: "ClassTimes");

            migrationBuilder.DropIndex(
                name: "IX_ClassTimes_ClassSubjectId",
                table: "ClassTimes");

            migrationBuilder.DropColumn(
                name: "ClassSubjectId",
                table: "ClassTimes");
        }
    }
}
