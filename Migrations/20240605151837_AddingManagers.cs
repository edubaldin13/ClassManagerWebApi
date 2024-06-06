using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace class_management_web_api.Migrations
{
    /// <inheritdoc />
    public partial class AddingManagers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("7675c866-ebc4-4449-ba15-88f33c31f0da"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cd79aed6-ff39-4c43-9ea4-6ca6f404f416"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ClassSubjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "CPF", "CreatedAt", "Email", "Name", "Password", "UpdatedAt" },
                values: new object[] { new Guid("62095c4d-a399-4b94-9bc7-33ddb80ba539"), "12345678", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "eduarbaldin@gmail.com", "Admin", "123456", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "ManagerId", "CPF", "CreatedAt", "Email", "ManagerDoc", "Name", "Password", "Role", "UpdatedAt" },
                values: new object[] { new Guid("97f31c66-6114-487a-a364-fcd2659c01a1"), "12345678", new DateTime(2024, 6, 5, 15, 18, 36, 778, DateTimeKind.Utc).AddTicks(8946), "eduarbaldin@gmail.com", null, "Cordenador Teste", "123456", "Manager", new DateTime(2024, 6, 5, 15, 18, 36, 778, DateTimeKind.Utc).AddTicks(8947) });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherId", "CPF", "CreatedAt", "Email", "Name", "Password", "Role", "TeacherDoc", "UpdatedAt" },
                values: new object[] { new Guid("ee6393f2-abfe-47e6-8186-bc08bc4a4cd0"), "12345678", new DateTime(2024, 6, 5, 15, 18, 36, 778, DateTimeKind.Utc).AddTicks(8924), "eduarbaldin@gmail.com", "Teacher Teste", "123456", "Teacher", null, new DateTime(2024, 6, 5, 15, 18, 36, 778, DateTimeKind.Utc).AddTicks(8925) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CPF", "CreatedAt", "Email", "Name", "Password", "Role", "Salt", "UpdatedAt" },
                values: new object[] { new Guid("52c97cbb-e4e5-49f6-ae36-a3d63ae3856a"), "12345678", new DateTime(2024, 6, 5, 15, 18, 36, 778, DateTimeKind.Utc).AddTicks(8885), "eduarbaldin@gmail.com", "Admin", "123456", 0, "y9wrDdai3E=n", new DateTime(2024, 6, 5, 15, 18, 36, 778, DateTimeKind.Utc).AddTicks(8887) });

            migrationBuilder.InsertData(
                table: "ClassSubjects",
                columns: new[] { "ClassSubjectId", "CreatedAt", "ManagerId", "Name", "TeacherId", "UpdatedAt" },
                values: new object[] { new Guid("f7185071-181e-4abe-a8c1-ca80ef72aa16"), new DateTime(2024, 6, 5, 15, 18, 36, 778, DateTimeKind.Utc).AddTicks(8967), new Guid("97f31c66-6114-487a-a364-fcd2659c01a1"), "Materia Teste", new Guid("ee6393f2-abfe-47e6-8186-bc08bc4a4cd0"), new DateTime(2024, 6, 5, 15, 18, 36, 778, DateTimeKind.Utc).AddTicks(8967) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("62095c4d-a399-4b94-9bc7-33ddb80ba539"));

            migrationBuilder.DeleteData(
                table: "ClassSubjects",
                keyColumn: "ClassSubjectId",
                keyValue: new Guid("f7185071-181e-4abe-a8c1-ca80ef72aa16"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("52c97cbb-e4e5-49f6-ae36-a3d63ae3856a"));

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: new Guid("97f31c66-6114-487a-a364-fcd2659c01a1"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: new Guid("ee6393f2-abfe-47e6-8186-bc08bc4a4cd0"));

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ClassSubjects");

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "CPF", "CreatedAt", "Email", "Name", "Password", "UpdatedAt" },
                values: new object[] { new Guid("7675c866-ebc4-4449-ba15-88f33c31f0da"), "12345678", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "eduarbaldin@gmail.com", "Admin", "123456", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CPF", "CreatedAt", "Email", "Name", "Password", "Role", "Salt", "UpdatedAt" },
                values: new object[] { new Guid("cd79aed6-ff39-4c43-9ea4-6ca6f404f416"), "12345678", new DateTime(2024, 6, 5, 4, 31, 25, 489, DateTimeKind.Utc).AddTicks(63), "eduarbaldin@gmail.com", "Admin", "123456", 0, "y9wrDdai3E=n", new DateTime(2024, 6, 5, 4, 31, 25, 489, DateTimeKind.Utc).AddTicks(66) });
        }
    }
}
