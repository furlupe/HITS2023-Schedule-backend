using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Schedule.Migrations
{
    /// <inheritdoc />
    public partial class addLessonScheduled : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleUser",
                keyColumns: new[] { "RolesId", "UsersId" },
                keyValues: new object[] { new Guid("f9a93e33-a471-41af-b02d-10b17d50022b"), new Guid("1977e097-8eac-4cef-9099-ed1a3b6f9112") });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2b820302-a95a-4631-b6c7-7b056fc9eb68"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2ffb27a0-5ca7-4381-8fe1-d53c54b6e0d2"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("cde52baf-fa25-47e8-8787-64d5f1a520b2"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ed64f894-d908-4c02-b17c-37fd4f403058"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f9a93e33-a471-41af-b02d-10b17d50022b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1977e097-8eac-4cef-9099-ed1a3b6f9112"));

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Lessons",
                newName: "DateUntil");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFrom",
                table: "Lessons",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Day",
                table: "Lessons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Lessons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ScheduledLessons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LessonId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledLessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduledLessons_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cabinets",
                columns: new[] { "Number", "Name" },
                values: new object[,]
                {
                    { 101, "Cabinet No. 101" },
                    { 102, "Cabinet No. 102" },
                    { 103, "Cabinet No. 103" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledLessons_LessonId",
                table: "ScheduledLessons",
                column: "LessonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduledLessons");

            migrationBuilder.DeleteData(
                table: "Cabinets",
                keyColumn: "Number",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Cabinets",
                keyColumn: "Number",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Cabinets",
                keyColumn: "Number",
                keyValue: 103);

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

            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "Day",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Lessons");

            migrationBuilder.RenameColumn(
                name: "DateUntil",
                table: "Lessons",
                newName: "Date");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { new Guid("2b820302-a95a-4631-b6c7-7b056fc9eb68"), 0 },
                    { new Guid("2ffb27a0-5ca7-4381-8fe1-d53c54b6e0d2"), 2 },
                    { new Guid("cde52baf-fa25-47e8-8787-64d5f1a520b2"), 1 },
                    { new Guid("ed64f894-d908-4c02-b17c-37fd4f403058"), 3 },
                    { new Guid("f9a93e33-a471-41af-b02d-10b17d50022b"), 4 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "GroupNumber", "Login", "Password", "TeacherProfileId" },
                values: new object[] { new Guid("1977e097-8eac-4cef-9099-ed1a3b6f9112"), null, "furlupe", "3414A9BE42AE5049DD6DBEE1E2C70A986C2E5C20B6E7BF3DDA103678FDDAA7DB", null });

            migrationBuilder.InsertData(
                table: "RoleUser",
                columns: new[] { "RolesId", "UsersId" },
                values: new object[] { new Guid("f9a93e33-a471-41af-b02d-10b17d50022b"), new Guid("1977e097-8eac-4cef-9099-ed1a3b6f9112") });
        }
    }
}
