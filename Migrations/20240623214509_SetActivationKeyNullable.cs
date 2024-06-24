using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace class_management_web_api.Migrations
{
    /// <inheritdoc />
    public partial class SetActivationKeyNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("98011c21-3488-48d2-b76e-d5d36a3c6bb3"));

            migrationBuilder.DeleteData(
                table: "ClassSubjects",
                keyColumn: "ClassSubjectId",
                keyValue: new Guid("26188154-36fc-41a5-9263-3254fe8b29cc"));

            migrationBuilder.DeleteData(
                table: "ClassSubjects",
                keyColumn: "ClassSubjectId",
                keyValue: new Guid("fbd7278a-278e-437d-93b0-35875b332b9a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00121be3-d7ea-44c9-bf85-fad1d644f09e"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivationKey",
                table: "Registers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivationKey",
                table: "Registers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "CPF", "CreatedAt", "Email", "Name", "Password", "UpdatedAt" },
                values: new object[] { new Guid("98011c21-3488-48d2-b76e-d5d36a3c6bb3"), "12345678", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "eduarbaldin@gmail.com", "Admin Eduardo", "123456", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ClassSubjects",
                columns: new[] { "ClassSubjectId", "CreatedAt", "ManagerId", "Name", "TeacherId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("26188154-36fc-41a5-9263-3254fe8b29cc"), new DateTime(2024, 6, 7, 19, 30, 20, 103, DateTimeKind.Utc).AddTicks(4342), new Guid("97f31c66-6114-487a-a364-fcd2659c01a1"), "PowerBI", new Guid("ee6393f2-abfe-47e6-8186-bc08bc4a4cd0"), new DateTime(2024, 6, 7, 19, 30, 20, 103, DateTimeKind.Utc).AddTicks(4344) },
                    { new Guid("fbd7278a-278e-437d-93b0-35875b332b9a"), new DateTime(2024, 6, 7, 19, 30, 20, 103, DateTimeKind.Utc).AddTicks(4347), new Guid("97f31c66-6114-487a-a364-fcd2659c01a1"), "PowerBI", new Guid("d0c7bf7b-efc0-4c63-9c9b-1bfa0e1dd207"), new DateTime(2024, 6, 7, 19, 30, 20, 103, DateTimeKind.Utc).AddTicks(4348) }
                });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: new Guid("61794cec-ba4a-432c-af5e-f58fe07799ac"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 7, 19, 30, 20, 103, DateTimeKind.Utc).AddTicks(4321), new DateTime(2024, 6, 7, 19, 30, 20, 103, DateTimeKind.Utc).AddTicks(4322) });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: new Guid("97f31c66-6114-487a-a364-fcd2659c01a1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 7, 19, 30, 20, 103, DateTimeKind.Utc).AddTicks(4318), new DateTime(2024, 6, 7, 19, 30, 20, 103, DateTimeKind.Utc).AddTicks(4319) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: new Guid("d0c7bf7b-efc0-4c63-9c9b-1bfa0e1dd207"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 7, 19, 30, 20, 103, DateTimeKind.Utc).AddTicks(4292), new DateTime(2024, 6, 7, 19, 30, 20, 103, DateTimeKind.Utc).AddTicks(4293) });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: new Guid("ee6393f2-abfe-47e6-8186-bc08bc4a4cd0"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 7, 19, 30, 20, 103, DateTimeKind.Utc).AddTicks(4289), new DateTime(2024, 6, 7, 19, 30, 20, 103, DateTimeKind.Utc).AddTicks(4290) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CPF", "CreatedAt", "Email", "Name", "Password", "Role", "Salt", "UpdatedAt" },
                values: new object[] { new Guid("00121be3-d7ea-44c9-bf85-fad1d644f09e"), "12345678", new DateTime(2024, 6, 7, 19, 30, 20, 103, DateTimeKind.Utc).AddTicks(4243), "eduarbaldin@gmail.com", "Admin", "123456", 3, "y9wrDdai3E=n", new DateTime(2024, 6, 7, 19, 30, 20, 103, DateTimeKind.Utc).AddTicks(4247) });
        }
    }
}
