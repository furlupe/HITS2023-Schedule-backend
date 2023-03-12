using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Schedule.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Groups_GroupNumber",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Groups_GroupNumber",
                table: "Users",
                column: "GroupNumber",
                principalTable: "Groups",
                principalColumn: "Number",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Groups_GroupNumber",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Groups_GroupNumber",
                table: "Users",
                column: "GroupNumber",
                principalTable: "Groups",
                principalColumn: "Number");
        }
    }
}
