using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YillikIzin.Migrations
{
    public partial class izintablosueklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Izinturleri",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Turadi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izinturleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Izinler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonelId = table.Column<int>(nullable: false),
                    TurId = table.Column<int>(nullable: false),
                    BaslamaTarihi = table.Column<DateTime>(type: "date", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "date", nullable: false),
                    Taleptarihi = table.Column<DateTime>(type: "date", nullable: false),
                    Adres = table.Column<string>(nullable: true),
                    Kullanilanizin = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izinler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Izinler_Personeller_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personeller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Izinler_Izinturleri_TurId",
                        column: x => x.TurId,
                        principalTable: "Izinturleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Izinler_PersonelId",
                table: "Izinler",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_Izinler_TurId",
                table: "Izinler",
                column: "TurId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Izinler");

            migrationBuilder.DropTable(
                name: "Izinturleri");
        }
    }
}
