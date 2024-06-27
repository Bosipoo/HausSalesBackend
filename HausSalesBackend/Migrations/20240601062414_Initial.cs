using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HausSalesBackend.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeneralLedgers",
                columns: table => new
                {
                    glId = table.Column<Guid>(type: "uuid", nullable: false),
                    accountNumber = table.Column<string>(type: "text", nullable: false),
                    glGroupId = table.Column<string>(type: "text", nullable: false),
                    glTypeId = table.Column<string>(type: "text", nullable: false),
                    tempAccName = table.Column<string>(type: "text", nullable: false),
                    glAccDescription = table.Column<string>(type: "text", nullable: false),
                    glAccName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralLedgers", x => x.glId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneralLedgers");
        }
    }
}
