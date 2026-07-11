using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningWebAgit.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RencanaModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SeninAsli = table.Column<int>(type: "INTEGER", nullable: false),
                    SelasaAsli = table.Column<int>(type: "INTEGER", nullable: false),
                    RabuAsli = table.Column<int>(type: "INTEGER", nullable: false),
                    KamisAsli = table.Column<int>(type: "INTEGER", nullable: false),
                    JumatAsli = table.Column<int>(type: "INTEGER", nullable: false),
                    SabtuAsli = table.Column<int>(type: "INTEGER", nullable: false),
                    MingguAsli = table.Column<int>(type: "INTEGER", nullable: false),
                    SeninHasil = table.Column<int>(type: "INTEGER", nullable: false),
                    SelasaHasil = table.Column<int>(type: "INTEGER", nullable: false),
                    RabuHasil = table.Column<int>(type: "INTEGER", nullable: false),
                    KamisHasil = table.Column<int>(type: "INTEGER", nullable: false),
                    JumatHasil = table.Column<int>(type: "INTEGER", nullable: false),
                    SabtuHasil = table.Column<int>(type: "INTEGER", nullable: false),
                    MingguHasil = table.Column<int>(type: "INTEGER", nullable: false),
                    TanggalProduksi = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RencanaModel", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RencanaModel");
        }
    }
}
