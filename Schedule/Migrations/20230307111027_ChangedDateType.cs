using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Schedule.Migrations
{
    /// <inheritdoc />
    public partial class ChangedDateType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleUser",
                keyColumns: new[] { "RolesId", "UsersId" },
                keyValues: new object[] { new Guid("7e8d7c21-a3a7-4f72-8ee9-76454f26b1aa"), new Guid("dfa8d2fc-5391-45f5-b066-b89bdba4ee45") });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0faef7db-cbc9-41c2-b18e-3a35e3727c4e"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1833ad80-472a-4fcd-a79d-64f2b343ae12"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c44ab5bd-d888-4659-b93b-703e9cf43a1d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("cadd7bef-1d2d-47d3-8cee-154d410660e9"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("058ef1e1-4530-4de9-a48a-a93e57bf168c"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("4fdb81fd-c8ac-4b97-858a-11960dafcc8b"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("79af4be6-0ecc-4252-a699-6f6a7b81e7df"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("7cced983-dcda-4627-848e-3dd678b6646a"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("3066925f-cd00-418d-bbe4-6948c2cdaf6a"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("33d75289-4a7e-495b-9ae0-67e4dcb4e42b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7e8d7c21-a3a7-4f72-8ee9-76454f26b1aa"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dfa8d2fc-5391-45f5-b066-b89bdba4ee45"));

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "StartsAt",
                table: "Timeslots",
                type: "time without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "EndsAt",
                table: "Timeslots",
                type: "time without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Date",
                table: "ScheduledLessons",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateUntil",
                table: "Lessons",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateFrom",
                table: "Lessons",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartsAt",
                table: "Timeslots",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndsAt",
                table: "Timeslots",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "ScheduledLessons",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUntil",
                table: "Lessons",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateFrom",
                table: "Lessons",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { new Guid("0faef7db-cbc9-41c2-b18e-3a35e3727c4e"), 0 },
                    { new Guid("1833ad80-472a-4fcd-a79d-64f2b343ae12"), 3 },
                    { new Guid("7e8d7c21-a3a7-4f72-8ee9-76454f26b1aa"), 4 },
                    { new Guid("c44ab5bd-d888-4659-b93b-703e9cf43a1d"), 1 },
                    { new Guid("cadd7bef-1d2d-47d3-8cee-154d410660e9"), 2 }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[,]
                {
                    { new Guid("058ef1e1-4530-4de9-a48a-a93e57bf168c"), "Amogusing", null },
                    { new Guid("4fdb81fd-c8ac-4b97-858a-11960dafcc8b"), "Albebra", null },
                    { new Guid("79af4be6-0ecc-4252-a699-6f6a7b81e7df"), "English language", null },
                    { new Guid("7cced983-dcda-4627-848e-3dd678b6646a"), "Programming", null }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3066925f-cd00-418d-bbe4-6948c2cdaf6a"), "Name Name Teacher" },
                    { new Guid("33d75289-4a7e-495b-9ae0-67e4dcb4e42b"), "Amogus Ballser" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "GroupNumber", "Login", "Password", "TeacherProfileId" },
                values: new object[] { new Guid("dfa8d2fc-5391-45f5-b066-b89bdba4ee45"), null, "furlupe", "3414A9BE42AE5049DD6DBEE1E2C70A986C2E5C20B6E7BF3DDA103678FDDAA7DB", null });

            migrationBuilder.InsertData(
                table: "RoleUser",
                columns: new[] { "RolesId", "UsersId" },
                values: new object[] { new Guid("7e8d7c21-a3a7-4f72-8ee9-76454f26b1aa"), new Guid("dfa8d2fc-5391-45f5-b066-b89bdba4ee45") });
        }
    }
}
