using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HausSalesBackend.Migrations
{
    /// <inheritdoc />
    public partial class Models : Migration
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
                    SSID = table.Column<int>(type: "integer", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Prospects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    OtherNames = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    StateOfOrigin = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    MaritalStatus = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    EmploymentStatus = table.Column<string>(type: "text", nullable: false),
                    PlaceOfWork = table.Column<string>(type: "text", nullable: false),
                    CompanyAddress = table.Column<string>(type: "text", nullable: false),
                    NextOfKinName = table.Column<string>(type: "text", nullable: false),
                    NextOfKinAddress = table.Column<string>(type: "text", nullable: false),
                    NextOfKinPhone = table.Column<string>(type: "text", nullable: false),
                    NextOfKinRelationship = table.Column<string>(type: "text", nullable: false),
                    AreasOfInterest = table.Column<string>(type: "text", nullable: false),
                    RefererCompany = table.Column<string>(type: "text", nullable: false),
                    LastCodeGenerated = table.Column<string>(type: "text", nullable: false),
                    RefererIdentity = table.Column<string>(type: "text", nullable: false),
                    RegCode = table.Column<string>(type: "text", nullable: false),
                    ClientStatus = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prospects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesRepresentatives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    OtherNames = table.Column<string>(type: "text", nullable: false),
                    PPhoto = table.Column<byte[]>(type: "bytea", nullable: false),
                    Dob = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    Phone1 = table.Column<string>(type: "text", nullable: false),
                    Phone2 = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    DateOfRecruitment = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    NokName = table.Column<string>(type: "text", nullable: false),
                    NokAddress = table.Column<string>(type: "text", nullable: false),
                    NokPhone = table.Column<string>(type: "text", nullable: false),
                    NokRelationship = table.Column<string>(type: "text", nullable: false),
                    RidName = table.Column<string>(type: "text", nullable: false),
                    RidAffiliateCompany = table.Column<string>(type: "text", nullable: false),
                    RidBeneficiaryDetails = table.Column<string>(type: "text", nullable: false),
                    LhaName = table.Column<string>(type: "text", nullable: false),
                    LhaBankName = table.Column<string>(type: "text", nullable: false),
                    LhaUplink = table.Column<string>(type: "text", nullable: false),
                    LhaAccountNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesRepresentatives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SalesId = table.Column<string>(type: "text", nullable: false),
                    SalesRefNo = table.Column<string>(type: "text", nullable: false),
                    ProspectId = table.Column<int>(type: "integer", nullable: false),
                    PurchaseQty = table.Column<int>(type: "integer", nullable: false),
                    Project = table.Column<string>(type: "text", nullable: false),
                    PriceComp = table.Column<decimal>(type: "numeric", nullable: false),
                    FractionPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    AvailFractions = table.Column<int>(type: "integer", nullable: false),
                    AmtPaid = table.Column<decimal>(type: "numeric", nullable: false),
                    DiscountType = table.Column<string>(type: "text", nullable: false),
                    OutstandingBal = table.Column<decimal>(type: "numeric", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Prospects_ProspectId",
                        column: x => x.ProspectId,
                        principalTable: "Prospects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ProspectId",
                table: "Sales",
                column: "ProspectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "SalesRepresentatives");

            migrationBuilder.DropTable(
                name: "Prospects");
        }
    }
}
