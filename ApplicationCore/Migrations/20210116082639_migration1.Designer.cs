﻿// <auto-generated />
using System;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApplicationCore.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20210116082639_migration1")]
    partial class migration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("DepartamentiId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool?>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("IndexId")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

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

            modelBuilder.Entity("ApplicationCore.Entities.Kerkesat", b =>
                {
                    b.Property<int>("KerkesaAnkesaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("KerkesaAnkesaID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Ankes")
                        .HasColumnType("bit");

                    b.Property<int?>("AnonimId")
                        .HasColumnName("AnonimID")
                        .HasColumnType("int");

                    b.Property<int?>("DepartamentiId")
                        .HasColumnName("DepartamentiID")
                        .HasColumnType("int");

                    b.Property<string>("InsertBy")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<DateTime?>("InsertDate")
                        .HasColumnType("date");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsAnonim")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("LlojiKerkeses")
                        .HasColumnType("int");

                    b.Property<string>("Lub")
                        .HasColumnName("LUB")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<DateTime?>("Lud")
                        .HasColumnName("LUD")
                        .HasColumnType("datetime");

                    b.Property<string>("Lun")
                        .HasColumnName("LUN")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<string>("Nenshkrimi")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PershkrimiIkerkeses")
                        .HasColumnName("PershkrimiIKerkeses")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<bool?>("Pranuar")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("KerkesaAnkesaId");

                    b.HasIndex("DepartamentiId");

                    b.HasIndex("LlojiKerkeses");

                    b.HasIndex("UserId");

                    b.ToTable("Kerkesat");
                });

            modelBuilder.Entity("ApplicationCore.Entities.MenaxhimiKerkesaveRolet", b =>
                {
                    b.Property<int>("MenaxhimiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MenaxhimiID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LlojiKerkesesId")
                        .HasColumnName("LlojiKerkesesID")
                        .HasColumnType("int");

                    b.Property<string>("RoliId")
                        .IsRequired()
                        .HasColumnName("RoliID")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.HasKey("MenaxhimiId");

                    b.HasIndex("LlojiKerkesesId");

                    b.HasIndex("RoliId");

                    b.ToTable("MenaxhimiKerkesaveRolet");
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

                    b.HasIndex("DepartamentiId");

                    b.HasIndex("VeprimetId");

                    b.ToTable("tbl.Departamentet");
                });

            modelBuilder.Entity("ApplicationCore.Entities.TblLlojetDepartamenteve", b =>
                {
                    b.Property<int>("DepartamentiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DepartamentiID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmriDepartamentit")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<string>("InsertBy")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<DateTime?>("InsertDate")
                        .HasColumnType("date");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Lub")
                        .HasColumnName("LUB")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<DateTime?>("Lud")
                        .HasColumnName("LUD")
                        .HasColumnType("date");

                    b.Property<string>("Lun")
                        .HasColumnName("LUN")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

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

                    b.Property<string>("InsertBy")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

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

                    b.Property<string>("Lub")
                        .HasColumnName("LUB")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<DateTime?>("Lud")
                        .HasColumnName("LUD")
                        .HasColumnType("date");

                    b.Property<string>("Lun")
                        .HasColumnName("LUN")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<string>("PershkrimiKerkeses")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MenaxhimiId");

                    b.ToTable("tbl.MenaxhimiKerkesave");
                });

            modelBuilder.Entity("ApplicationCore.Entities.VendimiPerfundimtar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InsertBy")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<DateTime?>("InsertDate")
                        .HasColumnType("date");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Lub")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<DateTime?>("Lud")
                        .HasColumnType("date");

                    b.Property<string>("PershkrimiVendimit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StaffId")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<bool?>("Vendimi")
                        .HasColumnType("bit");

                    b.Property<int?>("VeprimiId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VeprimiId");

                    b.ToTable("VendimiPerfundimtar");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Veprimet", b =>
                {
                    b.Property<int>("VeprimiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("VeprimiID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("DepEkonomik")
                        .HasColumnType("bit");

                    b.Property<bool?>("DepShkenca")
                        .HasColumnType("bit");

                    b.Property<string>("Grupi")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("InsertBy")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<string>("InsertDate")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

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

                    b.Property<string>("Lub")
                        .HasColumnName("LUB")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<DateTime?>("Lud")
                        .HasColumnName("LUD")
                        .HasColumnType("date");

                    b.Property<string>("Lun")
                        .HasColumnName("LUN")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

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

                    b.Property<bool?>("Perfunduar")
                        .HasColumnType("bit");

                    b.Property<bool?>("Pranimi")
                        .HasColumnType("bit");

                    b.Property<string>("RefuzimiTotalPerLende")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool?>("Rektorati")
                        .HasColumnType("bit");

                    b.Property<bool?>("Sekretari")
                        .HasColumnType("bit");

                    b.Property<bool?>("SherbimeStudentore")
                        .HasColumnType("bit");

                    b.Property<string>("StafId")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<bool?>("Vendimi")
                        .HasColumnType("bit");

                    b.Property<bool?>("Verifikimi")
                        .HasColumnType("bit");

                    b.Property<string>("VitiAkademik")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool?>("ZyraCilesis")
                        .HasColumnType("bit");

                    b.Property<bool?>("ZyraFinancave")
                        .HasColumnType("bit");

                    b.Property<bool?>("ZyraIt")
                        .HasColumnType("bit");

                    b.HasKey("VeprimiId");

                    b.HasIndex("KerkesaId");

                    b.ToTable("Veprimet");
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

            modelBuilder.Entity("ApplicationCore.Entities.Kerkesat", b =>
                {
                    b.HasOne("ApplicationCore.Entities.TblLlojetDepartamenteve", "Departamenti")
                        .WithMany("Kerkesat")
                        .HasForeignKey("DepartamentiId")
                        .HasConstraintName("FK_Kerkesat_tbl.LlojetDepartamenteve");

                    b.HasOne("ApplicationCore.Entities.TblMenaxhimiKerkesave", "LlojiKerkesesNavigation")
                        .WithMany("Kerkesat")
                        .HasForeignKey("LlojiKerkeses")
                        .HasConstraintName("FK_Kerkesat_tbl.MenaxhimiKerkesave");

                    b.HasOne("ApplicationCore.Entities.AspNetUsers", "User")
                        .WithMany("Kerkesat")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Kerkesat_AspNetUsers");
                });

            modelBuilder.Entity("ApplicationCore.Entities.MenaxhimiKerkesaveRolet", b =>
                {
                    b.HasOne("ApplicationCore.Entities.TblMenaxhimiKerkesave", "LlojiKerkeses")
                        .WithMany("MenaxhimiKerkesaveRolet")
                        .HasForeignKey("LlojiKerkesesId")
                        .HasConstraintName("FK_MenaxhimiKerkesaveRolet_tbl.MenaxhimiKerkesave")
                        .IsRequired();

                    b.HasOne("ApplicationCore.Entities.AspNetRoles", "Roli")
                        .WithMany("MenaxhimiKerkesaveRolet")
                        .HasForeignKey("RoliId")
                        .HasConstraintName("FK_MenaxhimiKerkesaveRolet_AspNetRoles")
                        .IsRequired();
                });

            modelBuilder.Entity("ApplicationCore.Entities.TblDepartamentet", b =>
                {
                    b.HasOne("ApplicationCore.Entities.TblLlojetDepartamenteve", "Departamenti")
                        .WithMany()
                        .HasForeignKey("DepartamentiId")
                        .HasConstraintName("FK_tbl.Departamentet_tbl.LlojetDepartamenteve")
                        .IsRequired();

                    b.HasOne("ApplicationCore.Entities.Veprimet", "Veprimet")
                        .WithMany()
                        .HasForeignKey("VeprimetId")
                        .HasConstraintName("FK_tbl.Departamentet_Veprimet");
                });

            modelBuilder.Entity("ApplicationCore.Entities.VendimiPerfundimtar", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Veprimet", "Veprimi")
                        .WithMany("VendimiPerfundimtar")
                        .HasForeignKey("VeprimiId")
                        .HasConstraintName("FK_VendimiPerfundimtar_Veprimet");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Veprimet", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Kerkesat", "Kerkesa")
                        .WithMany("Veprimet")
                        .HasForeignKey("KerkesaId")
                        .HasConstraintName("FK_Veprimet_Kerkesat");
                });
#pragma warning restore 612, 618
        }
    }
}
