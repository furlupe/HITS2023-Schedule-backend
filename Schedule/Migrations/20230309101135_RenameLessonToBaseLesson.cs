using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Schedule.Migrations
{
    /// <inheritdoc />
    public partial class RenameLessonToBaseLesson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledLessons_Lessons_LessonId",
                table: "ScheduledLessons");

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

            migrationBuilder.RenameColumn(
                name: "LessonId",
                table: "ScheduledLessons",
                newName: "BaseLessonId");

            migrationBuilder.RenameIndex(
                name: "IX_ScheduledLessons_LessonId",
                table: "ScheduledLessons",
                newName: "IX_ScheduledLessons_BaseLessonId");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { new Guid("1f00a541-b9f1-441f-a1b3-bfdb408afcf0"), 0 },
                    { new Guid("7291d761-5f66-4e63-bfe8-dcf787428ad6"), 4 },
                    { new Guid("e48a219e-e730-4426-abd3-b5ba31e6dea5"), 2 },
                    { new Guid("e4bbd429-cab4-4741-914d-f868a0e51b96"), 1 },
                    { new Guid("f75fd0be-f94d-4966-9288-cbbf2efd9a36"), 3 }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[,]
                {
                    { new Guid("48f21452-ef29-4703-8906-7daebd7a9c3f"), "Programming", null },
                    { new Guid("a5a03a62-09db-4e29-b3d8-b5a4db4ed34d"), "Albebra", null },
                    { new Guid("afefed60-dad4-4b7b-8003-17960eeada5d"), "Amogusing", null },
                    { new Guid("c9a6e332-46ae-41a0-bf5e-e1ff058f11e9"), "English language", null }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0c691990-d467-4984-b1c6-34ad6025b640"), "Name Name Teacher" },
                    { new Guid("31734aa4-00aa-42f0-8b60-93eab68c4b7d"), "Amogus Ballser" }
                });

            migrationBuilder.InsertData(
                table: "Timeslots",
                columns: new[] { "Id", "EndsAt", "StartsAt" },
                values: new object[,]
                {
                    { new Guid("0260f3c9-a031-4cf5-9fae-4c097655f375"), new TimeOnly(10, 20, 0), new TimeOnly(8, 45, 0) },
                    { new Guid("9c2c48ef-6fb9-468b-91cb-654566540bf4"), new TimeOnly(12, 10, 0), new TimeOnly(10, 35, 0) },
                    { new Guid("ffde25f3-98e7-4856-aa50-4497af87f52d"), new TimeOnly(14, 0, 0), new TimeOnly(12, 25, 0) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "GroupNumber", "Login", "Password", "TeacherProfileId" },
                values: new object[] { new Guid("a2b5e5e7-1991-43ef-96a0-f21f327749d9"), null, "furlupe", "3414A9BE42AE5049DD6DBEE1E2C70A986C2E5C20B6E7BF3DDA103678FDDAA7DB", null });

            migrationBuilder.InsertData(
                table: "RoleUser",
                columns: new[] { "RolesId", "UsersId" },
                values: new object[] { new Guid("7291d761-5f66-4e63-bfe8-dcf787428ad6"), new Guid("a2b5e5e7-1991-43ef-96a0-f21f327749d9") });

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledLessons_Lessons_BaseLessonId",
                table: "ScheduledLessons",
                column: "BaseLessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledLessons_Lessons_BaseLessonId",
                table: "ScheduledLessons");

            migrationBuilder.DeleteData(
                table: "RoleUser",
                keyColumns: new[] { "RolesId", "UsersId" },
                keyValues: new object[] { new Guid("7291d761-5f66-4e63-bfe8-dcf787428ad6"), new Guid("a2b5e5e7-1991-43ef-96a0-f21f327749d9") });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1f00a541-b9f1-441f-a1b3-bfdb408afcf0"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e48a219e-e730-4426-abd3-b5ba31e6dea5"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e4bbd429-cab4-4741-914d-f868a0e51b96"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f75fd0be-f94d-4966-9288-cbbf2efd9a36"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("48f21452-ef29-4703-8906-7daebd7a9c3f"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("a5a03a62-09db-4e29-b3d8-b5a4db4ed34d"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("afefed60-dad4-4b7b-8003-17960eeada5d"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("c9a6e332-46ae-41a0-bf5e-e1ff058f11e9"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("0c691990-d467-4984-b1c6-34ad6025b640"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("31734aa4-00aa-42f0-8b60-93eab68c4b7d"));

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: new Guid("0260f3c9-a031-4cf5-9fae-4c097655f375"));

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: new Guid("9c2c48ef-6fb9-468b-91cb-654566540bf4"));

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: new Guid("ffde25f3-98e7-4856-aa50-4497af87f52d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7291d761-5f66-4e63-bfe8-dcf787428ad6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a2b5e5e7-1991-43ef-96a0-f21f327749d9"));

            migrationBuilder.RenameColumn(
                name: "BaseLessonId",
                table: "ScheduledLessons",
                newName: "LessonId");

            migrationBuilder.RenameIndex(
                name: "IX_ScheduledLessons_BaseLessonId",
                table: "ScheduledLessons",
                newName: "IX_ScheduledLessons_LessonId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledLessons_Lessons_LessonId",
                table: "ScheduledLessons",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
