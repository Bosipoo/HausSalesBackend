using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HausSalesBackend.Migrations
{
    /// <inheritdoc />
    public partial class glUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "GeneralLedgers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "CreatedDate",
                value: new DateTime(2024, 7, 6, 7, 48, 56, 49, DateTimeKind.Utc).AddTicks(1256));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "GeneralLedgers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "CreatedDate",
                value: new DateTime(2024, 7, 5, 17, 6, 22, 637, DateTimeKind.Utc).AddTicks(9914));
        }
    }
}
