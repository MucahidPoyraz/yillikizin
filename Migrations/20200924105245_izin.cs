using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YillikIzin.Migrations
{
    public partial class izin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "Izinturleri");

            migrationBuilder.DropIndex(
                name: "IX_Izinler_TurId",
                table: "Izinler");

            migrationBuilder.DropColumn(
                name: "TurId",
                table: "Izinler");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TurId",
                table: "Izinler",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Izinler_TurId",
                table: "Izinler",
                column: "TurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Izinler_Izinturleri_TurId",
                table: "Izinler",
                column: "TurId",
                principalTable: "Izinturleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
