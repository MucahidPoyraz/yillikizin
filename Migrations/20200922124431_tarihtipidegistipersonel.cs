using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YillikIzin.Migrations
{
    public partial class tarihtipidegistipersonel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Giristarih",
                table: "Personeller",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Giristarih",
                table: "Personeller",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
