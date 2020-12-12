using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationCore.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl.KerkesatAnkesat");

            migrationBuilder.DropTable(
                name: "tbl.Veprimet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl.Departamentet",
                table: "tbl.Departamentet");

            migrationBuilder.RenameColumn(
                name: "DepartamentiId",
                table: "tbl.LlojetDepartamenteve",
                newName: "DepartamentiID");

            migrationBuilder.AlterColumn<string>(
                name: "EmriDepartamentit",
                table: "tbl.LlojetDepartamenteve",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InsertBy",
                table: "tbl.LlojetDepartamenteve",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "tbl.LlojetDepartamenteve",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "tbl.LlojetDepartamenteve",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tbl.LlojetDepartamenteve",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LUB",
                table: "tbl.LlojetDepartamenteve",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LUD",
                table: "tbl.LlojetDepartamenteve",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LUN",
                table: "tbl.LlojetDepartamenteve",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Kerkesat",
                columns: table => new
                {
                    KerkesaAnkesaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(maxLength: 450, nullable: true),
                    LlojiKerkeses = table.Column<int>(nullable: true),
                    DepartamentiID = table.Column<int>(nullable: true),
                    Nenshkrimi = table.Column<string>(maxLength: 50, nullable: true),
                    PershkrimiIKerkeses = table.Column<string>(maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    IsAnonim = table.Column<bool>(nullable: true),
                    AnonimID = table.Column<int>(nullable: true),
                    InsertBy = table.Column<int>(nullable: true),
                    InsertDate = table.Column<DateTime>(type: "date", nullable: true),
                    LUB = table.Column<int>(nullable: true),
                    LUD = table.Column<DateTime>(type: "date", nullable: true),
                    LUN = table.Column<int>(nullable: true)
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
                name: "Veprimet",
                columns: table => new
                {
                    VeprimiID = table.Column<int>(nullable: false),
                    KerkesaID = table.Column<int>(nullable: true),
                    Pranimi = table.Column<bool>(nullable: true),
                    Verifikimi = table.Column<bool>(nullable: true),
                    Miratimi = table.Column<bool>(nullable: true),
                    Vendimi = table.Column<bool>(nullable: true),
                    Grupi = table.Column<string>(maxLength: 50, nullable: true),
                    Orari = table.Column<string>(maxLength: 50, nullable: true),
                    LendetEMbetura = table.Column<string>(maxLength: 500, nullable: true),
                    LendetEPranuara = table.Column<string>(maxLength: 500, nullable: true),
                    VitiAkademik = table.Column<string>(maxLength: 50, nullable: true),
                    RefuzimiTotalPerLende = table.Column<string>(maxLength: 50, nullable: true),
                    ObligimetEMbetura = table.Column<string>(maxLength: 500, nullable: true),
                    LendetERefuzuara = table.Column<string>(maxLength: 500, nullable: true),
                    PagesatEPerfunduara = table.Column<string>(maxLength: 500, nullable: true),
                    InsertBy = table.Column<int>(nullable: true),
                    InsertDate = table.Column<DateTime>(type: "date", nullable: true),
                    LUB = table.Column<int>(nullable: true),
                    LUD = table.Column<DateTime>(type: "date", nullable: true),
                    LUN = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_tbl.Departamentet_DepartamentiID",
                table: "tbl.Departamentet",
                column: "DepartamentiID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl.Departamentet_VeprimetID",
                table: "tbl.Departamentet",
                column: "VeprimetID");

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
                name: "IX_Veprimet_KerkesaID",
                table: "Veprimet",
                column: "KerkesaID");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl.Departamentet_tbl.LlojetDepartamenteve",
                table: "tbl.Departamentet",
                column: "DepartamentiID",
                principalTable: "tbl.LlojetDepartamenteve",
                principalColumn: "DepartamentiID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl.Departamentet_Veprimet",
                table: "tbl.Departamentet",
                column: "VeprimetID",
                principalTable: "Veprimet",
                principalColumn: "VeprimiID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl.Departamentet_tbl.LlojetDepartamenteve",
                table: "tbl.Departamentet");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl.Departamentet_Veprimet",
                table: "tbl.Departamentet");

            migrationBuilder.DropTable(
                name: "Veprimet");

            migrationBuilder.DropTable(
                name: "Kerkesat");

            migrationBuilder.DropIndex(
                name: "IX_tbl.Departamentet_DepartamentiID",
                table: "tbl.Departamentet");

            migrationBuilder.DropIndex(
                name: "IX_tbl.Departamentet_VeprimetID",
                table: "tbl.Departamentet");

            migrationBuilder.DropColumn(
                name: "InsertBy",
                table: "tbl.LlojetDepartamenteve");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "tbl.LlojetDepartamenteve");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "tbl.LlojetDepartamenteve");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tbl.LlojetDepartamenteve");

            migrationBuilder.DropColumn(
                name: "LUB",
                table: "tbl.LlojetDepartamenteve");

            migrationBuilder.DropColumn(
                name: "LUD",
                table: "tbl.LlojetDepartamenteve");

            migrationBuilder.DropColumn(
                name: "LUN",
                table: "tbl.LlojetDepartamenteve");

            migrationBuilder.RenameColumn(
                name: "DepartamentiID",
                table: "tbl.LlojetDepartamenteve",
                newName: "DepartamentiId");

            migrationBuilder.AlterColumn<string>(
                name: "EmriDepartamentit",
                table: "tbl.LlojetDepartamenteve",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl.Departamentet",
                table: "tbl.Departamentet",
                column: "DepartamentiID");

            migrationBuilder.CreateTable(
                name: "tbl.KerkesatAnkesat",
                columns: table => new
                {
                    AnonimID = table.Column<int>(type: "int", nullable: true),
                    Departamenti = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InsertBy = table.Column<int>(type: "int", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "date", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsAnonim = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    KerkesaAnkesaID = table.Column<int>(type: "int", nullable: false),
                    LUB = table.Column<int>(type: "int", nullable: true),
                    LUD = table.Column<DateTime>(type: "date", nullable: true),
                    LUN = table.Column<int>(type: "int", nullable: true),
                    Nenshkrimi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PershkrimiIKerkeses = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RoliID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tbl.Veprimet",
                columns: table => new
                {
                    Grupi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InsertBy = table.Column<int>(type: "int", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "date", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    KerkesaID = table.Column<int>(type: "int", nullable: true),
                    LendetEMbetura = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LendetEPranuara = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LendetERefuzuara = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LlojiIKerkeses = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LUB = table.Column<int>(type: "int", nullable: true),
                    LUD = table.Column<DateTime>(type: "date", nullable: true),
                    LUN = table.Column<int>(type: "int", nullable: true),
                    MenaxhimiID = table.Column<int>(type: "int", nullable: true),
                    Miratimi = table.Column<bool>(type: "bit", nullable: true),
                    ObligimetEMbetura = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Orari = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PagesatEPerfunduara = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Pranimi = table.Column<bool>(type: "bit", nullable: true),
                    RefuzimiTotalPerLende = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Vendimi = table.Column<bool>(type: "bit", nullable: true),
                    VeprimiID = table.Column<int>(type: "int", nullable: false),
                    Verifikimi = table.Column<bool>(type: "bit", nullable: true),
                    VitiAkademik = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                });
        }
    }
}
