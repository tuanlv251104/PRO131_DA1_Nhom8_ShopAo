using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppData.Migrations
{
    public partial class _307 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "danhSachSPs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenDanhMuc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_danhSachSPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "gioHangs",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gioHangs", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "maGiamGia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenMaGiamGia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhanTramGiam = table.Column<int>(type: "int", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maGiamGia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mauSacs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenMau = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mauSacs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sizeSPs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenSize = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sizeSPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "taiKhoans",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taiKhoans", x => x.Username);
                    table.ForeignKey(
                        name: "FK_taiKhoans_gioHangs_Username",
                        column: x => x.Username,
                        principalTable: "gioHangs",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sanPhams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDanhMucSP = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnhSP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenSP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaSP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MauSacId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    ThuongHieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThaiSP = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sanPhams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sanPhams_danhSachSPs_IdDanhMucSP",
                        column: x => x.IdDanhMucSP,
                        principalTable: "danhSachSPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sanPhams_mauSacs_MauSacId",
                        column: x => x.MauSacId,
                        principalTable: "mauSacs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sanPhams_sizeSPs_SizeId",
                        column: x => x.SizeId,
                        principalTable: "sizeSPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hoaDons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdMaGiamGia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenNguoiNhan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<int>(type: "int", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayMua = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThaiDonHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThaiThanhToan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hoaDons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hoaDons_maGiamGia_IdMaGiamGia",
                        column: x => x.IdMaGiamGia,
                        principalTable: "maGiamGia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hoaDons_taiKhoans_Username",
                        column: x => x.Username,
                        principalTable: "taiKhoans",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gioHangCTs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SanPhamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gioHangCTs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gioHangCTs_gioHangs_Username",
                        column: x => x.Username,
                        principalTable: "gioHangs",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gioHangCTs_sanPhams_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "sanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hoaDonCTs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdsanPham = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdHoaDon = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hoaDonCTs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hoaDonCTs_hoaDons_IdHoaDon",
                        column: x => x.IdHoaDon,
                        principalTable: "hoaDons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hoaDonCTs_sanPhams_IdsanPham",
                        column: x => x.IdsanPham,
                        principalTable: "sanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_gioHangCTs_SanPhamId",
                table: "gioHangCTs",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_gioHangCTs_Username",
                table: "gioHangCTs",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_hoaDonCTs_IdHoaDon",
                table: "hoaDonCTs",
                column: "IdHoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_hoaDonCTs_IdsanPham",
                table: "hoaDonCTs",
                column: "IdsanPham");

            migrationBuilder.CreateIndex(
                name: "IX_hoaDons_IdMaGiamGia",
                table: "hoaDons",
                column: "IdMaGiamGia",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_hoaDons_Username",
                table: "hoaDons",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_sanPhams_IdDanhMucSP",
                table: "sanPhams",
                column: "IdDanhMucSP");

            migrationBuilder.CreateIndex(
                name: "IX_sanPhams_MauSacId",
                table: "sanPhams",
                column: "MauSacId");

            migrationBuilder.CreateIndex(
                name: "IX_sanPhams_SizeId",
                table: "sanPhams",
                column: "SizeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gioHangCTs");

            migrationBuilder.DropTable(
                name: "hoaDonCTs");

            migrationBuilder.DropTable(
                name: "hoaDons");

            migrationBuilder.DropTable(
                name: "sanPhams");

            migrationBuilder.DropTable(
                name: "maGiamGia");

            migrationBuilder.DropTable(
                name: "taiKhoans");

            migrationBuilder.DropTable(
                name: "danhSachSPs");

            migrationBuilder.DropTable(
                name: "mauSacs");

            migrationBuilder.DropTable(
                name: "sizeSPs");

            migrationBuilder.DropTable(
                name: "gioHangs");
        }
    }
}
