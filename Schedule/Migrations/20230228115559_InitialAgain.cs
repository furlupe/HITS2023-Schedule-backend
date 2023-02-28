using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Schedule.Migrations
{
    /// <inheritdoc />
    public partial class InitialAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("44197e43-4a9b-4e2a-a5c3-3c1775881099"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("475c6e59-95f9-4536-ae57-89a9fd14538c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9a452db5-3f6e-4a05-a8ae-2dbd265d7c19"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c0c3754f-be95-4ac8-9d62-90136753769f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d08fe43a-6efb-4948-8893-1930f59b3346"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("001caa83-b15a-44dd-9e74-bc54550957ff"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { new Guid("065a2929-e8b6-41c1-a83b-8249b54160c5"), 4 },
                    { new Guid("74833abe-99c9-48be-98ec-2679aee278bd"), 3 },
                    { new Guid("7737596e-eb3d-43da-b208-50bf6c747b54"), 2 },
                    { new Guid("cbc8d2b5-87ce-4b58-b984-f3d1a29d0f44"), 0 },
                    { new Guid("d8bc384e-7d88-4ecd-a6d6-82da257809fd"), 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("065a2929-e8b6-41c1-a83b-8249b54160c5"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("74833abe-99c9-48be-98ec-2679aee278bd"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7737596e-eb3d-43da-b208-50bf6c747b54"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("cbc8d2b5-87ce-4b58-b984-f3d1a29d0f44"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d8bc384e-7d88-4ecd-a6d6-82da257809fd"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { new Guid("44197e43-4a9b-4e2a-a5c3-3c1775881099"), 0 },
                    { new Guid("475c6e59-95f9-4536-ae57-89a9fd14538c"), 1 },
                    { new Guid("9a452db5-3f6e-4a05-a8ae-2dbd265d7c19"), 2 },
                    { new Guid("c0c3754f-be95-4ac8-9d62-90136753769f"), 4 },
                    { new Guid("d08fe43a-6efb-4948-8893-1930f59b3346"), 3 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "GroupNumber", "Login", "Password", "TeacherProfileId" },
                values: new object[] { new Guid("001caa83-b15a-44dd-9e74-bc54550957ff"), null, "furlupe", "3414A9BE42AE5049DD6DBEE1E2C70A986C2E5C20B6E7BF3DDA103678FDDAA7DB", null });
        }
    }
}
