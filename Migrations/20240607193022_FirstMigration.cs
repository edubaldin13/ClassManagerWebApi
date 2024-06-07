using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace class_management_web_api.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassTime",
                columns: table => new
                {
                    ClassTimeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassStartingHour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassClosingHour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassDuration = table.Column<int>(type: "int", nullable: false),
                    WeekDay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassesQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassTime", x => x.ClassTimeId);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.ManagerId);
                });

            migrationBuilder.CreateTable(
                name: "Registers",
                columns: table => new
                {
                    RegisterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivationKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: true),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registers", x => x.RegisterId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GraduationCourses",
                columns: table => new
                {
                    GraduationCourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassesQuantity = table.Column<int>(type: "int", nullable: false),
                    ClassDuration = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraduationCourses", x => x.GraduationCourseId);
                    table.ForeignKey(
                        name: "FK_GraduationCourses_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    TeacherDoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraduationCourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherId);
                    table.ForeignKey(
                        name: "FK_Teachers_GraduationCourses_GraduationCourseId",
                        column: x => x.GraduationCourseId,
                        principalTable: "GraduationCourses",
                        principalColumn: "GraduationCourseId");
                });

            migrationBuilder.CreateTable(
                name: "ClassSubjects",
                columns: table => new
                {
                    ClassSubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSubjects", x => x.ClassSubjectId);
                    table.ForeignKey(
                        name: "FK_ClassSubjects_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassSubjects_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Principals",
                columns: table => new
                {
                    PrincipalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    PrincipalDoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassSubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Principals", x => x.PrincipalId);
                    table.ForeignKey(
                        name: "FK_Principals_ClassSubjects_ClassSubjectId",
                        column: x => x.ClassSubjectId,
                        principalTable: "ClassSubjects",
                        principalColumn: "ClassSubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "CPF", "CreatedAt", "Email", "Name", "Password", "UpdatedAt" },
                values: new object[] { new Guid("98011c21-3488-48d2-b76e-d5d36a3c6bb3"), "12345678", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "eduarbaldin@gmail.com", "Admin Eduardo", "123456", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "ManagerId", "CPF", "CreatedAt", "Email", "Name", "Password", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("61794cec-ba4a-432c-af5e-f58fe07799ac"), "12345678", new DateTime(2024, 6, 7, 19, 30, 20, 103, DateTimeKind.Utc).AddTicks(4321), "pedro@gmail.com", "Pedro", "123456", "Manager", new DateTime(2024, 6, 7, 19, 30, 20, 103, DateTimeKind.Utc).AddTicks(4322) },
                    { new Guid("97f31c66-6114-487a-a364-fcd2659c01a1"), "12345678", new DateTime(2024, 6, 7, 19, 30, 20, 103, DateTimeKind.Utc).AddTicks(4318), "teste@gmail.com", "Cordenador Teste", "123456", "Manager", new DateTime(2024, 6, 7, 19, 30, 20, 103, DateTimeKind.Utc).AddTicks(4319) }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherId", "CPF", "CreatedAt", "Email", "GraduationCourseId", "Name", "Password", "Role", "TeacherDoc", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("d0c7bf7b-efc0-4c63-9c9b-1bfa0e1dd207"), "12345678", new DateTime(2024, 6, 7, 19, 30, 20, 103, DateTimeKind.Utc).AddTicks(4292), "tiago@gmail.com", null, "Tiago", "123456", "Teacher", null, new DateTime(2024, 6, 7, 19, 30, 20, 103, DateTimeKind.Utc).AddTicks(4293) },
                    { new Guid("ee6393f2-abfe-47e6-8186-bc08bc4a4cd0"), "12345678", new DateTime(2024, 6, 7, 19, 30, 20, 103, DateTimeKind.Utc).AddTicks(4289), "johanny@gmail.com", null, "Johanny", "123456", "Teacher", null, new DateTime(2024, 6, 7, 19, 30, 20, 103, DateTimeKind.Utc).AddTicks(4290) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CPF", "CreatedAt", "Email", "Name", "Password", "Role", "Salt", "UpdatedAt" },
                values: new object[] { new Guid("00121be3-d7ea-44c9-bf85-fad1d644f09e"), "12345678", new DateTime(2024, 6, 7, 19, 30, 20, 103, DateTimeKind.Utc).AddTicks(4243), "eduarbaldin@gmail.com", "Admin", "123456", 3, "y9wrDdai3E=n", new DateTime(2024, 6, 7, 19, 30, 20, 103, DateTimeKind.Utc).AddTicks(4247) });

            migrationBuilder.InsertData(
                table: "ClassSubjects",
                columns: new[] { "ClassSubjectId", "CreatedAt", "ManagerId", "Name", "TeacherId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("26188154-36fc-41a5-9263-3254fe8b29cc"), new DateTime(2024, 6, 7, 19, 30, 20, 103, DateTimeKind.Utc).AddTicks(4342), new Guid("97f31c66-6114-487a-a364-fcd2659c01a1"), "PowerBI", new Guid("ee6393f2-abfe-47e6-8186-bc08bc4a4cd0"), new DateTime(2024, 6, 7, 19, 30, 20, 103, DateTimeKind.Utc).AddTicks(4344) },
                    { new Guid("fbd7278a-278e-437d-93b0-35875b332b9a"), new DateTime(2024, 6, 7, 19, 30, 20, 103, DateTimeKind.Utc).AddTicks(4347), new Guid("97f31c66-6114-487a-a364-fcd2659c01a1"), "PowerBI", new Guid("d0c7bf7b-efc0-4c63-9c9b-1bfa0e1dd207"), new DateTime(2024, 6, 7, 19, 30, 20, 103, DateTimeKind.Utc).AddTicks(4348) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjects_ManagerId",
                table: "ClassSubjects",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjects_TeacherId",
                table: "ClassSubjects",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_GraduationCourses_ManagerId",
                table: "GraduationCourses",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Principals_ClassSubjectId",
                table: "Principals",
                column: "ClassSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_GraduationCourseId",
                table: "Teachers",
                column: "GraduationCourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "ClassTime");

            migrationBuilder.DropTable(
                name: "Principals");

            migrationBuilder.DropTable(
                name: "Registers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ClassSubjects");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "GraduationCourses");

            migrationBuilder.DropTable(
                name: "Managers");
        }
    }
}
