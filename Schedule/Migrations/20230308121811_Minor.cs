using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Schedule.Migrations
{
    /// <inheritdoc />
    public partial class Minor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleUser",
                keyColumns: new[] { "RolesId", "UsersId" },
                keyValues: new object[] { new Guid("edb3e326-822a-4235-9e50-20ca33eddcaf"), new Guid("a5844d3c-5e45-41dc-b2a3-7c3fea0b129b") });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1ca1b708-4bd7-4b07-8f2c-4998cd4310b9"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3c432470-7266-4bbc-a10a-961b6d132b48"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("69f3fc9e-30cf-4e46-9b2e-bee6b8f694d9"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a606bcb9-ef5d-4fb9-9ab2-11245b0b4489"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("7962e889-11ef-470f-8dbe-9b44db038872"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("7ec55c59-4f23-454f-b097-1c1f75946b0d"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("7ffb507b-2654-472f-9bfb-5e16835c7248"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("9a8453e9-856c-43ad-aea8-864cd23794dd"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("1051c382-e266-438a-be89-00545f9f62ad"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("f38883bf-5318-40dd-9285-ba6eec92bf92"));

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: new Guid("009e4697-aed8-4a81-9d09-76e301fddd0f"));

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: new Guid("63b22dba-2c5f-4ef6-b17b-40996d88fb47"));

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: new Guid("c0faa090-ecd8-42e8-8754-586f36b47942"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("edb3e326-822a-4235-9e50-20ca33eddcaf"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a5844d3c-5e45-41dc-b2a3-7c3fea0b129b"));

            migrationBuilder.AddColumn<Guid>(
                name: "TimeslotId",
                table: "ScheduledLessons",
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
                name: "IX_ScheduledLessons_TimeslotId",
                table: "ScheduledLessons",
                column: "TimeslotId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledLessons_Timeslots_TimeslotId",
                table: "ScheduledLessons",
                column: "TimeslotId",
                principalTable: "Timeslots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledLessons_Timeslots_TimeslotId",
                table: "ScheduledLessons");

            migrationBuilder.DropIndex(
                name: "IX_ScheduledLessons_TimeslotId",
                table: "ScheduledLessons");

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
                name: "TimeslotId",
                table: "ScheduledLessons");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { new Guid("1ca1b708-4bd7-4b07-8f2c-4998cd4310b9"), 2 },
                    { new Guid("3c432470-7266-4bbc-a10a-961b6d132b48"), 1 },
                    { new Guid("69f3fc9e-30cf-4e46-9b2e-bee6b8f694d9"), 3 },
                    { new Guid("a606bcb9-ef5d-4fb9-9ab2-11245b0b4489"), 0 },
                    { new Guid("edb3e326-822a-4235-9e50-20ca33eddcaf"), 4 }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[,]
                {
                    { new Guid("7962e889-11ef-470f-8dbe-9b44db038872"), "English language", null },
                    { new Guid("7ec55c59-4f23-454f-b097-1c1f75946b0d"), "Albebra", null },
                    { new Guid("7ffb507b-2654-472f-9bfb-5e16835c7248"), "Programming", null },
                    { new Guid("9a8453e9-856c-43ad-aea8-864cd23794dd"), "Amogusing", null }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1051c382-e266-438a-be89-00545f9f62ad"), "Amogus Ballser" },
                    { new Guid("f38883bf-5318-40dd-9285-ba6eec92bf92"), "Name Name Teacher" }
                });

            migrationBuilder.InsertData(
                table: "Timeslots",
                columns: new[] { "Id", "EndsAt", "StartsAt" },
                values: new object[,]
                {
                    { new Guid("009e4697-aed8-4a81-9d09-76e301fddd0f"), new TimeOnly(14, 0, 0), new TimeOnly(12, 25, 0) },
                    { new Guid("63b22dba-2c5f-4ef6-b17b-40996d88fb47"), new TimeOnly(12, 10, 0), new TimeOnly(10, 35, 0) },
                    { new Guid("c0faa090-ecd8-42e8-8754-586f36b47942"), new TimeOnly(10, 20, 0), new TimeOnly(8, 45, 0) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "GroupNumber", "Login", "Password", "TeacherProfileId" },
                values: new object[] { new Guid("a5844d3c-5e45-41dc-b2a3-7c3fea0b129b"), null, "furlupe", "3414A9BE42AE5049DD6DBEE1E2C70A986C2E5C20B6E7BF3DDA103678FDDAA7DB", null });

            migrationBuilder.InsertData(
                table: "RoleUser",
                columns: new[] { "RolesId", "UsersId" },
                values: new object[] { new Guid("edb3e326-822a-4235-9e50-20ca33eddcaf"), new Guid("a5844d3c-5e45-41dc-b2a3-7c3fea0b129b") });
        }
    }
}
