using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HausSalesBackend.Migrations
{
    /// <inheritdoc />
    public partial class properties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SSID = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    ProjectCode = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    OffPlanTrancheDisc = table.Column<decimal>(type: "numeric", nullable: false),
                    OffPlanBulletDisc = table.Column<decimal>(type: "numeric", nullable: false),
                    ConstructionStageDisc = table.Column<decimal>(type: "numeric", nullable: false),
                    NoDiscount = table.Column<decimal>(type: "numeric", nullable: false),
                    PricePerFraction = table.Column<decimal>(type: "numeric", nullable: false),
                    NoOfFractions = table.Column<int>(type: "integer", nullable: false),
                    Moniker = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    TypeName = table.Column<string>(type: "text", nullable: false),
                    TypeCode = table.Column<string>(type: "text", nullable: false),
                    NoOfUnits = table.Column<int>(type: "integer", nullable: false),
                    NoOfFractionsPerUnit = table.Column<int>(type: "integer", nullable: false),
                    TypeDescription = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
