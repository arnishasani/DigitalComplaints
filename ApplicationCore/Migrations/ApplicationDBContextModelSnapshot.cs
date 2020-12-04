﻿// <auto-generated />
using System;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApplicationCore.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApplicationCore.Entities.AspNetRoleClaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("ApplicationCore.Entities.AspNetRoles", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("([NormalizedName] IS NOT NULL)");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("ApplicationCore.Entities.AspNetUserClaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("ApplicationCore.Entities.AspNetUserLogins", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("ApplicationCore.Entities.AspNetUserRoles", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("ApplicationCore.Entities.AspNetUserTokens", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ApplicationCore.Entities.AspNetUsers", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreateByUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateOnDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool?>("Gender")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedByUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedOnDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("([NormalizedUserName] IS NOT NULL)");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ApplicationCore.Entities.TblDepartamentet", b =>
                {
                    b.Property<int>("DepartamentiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DepartamentiID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("VeprimetId")
                        .HasColumnName("VeprimetID")
                        .HasColumnType("int");

                    b.HasKey("DepartamentiId");

                    b.ToTable("tbl.Departamentet");
                });

            modelBuilder.Entity("ApplicationCore.Entities.TblKerkesatAnkesat", b =>
                {
                    b.Property<int?>("AnonimId")
                        .HasColumnName("AnonimID")
                        .HasColumnType("int");

                    b.Property<string>("Departamenti")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("InsertBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("InsertDate")
                        .HasColumnType("date");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsAnonim")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("KerkesaAnkesaId")
                        .HasColumnName("KerkesaAnkesaID")
                        .HasColumnType("int");

                    b.Property<int?>("Lub")
                        .HasColumnName("LUB")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Lud")
                        .HasColumnName("LUD")
                        .HasColumnType("date");

                    b.Property<int?>("Lun")
                        .HasColumnName("LUN")
                        .HasColumnType("int");

                    b.Property<string>("Nenshkrimi")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PershkrimiIkerkeses")
                        .HasColumnName("PershkrimiIKerkeses")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int?>("RoliId")
                        .HasColumnName("RoliID")
                        .HasColumnType("int");

                    b.ToTable("tbl.KerkesatAnkesat");
                });

            modelBuilder.Entity("ApplicationCore.Entities.TblLlojetDepartamenteve", b =>
                {
                    b.Property<int>("DepartamentiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmriDepartamentit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartamentiId");

                    b.ToTable("tbl.LlojetDepartamenteve");
                });

            modelBuilder.Entity("ApplicationCore.Entities.TblMenaxhimiKerkesave", b =>
                {
                    b.Property<int>("MenaxhimiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MenaxhimiID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("InsertBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("InsertDate")
                        .HasColumnType("date");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LlojiIkerkeses")
                        .HasColumnName("LlojiIKerkeses")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int?>("Lub")
                        .HasColumnName("LUB")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Lud")
                        .HasColumnName("LUD")
                        .HasColumnType("date");

                    b.Property<int?>("Lun")
                        .HasColumnName("LUN")
                        .HasColumnType("int");

                    b.HasKey("MenaxhimiId");

                    b.ToTable("tbl.MenaxhimiKerkesave");
                });

            modelBuilder.Entity("ApplicationCore.Entities.TblVeprimet", b =>
                {
                    b.Property<string>("Grupi")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("InsertBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("InsertDate")
                        .HasColumnType("date");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("KerkesaId")
                        .HasColumnName("KerkesaID")
                        .HasColumnType("int");

                    b.Property<string>("LendetEmbetura")
                        .HasColumnName("LendetEMbetura")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("LendetEpranuara")
                        .HasColumnName("LendetEPranuara")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("LendetErefuzuara")
                        .HasColumnName("LendetERefuzuara")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("LlojiIkerkeses")
                        .HasColumnName("LlojiIKerkeses")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("Lub")
                        .HasColumnName("LUB")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Lud")
                        .HasColumnName("LUD")
                        .HasColumnType("date");

                    b.Property<int?>("Lun")
                        .HasColumnName("LUN")
                        .HasColumnType("int");

                    b.Property<int?>("MenaxhimiId")
                        .HasColumnName("MenaxhimiID")
                        .HasColumnType("int");

                    b.Property<bool?>("Miratimi")
                        .HasColumnType("bit");

                    b.Property<string>("ObligimetEmbetura")
                        .HasColumnName("ObligimetEMbetura")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Orari")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PagesatEperfunduara")
                        .HasColumnName("PagesatEPerfunduara")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<bool?>("Pranimi")
                        .HasColumnType("bit");

                    b.Property<string>("RefuzimiTotalPerLende")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool?>("Vendimi")
                        .HasColumnType("bit");

                    b.Property<int>("VeprimiId")
                        .HasColumnName("VeprimiID")
                        .HasColumnType("int");

                    b.Property<bool?>("Verifikimi")
                        .HasColumnType("bit");

                    b.Property<string>("VitiAkademik")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.ToTable("tbl.Veprimet");
                });

            modelBuilder.Entity("ApplicationCore.Entities.AspNetRoleClaims", b =>
                {
                    b.HasOne("ApplicationCore.Entities.AspNetRoles", "Role")
                        .WithMany("AspNetRoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApplicationCore.Entities.AspNetUserClaims", b =>
                {
                    b.HasOne("ApplicationCore.Entities.AspNetUsers", "User")
                        .WithMany("AspNetUserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApplicationCore.Entities.AspNetUserLogins", b =>
                {
                    b.HasOne("ApplicationCore.Entities.AspNetUsers", "User")
                        .WithMany("AspNetUserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApplicationCore.Entities.AspNetUserRoles", b =>
                {
                    b.HasOne("ApplicationCore.Entities.AspNetRoles", "Role")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationCore.Entities.AspNetUsers", "User")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApplicationCore.Entities.AspNetUserTokens", b =>
                {
                    b.HasOne("ApplicationCore.Entities.AspNetUsers", "User")
                        .WithMany("AspNetUserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
