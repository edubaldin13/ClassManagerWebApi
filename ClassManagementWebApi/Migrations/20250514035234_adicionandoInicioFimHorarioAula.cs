using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassManagementWebApi.Migrations
{
    /// <inheritdoc />
    public partial class adicionandoInicioFimHorarioAula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "ClassTimes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "ClassTimes",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "End",
                table: "ClassTimes");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "ClassTimes");
        }
    }
}
