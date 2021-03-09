using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationCore.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateByUserId = table.Column<string>(nullable: true),
                    CreateOnDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Gender = table.Column<bool>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    LastModifiedByUserId = table.Column<string>(nullable: true),
                    LastModifiedOnDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    IndexId = table.Column<string>(maxLength: 450, nullable: true),
                    DepartamentiId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl.LlojetDepartamenteve",
                columns: table => new
                {
                    DepartamentiID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmriDepartamentit = table.Column<string>(maxLength: 450, nullable: true),
                    InsertBy = table.Column<string>(maxLength: 450, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    LUB = table.Column<string>(maxLength: 450, nullable: true),
                    LUD = table.Column<DateTime>(type: "datetime", nullable: true),
                    LUN = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl.LlojetDepartamenteve", x => x.DepartamentiID);
                });

            migrationBuilder.CreateTable(
                name: "tbl.MenaxhimiKerkesave",
                columns: table => new
                {
                    MenaxhimiID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LlojiIKerkeses = table.Column<string>(maxLength: 500, nullable: true),
                    PershkrimiKerkeses = table.Column<string>(nullable: true),
                    InsertBy = table.Column<string>(maxLength: 450, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LUB = table.Column<string>(maxLength: 450, nullable: true),
                    LUD = table.Column<DateTime>(type: "datetime", nullable: true),
                    LUN = table.Column<string>(maxLength: 450, nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl.MenaxhimiKerkesave", x => x.MenaxhimiID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kerkesat",
                columns: table => new
                {
                    KerkesaAnkesaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    LlojiKerkeses = table.Column<int>(nullable: true),
                    DepartamentiID = table.Column<int>(nullable: true),
                    Nenshkrimi = table.Column<string>(maxLength: 50, nullable: true),
                    PershkrimiIKerkeses = table.Column<string>(maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    IsAnonim = table.Column<bool>(nullable: true),
                    AnonimID = table.Column<int>(nullable: true),
                    InsertBy = table.Column<string>(maxLength: 450, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LUB = table.Column<string>(maxLength: 450, nullable: true),
                    LUD = table.Column<DateTime>(type: "datetime", nullable: true),
                    LUN = table.Column<string>(maxLength: 450, nullable: true),
                    Ankes = table.Column<bool>(nullable: true),
                    Pranuar = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kerkesat", x => x.KerkesaAnkesaID);
                    table.ForeignKey(
                        name: "FK_Kerkesat_tbl.LlojetDepartamenteve",
                        column: x => x.DepartamentiID,
                        principalTable: "tbl.LlojetDepartamenteve",
                        principalColumn: "DepartamentiID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kerkesat_tbl.MenaxhimiKerkesave",
                        column: x => x.LlojiKerkeses,
                        principalTable: "tbl.MenaxhimiKerkesave",
                        principalColumn: "MenaxhimiID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kerkesat_AspNetUsers",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MenaxhimiKerkesaveRolet",
                columns: table => new
                {
                    MenaxhimiID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LlojiKerkesesID = table.Column<int>(nullable: false),
                    RoliID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenaxhimiKerkesaveRolet", x => x.MenaxhimiID);
                    table.ForeignKey(
                        name: "FK_MenaxhimiKerkesaveRolet_tbl.MenaxhimiKerkesave",
                        column: x => x.LlojiKerkesesID,
                        principalTable: "tbl.MenaxhimiKerkesave",
                        principalColumn: "MenaxhimiID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenaxhimiKerkesaveRolet_AspNetRoles",
                        column: x => x.RoliID,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Veprimet",
                columns: table => new
                {
                    VeprimiID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KerkesaID = table.Column<int>(nullable: true),
                    StafId = table.Column<string>(maxLength: 450, nullable: true),
                    Pranimi = table.Column<bool>(nullable: true),
                    Grupi = table.Column<string>(maxLength: 50, nullable: true),
                    Orari = table.Column<string>(maxLength: 50, nullable: true),
                    LendetEMbetura = table.Column<string>(maxLength: 500, nullable: true),
                    LendetEPranuara = table.Column<string>(maxLength: 500, nullable: true),
                    VitiAkademik = table.Column<string>(maxLength: 50, nullable: true),
                    RefuzimiTotalPerLende = table.Column<string>(maxLength: 50, nullable: true),
                    ObligimetEMbetura = table.Column<string>(maxLength: 500, nullable: true),
                    LendetERefuzuara = table.Column<string>(maxLength: 500, nullable: true),
                    PagesatEPerfunduara = table.Column<string>(maxLength: 500, nullable: true),
                    InsertBy = table.Column<string>(maxLength: 450, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LUB = table.Column<string>(maxLength: 450, nullable: true),
                    LUD = table.Column<DateTime>(type: "datetime", nullable: true),
                    LUN = table.Column<string>(maxLength: 450, nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    Perfunduar = table.Column<bool>(nullable: true),
                    ZyraCilesis = table.Column<bool>(nullable: true),
                    ZyraIt = table.Column<bool>(nullable: true),
                    SherbimeStudentore = table.Column<bool>(nullable: true),
                    DepShkenca = table.Column<bool>(nullable: true),
                    DepEkonomik = table.Column<bool>(nullable: true),
                    ZyraFinancave = table.Column<bool>(nullable: true),
                    Rektorati = table.Column<bool>(nullable: true),
                    Sekretari = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veprimet", x => x.VeprimiID);
                    table.ForeignKey(
                        name: "FK_Veprimet_Kerkesat",
                        column: x => x.KerkesaID,
                        principalTable: "Kerkesat",
                        principalColumn: "KerkesaAnkesaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl.Departamentet",
                columns: table => new
                {
                    DepartamentiID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VeprimetID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_tbl.Departamentet_tbl.LlojetDepartamenteve",
                        column: x => x.DepartamentiID,
                        principalTable: "tbl.LlojetDepartamenteve",
                        principalColumn: "DepartamentiID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl.Departamentet_Veprimet",
                        column: x => x.VeprimetID,
                        principalTable: "Veprimet",
                        principalColumn: "VeprimiID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VendimiPerfundimtar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VeprimiId = table.Column<int>(nullable: true),
                    StaffId = table.Column<string>(maxLength: 450, nullable: true),
                    Vendimi = table.Column<bool>(nullable: true),
                    PershkrimiVendimit = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    InsertBy = table.Column<string>(maxLength: 450, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Lud = table.Column<DateTime>(type: "datetime", nullable: true),
                    Lub = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendimiPerfundimtar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendimiPerfundimtar_Veprimet",
                        column: x => x.VeprimiId,
                        principalTable: "Veprimet",
                        principalColumn: "VeprimiID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "([NormalizedName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "([NormalizedUserName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_Kerkesat_DepartamentiID",
                table: "Kerkesat",
                column: "DepartamentiID");

            migrationBuilder.CreateIndex(
                name: "IX_Kerkesat_LlojiKerkeses",
                table: "Kerkesat",
                column: "LlojiKerkeses");

            migrationBuilder.CreateIndex(
                name: "IX_Kerkesat_UserId",
                table: "Kerkesat",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MenaxhimiKerkesaveRolet_LlojiKerkesesID",
                table: "MenaxhimiKerkesaveRolet",
                column: "LlojiKerkesesID");

            migrationBuilder.CreateIndex(
                name: "IX_MenaxhimiKerkesaveRolet_RoliID",
                table: "MenaxhimiKerkesaveRolet",
                column: "RoliID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl.Departamentet_DepartamentiID",
                table: "tbl.Departamentet",
                column: "DepartamentiID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl.Departamentet_VeprimetID",
                table: "tbl.Departamentet",
                column: "VeprimetID");

            migrationBuilder.CreateIndex(
                name: "IX_VendimiPerfundimtar_VeprimiId",
                table: "VendimiPerfundimtar",
                column: "VeprimiId");

            migrationBuilder.CreateIndex(
                name: "IX_Veprimet_KerkesaID",
                table: "Veprimet",
                column: "KerkesaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "MenaxhimiKerkesaveRolet");

            migrationBuilder.DropTable(
                name: "tbl.Departamentet");

            migrationBuilder.DropTable(
                name: "VendimiPerfundimtar");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Veprimet");

            migrationBuilder.DropTable(
                name: "Kerkesat");

            migrationBuilder.DropTable(
                name: "tbl.LlojetDepartamenteve");

            migrationBuilder.DropTable(
                name: "tbl.MenaxhimiKerkesave");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
