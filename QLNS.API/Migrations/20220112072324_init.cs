using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QLNS.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChucVus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenChucVu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhongBans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenPhongBan = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongBans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySinh = table.Column<int>(type: "int", nullable: false),
                    ThangSinh = table.Column<int>(type: "int", nullable: false),
                    NamSinh = table.Column<int>(type: "int", nullable: false),
                    GioiTinh = table.Column<int>(type: "int", nullable: false),
                    ChucVuId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PhongBanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhanViens_ChucVus_ChucVuId",
                        column: x => x.ChucVuId,
                        principalTable: "ChucVus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_NhanViens_PhongBans_PhongBanId",
                        column: x => x.PhongBanId,
                        principalTable: "PhongBans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "HopDongLaoDongs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoaiHopDong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NhanVienId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDongLaoDongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HopDongLaoDongs_NhanViens_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QueQuans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChiTiet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XaPhuong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuanHuyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TinhThanhPho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NhanVienId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueQuans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QueQuans_NhanViens_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NhanVienId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_NhanViens_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HopDongLaoDongs_NhanVienId",
                table: "HopDongLaoDongs",
                column: "NhanVienId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_ChucVuId",
                table: "NhanViens",
                column: "ChucVuId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_PhongBanId",
                table: "NhanViens",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_QueQuans_NhanVienId",
                table: "QueQuans",
                column: "NhanVienId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_NhanVienId",
                table: "Users",
                column: "NhanVienId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HopDongLaoDongs");

            migrationBuilder.DropTable(
                name: "QueQuans");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "ChucVus");

            migrationBuilder.DropTable(
                name: "PhongBans");
        }
    }
}
