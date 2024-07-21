using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppData.Migrations
{
    public partial class _2107 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "anhSPs");

            migrationBuilder.DropColumn(
                name: "GiaSP",
                table: "sanPhamCTs");

            migrationBuilder.AddColumn<string>(
                name: "AnhSP",
                table: "sanPhams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "GiaSP",
                table: "sanPhams",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnhSP",
                table: "sanPhams");

            migrationBuilder.DropColumn(
                name: "GiaSP",
                table: "sanPhams");

            migrationBuilder.AddColumn<decimal>(
                name: "GiaSP",
                table: "sanPhamCTs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "anhSPs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SanPhamCTId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImgSP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenSP = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_anhSPs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_anhSPs_sanPhamCTs_SanPhamCTId",
                        column: x => x.SanPhamCTId,
                        principalTable: "sanPhamCTs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_anhSPs_SanPhamCTId",
                table: "anhSPs",
                column: "SanPhamCTId");
        }
    }
}
