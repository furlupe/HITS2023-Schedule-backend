using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Schedule.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleUser",
                keyColumns: new[] { "RolesId", "UsersId" },
                keyValues: new object[] { new Guid("0c48542a-13f7-4387-af7f-c2ff4f74b89d"), new Guid("e955e37b-233c-4893-b2dc-c91a626a418f") });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4a1bf6b3-7a31-4dd4-be3a-113971ba4173"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("52582bda-a6ce-48eb-8703-196cfe5d0df5"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8217a6f9-b788-41c1-a368-d5b46b87d98a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d6bd1e12-5a8d-4a31-9809-be2870aff8ea"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0c48542a-13f7-4387-af7f-c2ff4f74b89d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e955e37b-233c-4893-b2dc-c91a626a418f"));

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

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { new Guid("0c48542a-13f7-4387-af7f-c2ff4f74b89d"), 4 },
                    { new Guid("4a1bf6b3-7a31-4dd4-be3a-113971ba4173"), 1 },
                    { new Guid("52582bda-a6ce-48eb-8703-196cfe5d0df5"), 3 },
                    { new Guid("8217a6f9-b788-41c1-a368-d5b46b87d98a"), 2 },
                    { new Guid("d6bd1e12-5a8d-4a31-9809-be2870aff8ea"), 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "GroupNumber", "Login", "Password", "TeacherProfileId" },
                values: new object[] { new Guid("e955e37b-233c-4893-b2dc-c91a626a418f"), null, "furlupe", "3414A9BE42AE5049DD6DBEE1E2C70A986C2E5C20B6E7BF3DDA103678FDDAA7DB", null });

            migrationBuilder.InsertData(
                table: "RoleUser",
                columns: new[] { "RolesId", "UsersId" },
                values: new object[] { new Guid("0c48542a-13f7-4387-af7f-c2ff4f74b89d"), new Guid("e955e37b-233c-4893-b2dc-c91a626a418f") });
        }
    }
}
