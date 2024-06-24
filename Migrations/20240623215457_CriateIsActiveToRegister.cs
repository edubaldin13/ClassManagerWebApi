using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace class_management_web_api.Migrations
{
    /// <inheritdoc />
    public partial class CriateIsActiveToRegister : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("29e10d80-4701-49cb-b205-5bcc6e0fc245"));

            migrationBuilder.DeleteData(
                table: "ClassSubjects",
                keyColumn: "ClassSubjectId",
                keyValue: new Guid("3bf73a9c-f58c-4600-b043-bca5df6a352f"));

            migrationBuilder.DeleteData(
                table: "ClassSubjects",
                keyColumn: "ClassSubjectId",
                keyValue: new Guid("ccc68657-6489-4b5a-9419-6af4fd349c30"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a0776d82-0383-42fc-beae-638db701d0ee"));

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "Registers",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Registers");

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "CPF", "CreatedAt", "Email", "Name", "Password", "UpdatedAt" },
                values: new object[] { new Guid("29e10d80-4701-49cb-b205-5bcc6e0fc245"), "12345678", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "eduarbaldin@gmail.com", "Admin Eduardo", "123456", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ClassSubjects",
                columns: new[] { "ClassSubjectId", "CreatedAt", "ManagerId", "Name", "TeacherId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3bf73a9c-f58c-4600-b043-bca5df6a352f"), new DateTime(2024, 6, 23, 21, 45, 7, 808, DateTimeKind.Utc).AddTicks(8225), new Guid("97f31c66-6114-487a-a364-fcd2659c01a1"), "PowerBI", new Guid("d0c7bf7b-efc0-4c63-9c9b-1bfa0e1dd207"), new DateTime(2024, 6, 23, 21, 45, 7, 808, DateTimeKind.Utc).AddTicks(8226) },
                    { new Guid("ccc68657-6489-4b5a-9419-6af4fd349c30"), new DateTime(2024, 6, 23, 21, 45, 7, 808, DateTimeKind.Utc).AddTicks(8221), new Guid("97f31c66-6114-487a-a364-fcd2659c01a1"), "PowerBI", new Guid("ee6393f2-abfe-47e6-8186-bc08bc4a4cd0"), new DateTime(2024, 6, 23, 21, 45, 7, 808, DateTimeKind.Utc).AddTicks(8222) }
                });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: new Guid("61794cec-ba4a-432c-af5e-f58fe07799ac"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 23, 21, 45, 7, 808, DateTimeKind.Utc).AddTicks(8198), new DateTime(2024, 6, 23, 21, 45, 7, 808, DateTimeKind.Utc).AddTicks(8198) });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: new Guid("97f31c66-6114-487a-a364-fcd2659c01a1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 23, 21, 45, 7, 808, DateTimeKind.Utc).AddTicks(8194), new DateTime(2024, 6, 23, 21, 45, 7, 808, DateTimeKind.Utc).AddTicks(8195) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: new Guid("d0c7bf7b-efc0-4c63-9c9b-1bfa0e1dd207"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 23, 21, 45, 7, 808, DateTimeKind.Utc).AddTicks(8169), new DateTime(2024, 6, 23, 21, 45, 7, 808, DateTimeKind.Utc).AddTicks(8170) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: new Guid("ee6393f2-abfe-47e6-8186-bc08bc4a4cd0"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 23, 21, 45, 7, 808, DateTimeKind.Utc).AddTicks(8166), new DateTime(2024, 6, 23, 21, 45, 7, 808, DateTimeKind.Utc).AddTicks(8166) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CPF", "CreatedAt", "Email", "Name", "Password", "Role", "Salt", "UpdatedAt" },
                values: new object[] { new Guid("a0776d82-0383-42fc-beae-638db701d0ee"), "12345678", new DateTime(2024, 6, 23, 21, 45, 7, 808, DateTimeKind.Utc).AddTicks(8129), "eduarbaldin@gmail.com", "Admin", "123456", 3, "y9wrDdai3E=n", new DateTime(2024, 6, 23, 21, 45, 7, 808, DateTimeKind.Utc).AddTicks(8132) });
        }
    }
}
