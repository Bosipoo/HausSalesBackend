using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HausSalesBackend.Migrations
{
    /// <inheritdoc />
    public partial class userAvi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "CreatedDate",
                value: new DateTime(2024, 6, 25, 14, 10, 6, 95, DateTimeKind.Utc).AddTicks(3162));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "CreatedDate",
                value: new DateTime(2024, 6, 19, 16, 19, 5, 947, DateTimeKind.Utc).AddTicks(4064));
        }
    }
}
