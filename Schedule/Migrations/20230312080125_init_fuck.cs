using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Schedule.Migrations
{
    /// <inheritdoc />
    public partial class init_fuck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blacklist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blacklist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cabinets",
                columns: table => new
                {
                    Number = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabinets", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Number = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Timeslots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartsAt = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    EndsAt = table.Column<TimeOnly>(type: "time without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timeslots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CabinetNumber = table.Column<int>(type: "integer", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Cabinets_CabinetNumber",
                        column: x => x.CabinetNumber,
                        principalTable: "Cabinets",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lessons_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lessons_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    TeacherProfileId = table.Column<Guid>(type: "uuid", nullable: true),
                    GroupNumber = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Groups_GroupNumber",
                        column: x => x.GroupNumber,
                        principalTable: "Groups",
                        principalColumn: "Number");
                    table.ForeignKey(
                        name: "FK_Users_Teachers_TeacherProfileId",
                        column: x => x.TeacherProfileId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GroupLesson",
                columns: table => new
                {
                    GroupsNumber = table.Column<int>(type: "integer", nullable: false),
                    LessonId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupLesson", x => new { x.GroupsNumber, x.LessonId });
                    table.ForeignKey(
                        name: "FK_GroupLesson_Groups_GroupsNumber",
                        column: x => x.GroupsNumber,
                        principalTable: "Groups",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupLesson_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduledLessons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BaseLessonId = table.Column<Guid>(type: "uuid", nullable: false),
                    TimeslotId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledLessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduledLessons_Lessons_BaseLessonId",
                        column: x => x.BaseLessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduledLessons_Timeslots_TimeslotId",
                        column: x => x.TimeslotId,
                        principalTable: "Timeslots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Value = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Expiry = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Value);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleUser",
                columns: table => new
                {
                    RolesId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RoleUser_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
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
                    { 103, "Cabinet No. 103" },
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
                    972103,
                    972202,
                    972203
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { new Guid("2830fb5c-241d-4bd7-96be-dec2bec312fe"), 0 },
                    { new Guid("285ff0ee-d361-4d7e-9991-3f04b032588c"), 3 },
                    { new Guid("756fe957-9dce-4768-a349-938f82c4ea67"), 2 },
                    { new Guid("d2aae306-326f-4af7-bd14-162846246640"), 4 },
                    { new Guid("df6ec725-46c4-40e9-ad99-d5ae97b5d3a5"), 1 }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("121f601a-6009-4342-a514-8958bf056d16"), "English language" },
                    { new Guid("223355ca-415f-4b2e-bbcb-114452242017"), "Albebra" },
                    { new Guid("3429d37d-d1e1-43a3-92d8-bef007806616"), "Amogusing" },
                    { new Guid("41e06c50-0ed9-4d8e-8ed0-6c56a5dadc83"), "Linear bebra" },
                    { new Guid("4951c037-dd1d-4734-a94b-152151a8d79e"), "Meth cooking" },
                    { new Guid("55014fbb-f50b-4091-b523-f447b6d4d827"), "Programming" },
                    { new Guid("c8e097f1-32b1-4988-8191-11239b673f88"), "Requirements development" },
                    { new Guid("f356a853-338b-4f69-a569-6347b55d7ab1"), "Russian language" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("57e46578-b64f-4029-9326-c6da20a25f43"), "Neel Kiggers" },
                    { new Guid("6efa209c-aaf1-48b6-b496-7b456a216289"), "Nuck Figgers" },
                    { new Guid("7e7785d7-28ad-47e0-9680-cbaca880ee62"), "Zenis Dmeev" },
                    { new Guid("abaee0d6-2c2c-487d-885a-993e46f3e34d"), "Ilia Volgin" },
                    { new Guid("baf4cf87-ba84-476c-a9e7-867c5e48fe86"), "Kid named Finger" },
                    { new Guid("bdb6ec61-2485-458a-a444-547b8f0c947d"), "Walter White" },
                    { new Guid("f7cb6c7c-5ccd-465f-8968-67beb850d37b"), "Name Name Teacher" },
                    { new Guid("fb7c8865-12c3-458d-9e28-8865cb0cde32"), "Amogus Ballser" }
                });

            migrationBuilder.InsertData(
                table: "Timeslots",
                columns: new[] { "Id", "EndsAt", "StartsAt" },
                values: new object[,]
                {
                    { new Guid("1f0c2b59-105a-47ce-a56a-843eb110cda1"), new TimeOnly(10, 20, 0), new TimeOnly(8, 45, 0) },
                    { new Guid("2ad17207-4073-495c-8704-e5aee81cb7bf"), new TimeOnly(16, 20, 0), new TimeOnly(14, 45, 0) },
                    { new Guid("735bac68-9006-484b-a6ea-6c1461270d12"), new TimeOnly(12, 10, 0), new TimeOnly(10, 35, 0) },
                    { new Guid("bdfcfd50-b12e-409c-81de-d009a59ee4c6"), new TimeOnly(18, 10, 0), new TimeOnly(16, 35, 0) },
                    { new Guid("c1442044-ae2c-49d3-ac89-c2e652a141a0"), new TimeOnly(20, 0, 0), new TimeOnly(18, 25, 0) },
                    { new Guid("d772c139-2501-4c29-972f-9ab402451225"), new TimeOnly(21, 50, 0), new TimeOnly(20, 15, 0) },
                    { new Guid("ec4704be-5499-4e9a-a320-704f621e24f6"), new TimeOnly(14, 0, 0), new TimeOnly(12, 25, 0) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "GroupNumber", "Login", "Password", "TeacherProfileId" },
                values: new object[] { new Guid("a4d6a415-a989-4198-bbe5-11593409b566"), null, "furlupe", "3414A9BE42AE5049DD6DBEE1E2C70A986C2E5C20B6E7BF3DDA103678FDDAA7DB", null });

            migrationBuilder.InsertData(
                table: "RoleUser",
                columns: new[] { "RolesId", "UsersId" },
                values: new object[] { new Guid("d2aae306-326f-4af7-bd14-162846246640"), new Guid("a4d6a415-a989-4198-bbe5-11593409b566") });

            migrationBuilder.CreateIndex(
                name: "IX_GroupLesson_LessonId",
                table: "GroupLesson",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_CabinetNumber",
                table: "Lessons",
                column: "CabinetNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_SubjectId",
                table: "Lessons",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_TeacherId",
                table: "Lessons",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UsersId",
                table: "RoleUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledLessons_BaseLessonId",
                table: "ScheduledLessons",
                column: "BaseLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledLessons_TimeslotId",
                table: "ScheduledLessons",
                column: "TimeslotId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupNumber",
                table: "Users",
                column: "GroupNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeacherProfileId",
                table: "Users",
                column: "TeacherProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blacklist");

            migrationBuilder.DropTable(
                name: "GroupLesson");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "RoleUser");

            migrationBuilder.DropTable(
                name: "ScheduledLessons");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Timeslots");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Cabinets");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
