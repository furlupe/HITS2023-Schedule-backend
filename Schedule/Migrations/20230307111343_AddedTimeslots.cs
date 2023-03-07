using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Schedule.Migrations
{
    /// <inheritdoc />
    public partial class AddedTimeslots : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleUser",
                keyColumns: new[] { "RolesId", "UsersId" },
                keyValues: new object[] { new Guid("914867e9-db1a-4423-b477-8d50c7b0f935"), new Guid("19108dbb-6b9c-41a7-a44f-493f9cc40250") });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("79aec46f-784b-46a1-b2f6-36a488643476"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d0a77a2a-2653-4fba-9181-8e5f8181147d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d90d5c82-da4a-4cca-85b6-84c57c54c2ee"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f3346948-f7f1-46dd-8211-3e36221ef236"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("29547970-f9c3-419b-804e-c6080816cbe1"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("693bf5ab-830c-40a0-9069-cb43cca4cb91"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("9dc14821-55d7-441b-8e2c-4035a2eb4686"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("da6c8174-7392-4371-9a72-4539c1a17a9b"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("37ccbbc8-4794-4035-a998-722374e97b35"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("c7e3660b-f8b5-43e6-a691-7e98c01548ad"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("914867e9-db1a-4423-b477-8d50c7b0f935"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19108dbb-6b9c-41a7-a44f-493f9cc40250"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { new Guid("79aec46f-784b-46a1-b2f6-36a488643476"), 3 },
                    { new Guid("914867e9-db1a-4423-b477-8d50c7b0f935"), 4 },
                    { new Guid("d0a77a2a-2653-4fba-9181-8e5f8181147d"), 2 },
                    { new Guid("d90d5c82-da4a-4cca-85b6-84c57c54c2ee"), 1 },
                    { new Guid("f3346948-f7f1-46dd-8211-3e36221ef236"), 0 }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[,]
                {
                    { new Guid("29547970-f9c3-419b-804e-c6080816cbe1"), "Amogusing", null },
                    { new Guid("693bf5ab-830c-40a0-9069-cb43cca4cb91"), "English language", null },
                    { new Guid("9dc14821-55d7-441b-8e2c-4035a2eb4686"), "Albebra", null },
                    { new Guid("da6c8174-7392-4371-9a72-4539c1a17a9b"), "Programming", null }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("37ccbbc8-4794-4035-a998-722374e97b35"), "Amogus Ballser" },
                    { new Guid("c7e3660b-f8b5-43e6-a691-7e98c01548ad"), "Name Name Teacher" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "GroupNumber", "Login", "Password", "TeacherProfileId" },
                values: new object[] { new Guid("19108dbb-6b9c-41a7-a44f-493f9cc40250"), null, "furlupe", "3414A9BE42AE5049DD6DBEE1E2C70A986C2E5C20B6E7BF3DDA103678FDDAA7DB", null });

            migrationBuilder.InsertData(
                table: "RoleUser",
                columns: new[] { "RolesId", "UsersId" },
                values: new object[] { new Guid("914867e9-db1a-4423-b477-8d50c7b0f935"), new Guid("19108dbb-6b9c-41a7-a44f-493f9cc40250") });
        }
    }
}
