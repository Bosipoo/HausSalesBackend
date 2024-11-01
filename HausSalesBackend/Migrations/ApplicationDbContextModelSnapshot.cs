﻿// <auto-generated />
using System;
using HausSalesBackend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HausSalesBackend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HausSalesBackend.Models.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            CreatedDate = new DateTime(2024, 7, 21, 21, 40, 57, 150, DateTimeKind.Utc).AddTicks(9264),
                            Description = "Administrator role",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("HausSalesBackend.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("HausSalesBackend.Models.GeneralLedger", b =>
                {
                    b.Property<Guid>("glId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("accountNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("glAccDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("glAccName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("glGroupId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("glTypeId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("status")
                        .HasColumnType("boolean");

                    b.Property<string>("tempAccName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("glId");

                    b.ToTable("GeneralLedgers");
                });

            modelBuilder.Entity("HausSalesBackend.Models.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("ConstructionStageDisc")
                        .HasColumnType("numeric");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Moniker")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("NoDiscount")
                        .HasColumnType("numeric");

                    b.Property<int>("NoOfFractions")
                        .HasColumnType("integer");

                    b.Property<decimal>("OffPlanBulletDisc")
                        .HasColumnType("numeric");

                    b.Property<decimal>("OffPlanTrancheDisc")
                        .HasColumnType("numeric");

                    b.Property<decimal>("PricePerFraction")
                        .HasColumnType("numeric");

                    b.Property<string>("ProjectCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PropertyTypeId")
                        .HasColumnType("integer");

                    b.Property<Guid>("SSID")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PropertyTypeId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("HausSalesBackend.Models.PropertyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NoOfFractionsPerUnit")
                        .HasColumnType("integer");

                    b.Property<int>("NoOfUnits")
                        .HasColumnType("integer");

                    b.Property<string>("TypeDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PropertyTypes");
                });

            modelBuilder.Entity("HausSalesBackend.Models.Prospect", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AreasOfInterest")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ClientStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CompanyAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EmploymentStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastCodeGenerated")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MaritalStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NextOfKinAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NextOfKinName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NextOfKinPhone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NextOfKinRelationship")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OtherNames")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PlaceOfWork")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RefererCompany")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RefererIdentity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RegCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StateOfOrigin")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Prospects");
                });

            modelBuilder.Entity("HausSalesBackend.Models.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("AmtPaid")
                        .HasColumnType("numeric");

                    b.Property<int>("AvailFractions")
                        .HasColumnType("integer");

                    b.Property<string>("DiscountType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("FractionPrice")
                        .HasColumnType("numeric");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("OutstandingBal")
                        .HasColumnType("numeric");

                    b.Property<decimal>("PriceComp")
                        .HasColumnType("numeric");

                    b.Property<string>("Project")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProspectId")
                        .HasColumnType("integer");

                    b.Property<int>("PurchaseQty")
                        .HasColumnType("integer");

                    b.Property<string>("SalesId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SalesRefNo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProspectId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("HausSalesBackend.Models.SalesRepresentative", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateOfRecruitment")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LhaAccountNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LhaBankName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LhaName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LhaUplink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NokAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NokName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NokPhone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NokRelationship")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OtherNames")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("PPhoto")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Phone1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone2")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RidAffiliateCompany")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RidBeneficiaryDetails")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RidName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SalesRepresentatives");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("HausSalesBackend.Models.Property", b =>
                {
                    b.HasOne("HausSalesBackend.Models.PropertyType", "PropertyType")
                        .WithMany()
                        .HasForeignKey("PropertyTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("PropertyType");
                });

            modelBuilder.Entity("HausSalesBackend.Models.Sale", b =>
                {
                    b.HasOne("HausSalesBackend.Models.Prospect", "Prospect")
                        .WithMany("Sales")
                        .HasForeignKey("ProspectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prospect");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("HausSalesBackend.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HausSalesBackend.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HausSalesBackend.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("HausSalesBackend.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HausSalesBackend.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HausSalesBackend.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HausSalesBackend.Models.Prospect", b =>
                {
                    b.Navigation("Sales");
                });
#pragma warning restore 612, 618
        }
    }
}
