using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Schedule.Migrations
{
    /// <inheritdoc />
    public partial class MoveTimeslotToSL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Timeslots_TimeslotId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_TimeslotId",
                table: "Lessons");

            migrationBuilder.DeleteData(
                table: "RoleUser",
                keyColumns: new[] { "RolesId", "UsersId" },
                keyValues: new object[] { new Guid("7f58a513-b0d3-47a8-bc06-57154045db1d"), new Guid("45c49b23-cfa8-4651-9c8e-cae140a75c15") });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("21fcd0f4-fabb-4531-bcc7-37a2afee0d83"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3a059f41-554e-4c4f-997b-92b5bb418ac2"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a89729b9-e13b-4964-8ace-e538bc073047"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f8f132ad-edb0-43d5-9629-95d63ec20090"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("493eff5f-764d-4e98-8ee1-c5e93bd8892c"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("698a5139-2222-4bcb-b9f2-9a4fc4d854c0"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("a4328591-51ab-4f62-9cf1-41c2356cdf01"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("ef9be43b-7f98-4710-8a24-3ca884196e82"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("08f7c0f1-7c61-45c5-8737-f63a1ce1edd2"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("6c530c89-27bd-4512-87f6-7bde4289443c"));

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: new Guid("542afc28-b50d-431b-bc1b-a4a196b6ed02"));

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: new Guid("d03a832d-03c4-4771-ba0b-eb7bb6273a57"));

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: new Guid("f4ac522a-433f-4ae1-bd22-bc3eb1d04854"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7f58a513-b0d3-47a8-bc06-57154045db1d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("45c49b23-cfa8-4651-9c8e-cae140a75c15"));

            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "DateUntil",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "Day",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "TimeslotId",
                table: "Lessons");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { new Guid("2269ecac-68e7-4cd1-9d81-f8ec9c6bcbe5"), 0 },
                    { new Guid("52741dc7-ac53-4cf7-b099-f9eca7008930"), 3 },
                    { new Guid("72d3f413-ec47-443b-8d58-e8409308ad8f"), 2 },
                    { new Guid("b2463ec2-a1b5-42ac-a4f7-1fc5cc35b8b9"), 1 },
                    { new Guid("c26bc57f-534d-47aa-bb44-efa09eaa7c98"), 4 }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[,]
                {
                    { new Guid("5e6552c3-d7a5-478a-ad76-684f6f648ea0"), "Albebra", null },
                    { new Guid("71264118-44f3-40d5-a382-84d1406f1c95"), "Programming", null },
                    { new Guid("e7946e57-3489-45af-9b33-9a715cbad2cc"), "Amogusing", null },
                    { new Guid("f60a1705-b620-4f11-aea5-e49b8cad9ad4"), "English language", null }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("41d2a1a0-3b7b-407d-ba6d-30f4d46898bf"), "Name Name Teacher" },
                    { new Guid("74ba0242-ce13-4b25-a6ae-4a3777a475ec"), "Amogus Ballser" }
                });

            migrationBuilder.InsertData(
                table: "Timeslots",
                columns: new[] { "Id", "EndsAt", "StartsAt" },
                values: new object[,]
                {
                    { new Guid("46e0c27b-d260-418c-a719-ddf7d2ad235d"), new TimeOnly(12, 10, 0), new TimeOnly(10, 35, 0) },
                    { new Guid("9161f3c5-3d0d-4aff-9258-5fb25b50e0a0"), new TimeOnly(10, 20, 0), new TimeOnly(8, 45, 0) },
                    { new Guid("a12393fa-f216-4a1e-8f27-a4b4c9cbe664"), new TimeOnly(14, 0, 0), new TimeOnly(12, 25, 0) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "GroupNumber", "Login", "Password", "TeacherProfileId" },
                values: new object[] { new Guid("145e9c0b-1230-48d3-a311-796ecb91c441"), null, "furlupe", "3414A9BE42AE5049DD6DBEE1E2C70A986C2E5C20B6E7BF3DDA103678FDDAA7DB", null });

            migrationBuilder.InsertData(
                table: "RoleUser",
                columns: new[] { "RolesId", "UsersId" },
                values: new object[] { new Guid("c26bc57f-534d-47aa-bb44-efa09eaa7c98"), new Guid("145e9c0b-1230-48d3-a311-796ecb91c441") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleUser",
                keyColumns: new[] { "RolesId", "UsersId" },
                keyValues: new object[] { new Guid("c26bc57f-534d-47aa-bb44-efa09eaa7c98"), new Guid("145e9c0b-1230-48d3-a311-796ecb91c441") });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2269ecac-68e7-4cd1-9d81-f8ec9c6bcbe5"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("52741dc7-ac53-4cf7-b099-f9eca7008930"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("72d3f413-ec47-443b-8d58-e8409308ad8f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b2463ec2-a1b5-42ac-a4f7-1fc5cc35b8b9"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("5e6552c3-d7a5-478a-ad76-684f6f648ea0"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("71264118-44f3-40d5-a382-84d1406f1c95"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("e7946e57-3489-45af-9b33-9a715cbad2cc"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("f60a1705-b620-4f11-aea5-e49b8cad9ad4"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("41d2a1a0-3b7b-407d-ba6d-30f4d46898bf"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("74ba0242-ce13-4b25-a6ae-4a3777a475ec"));

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: new Guid("46e0c27b-d260-418c-a719-ddf7d2ad235d"));

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: new Guid("9161f3c5-3d0d-4aff-9258-5fb25b50e0a0"));

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: new Guid("a12393fa-f216-4a1e-8f27-a4b4c9cbe664"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c26bc57f-534d-47aa-bb44-efa09eaa7c98"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("145e9c0b-1230-48d3-a311-796ecb91c441"));

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateFrom",
                table: "Lessons",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateUntil",
                table: "Lessons",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "Day",
                table: "Lessons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "TimeslotId",
                table: "Lessons",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { new Guid("21fcd0f4-fabb-4531-bcc7-37a2afee0d83"), 1 },
                    { new Guid("3a059f41-554e-4c4f-997b-92b5bb418ac2"), 3 },
                    { new Guid("7f58a513-b0d3-47a8-bc06-57154045db1d"), 4 },
                    { new Guid("a89729b9-e13b-4964-8ace-e538bc073047"), 0 },
                    { new Guid("f8f132ad-edb0-43d5-9629-95d63ec20090"), 2 }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[,]
                {
                    { new Guid("493eff5f-764d-4e98-8ee1-c5e93bd8892c"), "Amogusing", null },
                    { new Guid("698a5139-2222-4bcb-b9f2-9a4fc4d854c0"), "Programming", null },
                    { new Guid("a4328591-51ab-4f62-9cf1-41c2356cdf01"), "Albebra", null },
                    { new Guid("ef9be43b-7f98-4710-8a24-3ca884196e82"), "English language", null }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("08f7c0f1-7c61-45c5-8737-f63a1ce1edd2"), "Amogus Ballser" },
                    { new Guid("6c530c89-27bd-4512-87f6-7bde4289443c"), "Name Name Teacher" }
                });

            migrationBuilder.InsertData(
                table: "Timeslots",
                columns: new[] { "Id", "EndsAt", "StartsAt" },
                values: new object[,]
                {
                    { new Guid("542afc28-b50d-431b-bc1b-a4a196b6ed02"), new TimeOnly(10, 20, 0), new TimeOnly(8, 45, 0) },
                    { new Guid("d03a832d-03c4-4771-ba0b-eb7bb6273a57"), new TimeOnly(14, 0, 0), new TimeOnly(12, 25, 0) },
                    { new Guid("f4ac522a-433f-4ae1-bd22-bc3eb1d04854"), new TimeOnly(12, 10, 0), new TimeOnly(10, 35, 0) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "GroupNumber", "Login", "Password", "TeacherProfileId" },
                values: new object[] { new Guid("45c49b23-cfa8-4651-9c8e-cae140a75c15"), null, "furlupe", "3414A9BE42AE5049DD6DBEE1E2C70A986C2E5C20B6E7BF3DDA103678FDDAA7DB", null });

            migrationBuilder.InsertData(
                table: "RoleUser",
                columns: new[] { "RolesId", "UsersId" },
                values: new object[] { new Guid("7f58a513-b0d3-47a8-bc06-57154045db1d"), new Guid("45c49b23-cfa8-4651-9c8e-cae140a75c15") });

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_TimeslotId",
                table: "Lessons",
                column: "TimeslotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Timeslots_TimeslotId",
                table: "Lessons",
                column: "TimeslotId",
                principalTable: "Timeslots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
