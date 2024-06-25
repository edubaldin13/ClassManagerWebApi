using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace class_management_web_api.Migrations
{
    /// <inheritdoc />
    public partial class SettingEmailUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("384d6132-4fe9-44dd-bb89-45cfb302714c"));

            migrationBuilder.DeleteData(
                table: "ClassSubjects",
                keyColumn: "ClassSubjectId",
                keyValue: new Guid("0cb07996-a222-413b-9487-acd9c8a025f8"));

            migrationBuilder.DeleteData(
                table: "ClassSubjects",
                keyColumn: "ClassSubjectId",
                keyValue: new Guid("4d940304-f59c-4bc2-b0d8-352420905db1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8fed71be-b981-44df-8982-32731cce3b41"));

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "CPF", "CreatedAt", "Email", "Name", "Password", "UpdatedAt" },
                values: new object[] { new Guid("6ad21b13-b94a-4042-9347-e357c0a2b72c"), "12345678", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "eduarbaldin@gmail.com", "Admin Eduardo", "123456", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ClassSubjects",
                columns: new[] { "ClassSubjectId", "CreatedAt", "ManagerId", "Name", "TeacherId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("2212af65-2a5e-4fe2-9df2-31b3cb7df3ec"), new DateTime(2024, 6, 24, 21, 45, 8, 772, DateTimeKind.Utc).AddTicks(1348), new Guid("97f31c66-6114-487a-a364-fcd2659c01a1"), "PowerBI", new Guid("d0c7bf7b-efc0-4c63-9c9b-1bfa0e1dd207"), new DateTime(2024, 6, 24, 21, 45, 8, 772, DateTimeKind.Utc).AddTicks(1348) },
                    { new Guid("d951c6e5-9532-43e3-af57-685c977b7596"), new DateTime(2024, 6, 24, 21, 45, 8, 772, DateTimeKind.Utc).AddTicks(1344), new Guid("97f31c66-6114-487a-a364-fcd2659c01a1"), "PowerBI", new Guid("ee6393f2-abfe-47e6-8186-bc08bc4a4cd0"), new DateTime(2024, 6, 24, 21, 45, 8, 772, DateTimeKind.Utc).AddTicks(1344) }
                });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: new Guid("61794cec-ba4a-432c-af5e-f58fe07799ac"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 21, 45, 8, 772, DateTimeKind.Utc).AddTicks(1324), new DateTime(2024, 6, 24, 21, 45, 8, 772, DateTimeKind.Utc).AddTicks(1324) });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: new Guid("97f31c66-6114-487a-a364-fcd2659c01a1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 21, 45, 8, 772, DateTimeKind.Utc).AddTicks(1320), new DateTime(2024, 6, 24, 21, 45, 8, 772, DateTimeKind.Utc).AddTicks(1321) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: new Guid("d0c7bf7b-efc0-4c63-9c9b-1bfa0e1dd207"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 21, 45, 8, 772, DateTimeKind.Utc).AddTicks(1295), new DateTime(2024, 6, 24, 21, 45, 8, 772, DateTimeKind.Utc).AddTicks(1296) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: new Guid("ee6393f2-abfe-47e6-8186-bc08bc4a4cd0"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 21, 45, 8, 772, DateTimeKind.Utc).AddTicks(1292), new DateTime(2024, 6, 24, 21, 45, 8, 772, DateTimeKind.Utc).AddTicks(1292) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CPF", "CreatedAt", "Email", "Name", "Password", "Role", "Salt", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("dc9e38e5-50fe-4ece-83e0-510bf7be5aa5"), "12345678", new DateTime(2024, 6, 24, 21, 45, 8, 772, DateTimeKind.Utc).AddTicks(1255), "diretor@gmail.com", "Diretor Teste", "123456", 2, "y9wrDdai3E=k", new DateTime(2024, 6, 24, 21, 45, 8, 772, DateTimeKind.Utc).AddTicks(1256) },
                    { new Guid("e0528a07-6659-43c1-988c-9d26c6e883b5"), "12345678", new DateTime(2024, 6, 24, 21, 45, 8, 772, DateTimeKind.Utc).AddTicks(1247), "eduarbaldin@gmail.com", "Admin", "123456", 3, "y9wrDdai3E=n", new DateTime(2024, 6, 24, 21, 45, 8, 772, DateTimeKind.Utc).AddTicks(1250) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("6ad21b13-b94a-4042-9347-e357c0a2b72c"));

            migrationBuilder.DeleteData(
                table: "ClassSubjects",
                keyColumn: "ClassSubjectId",
                keyValue: new Guid("2212af65-2a5e-4fe2-9df2-31b3cb7df3ec"));

            migrationBuilder.DeleteData(
                table: "ClassSubjects",
                keyColumn: "ClassSubjectId",
                keyValue: new Guid("d951c6e5-9532-43e3-af57-685c977b7596"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dc9e38e5-50fe-4ece-83e0-510bf7be5aa5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e0528a07-6659-43c1-988c-9d26c6e883b5"));

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "CPF", "CreatedAt", "Email", "Name", "Password", "UpdatedAt" },
                values: new object[] { new Guid("384d6132-4fe9-44dd-bb89-45cfb302714c"), "12345678", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "eduarbaldin@gmail.com", "Admin Eduardo", "123456", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ClassSubjects",
                columns: new[] { "ClassSubjectId", "CreatedAt", "ManagerId", "Name", "TeacherId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0cb07996-a222-413b-9487-acd9c8a025f8"), new DateTime(2024, 6, 23, 21, 54, 56, 812, DateTimeKind.Utc).AddTicks(6631), new Guid("97f31c66-6114-487a-a364-fcd2659c01a1"), "PowerBI", new Guid("d0c7bf7b-efc0-4c63-9c9b-1bfa0e1dd207"), new DateTime(2024, 6, 23, 21, 54, 56, 812, DateTimeKind.Utc).AddTicks(6631) },
                    { new Guid("4d940304-f59c-4bc2-b0d8-352420905db1"), new DateTime(2024, 6, 23, 21, 54, 56, 812, DateTimeKind.Utc).AddTicks(6627), new Guid("97f31c66-6114-487a-a364-fcd2659c01a1"), "PowerBI", new Guid("ee6393f2-abfe-47e6-8186-bc08bc4a4cd0"), new DateTime(2024, 6, 23, 21, 54, 56, 812, DateTimeKind.Utc).AddTicks(6628) }
                });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: new Guid("61794cec-ba4a-432c-af5e-f58fe07799ac"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 23, 21, 54, 56, 812, DateTimeKind.Utc).AddTicks(6604), new DateTime(2024, 6, 23, 21, 54, 56, 812, DateTimeKind.Utc).AddTicks(6604) });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: new Guid("97f31c66-6114-487a-a364-fcd2659c01a1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 23, 21, 54, 56, 812, DateTimeKind.Utc).AddTicks(6599), new DateTime(2024, 6, 23, 21, 54, 56, 812, DateTimeKind.Utc).AddTicks(6601) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: new Guid("d0c7bf7b-efc0-4c63-9c9b-1bfa0e1dd207"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 23, 21, 54, 56, 812, DateTimeKind.Utc).AddTicks(6534), new DateTime(2024, 6, 23, 21, 54, 56, 812, DateTimeKind.Utc).AddTicks(6535) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: new Guid("ee6393f2-abfe-47e6-8186-bc08bc4a4cd0"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 23, 21, 54, 56, 812, DateTimeKind.Utc).AddTicks(6530), new DateTime(2024, 6, 23, 21, 54, 56, 812, DateTimeKind.Utc).AddTicks(6531) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CPF", "CreatedAt", "Email", "Name", "Password", "Role", "Salt", "UpdatedAt" },
                values: new object[] { new Guid("8fed71be-b981-44df-8982-32731cce3b41"), "12345678", new DateTime(2024, 6, 23, 21, 54, 56, 812, DateTimeKind.Utc).AddTicks(6496), "eduarbaldin@gmail.com", "Admin", "123456", 3, "y9wrDdai3E=n", new DateTime(2024, 6, 23, 21, 54, 56, 812, DateTimeKind.Utc).AddTicks(6497) });
        }
    }
}
