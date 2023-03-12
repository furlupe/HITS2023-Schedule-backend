using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Schedule.Migrations
{
    /// <inheritdoc />
    public partial class wtf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Subjects_TeacherId",
                table: "Subjects",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Teachers_TeacherId",
                table: "Subjects",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Teachers_TeacherId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_TeacherId",
                table: "Subjects");

            migrationBuilder.DeleteData(
                table: "RoleUser",
                keyColumns: new[] { "RolesId", "UsersId" },
                keyValues: new object[] { new Guid("fc2e29cc-b4c4-4d31-a589-2311b10d80b6"), new Guid("03b73341-2cfc-4d33-b0e7-7f131bfe21ec") });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3627bc72-b8c9-4b3f-a35b-1ffb09595562"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("38e4d6a9-78ee-45b4-8bce-3f5bbf69d4fa"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("557e5a64-e05b-4ae6-8888-ecac386c34e1"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ca68faba-65fd-4cf8-ac52-fd0bd33a4569"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("6646c9f5-541f-4f74-bca9-a29724da2abf"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("70d70b75-848f-48c3-ad30-5e79b5394319"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("7ca78f8a-cae5-4c86-9a18-9c137c1291cd"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("ff3fee59-1620-48df-af62-05495ff1d631"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("44b23b85-d977-4c21-971a-5a0c58fbb004"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("9211bba3-fd2a-4ea3-a5b7-c24c86fbc4a3"));

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: new Guid("4961f0f1-b94d-41ac-95f6-4fab2f04b924"));

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: new Guid("a4f6613d-562d-4792-bc4f-0a314f81144a"));

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: new Guid("da6e1024-7132-4df2-aadb-31179096381e"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fc2e29cc-b4c4-4d31-a589-2311b10d80b6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("03b73341-2cfc-4d33-b0e7-7f131bfe21ec"));

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Subjects");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cabinets",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Cabinets",
                columns: new[] { "Number", "Name" },
                values: new object[,]
                {
                    { 123, "Sussy spaceship" },
                    { 141, null },
                    { 211, "Chill cabinet" },
                    { 222, "Toilet" },
                    { 332, null },
                    { 333, "Computer class" },
                    { 443, null },
                    { 451, "Denis' basement" },
                    { 452, "Hell" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                column: "Number",
                values: new object[]
                {
                    271805,
                    271905,
                    272201,
                    972101,
                    972102,
                    972202
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { new Guid("168d21d3-42ac-4924-b829-81497b77ea23"), 4 },
                    { new Guid("6678a845-4823-4896-bb76-dada882fbd21"), 1 },
                    { new Guid("6b87bbf4-f3e7-42a9-b016-a0bc11bcdaae"), 3 },
                    { new Guid("b9eb356d-9cdb-4004-83a4-f2061955e47a"), 2 },
                    { new Guid("cb7dead0-e43f-408c-bddc-8ed060044b99"), 0 }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1515e5f9-3b3a-4470-a057-856ba4a2181f"), "English language" },
                    { new Guid("3e234026-f43a-4017-87d5-5aeddb9b7f90"), "Russian language" },
                    { new Guid("4eb6537d-0db0-45f2-9c0b-ba3c4f9e5c8e"), "Meth cooking" },
                    { new Guid("6e8ab95b-786a-4c5d-9663-820e7851eee3"), "Programming" },
                    { new Guid("75eae3a0-add7-4c6f-9278-07a384d6801e"), "Requirements development" },
                    { new Guid("98c6e09e-d266-4904-9ed7-c7539046e7f8"), "Albebra" },
                    { new Guid("b593359a-4b41-4a95-861d-9753288509c9"), "Linear bebra" },
                    { new Guid("f553e9ac-2d78-4910-9502-cdeb995a466b"), "Amogusing" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("11e08458-b324-42ba-ac9e-6a3d7e792aea"), "Name Name Teacher" },
                    { new Guid("14dec041-abce-46fd-819d-5e8f71bd6218"), "Walter White" },
                    { new Guid("26bc1786-96b1-4f1d-93ea-2f44afde694f"), "Ilia Volgin" },
                    { new Guid("34c601af-7bea-4f26-9b4b-c5e7958ab679"), "Neel Kiggers" },
                    { new Guid("550c1c87-9c58-4752-a0fa-c2f40ab21f2e"), "Amogus Ballser" },
                    { new Guid("75bf8531-907a-4ae6-b59f-719f61055eea"), "Nuck Figgers" },
                    { new Guid("7965958b-fd27-407d-86f4-9a474264cd61"), "Zenis Dmeev" },
                    { new Guid("cc4116f9-019c-40ab-88f1-ef341e86f19e"), "Kid named Finger" }
                });

            migrationBuilder.InsertData(
                table: "Timeslots",
                columns: new[] { "Id", "EndsAt", "StartsAt" },
                values: new object[,]
                {
                    { new Guid("30b28c59-ec63-4dad-bea9-d963f421bb35"), new TimeOnly(12, 10, 0), new TimeOnly(10, 35, 0) },
                    { new Guid("64e23715-462f-48b0-aa6d-667cdf9b8b89"), new TimeOnly(16, 20, 0), new TimeOnly(14, 45, 0) },
                    { new Guid("6ead857b-5293-47d0-834f-38a2f21be4ba"), new TimeOnly(10, 20, 0), new TimeOnly(8, 45, 0) },
                    { new Guid("7d50fa21-2507-442a-b53c-65723b35e67b"), new TimeOnly(21, 50, 0), new TimeOnly(20, 15, 0) },
                    { new Guid("7e6f744c-7e55-41c7-8677-cd9867f8d426"), new TimeOnly(18, 10, 0), new TimeOnly(16, 35, 0) },
                    { new Guid("a0b44c5c-831d-4416-8f83-2e22e7bfa242"), new TimeOnly(14, 0, 0), new TimeOnly(12, 25, 0) },
                    { new Guid("d2cf45a9-de48-4ce0-ad93-296eccbb6761"), new TimeOnly(20, 0, 0), new TimeOnly(18, 25, 0) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "GroupNumber", "Login", "Password", "TeacherProfileId" },
                values: new object[] { new Guid("9d3f5535-220d-40b2-83bd-6b69b9cf4de8"), null, null, "furlupe", "3414A9BE42AE5049DD6DBEE1E2C70A986C2E5C20B6E7BF3DDA103678FDDAA7DB", null });

            migrationBuilder.InsertData(
                table: "RoleUser",
                columns: new[] { "RolesId", "UsersId" },
                values: new object[] { new Guid("168d21d3-42ac-4924-b829-81497b77ea23"), new Guid("9d3f5535-220d-40b2-83bd-6b69b9cf4de8") });
        }
    }
}
