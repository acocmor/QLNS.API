﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QLNS.Infrastructure.Context;

namespace QLNS.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220111081250_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QLNS.Domain.Entities.ChucVu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TenChucVu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ChucVus");
                });

            modelBuilder.Entity("QLNS.Domain.Entities.HopDongLaoDong", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoaiHopDong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("HopDongLaoDongs");
                });

            modelBuilder.Entity("QLNS.Domain.Entities.NhanVien", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ChucVuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GioiTinh")
                        .HasColumnType("int");

                    b.Property<string>("Ho")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("HopDongLaoDongId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NamSinh")
                        .HasColumnType("int");

                    b.Property<int>("NgaySinh")
                        .HasColumnType("int");

                    b.Property<Guid?>("PhongBanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("QueQuanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ThangSinh")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ChucVuId");

                    b.HasIndex("HopDongLaoDongId")
                        .IsUnique()
                        .HasFilter("[HopDongLaoDongId] IS NOT NULL");

                    b.HasIndex("PhongBanId");

                    b.HasIndex("QueQuanId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("NhanViens");
                });

            modelBuilder.Entity("QLNS.Domain.Entities.PhongBan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TenPhongBan")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PhongBans");
                });

            modelBuilder.Entity("QLNS.Domain.Entities.QueQuan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ChiTiet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuanHuyen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TinhThanhPho")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("XaPhuong")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("QueQuans");
                });

            modelBuilder.Entity("QLNS.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("QLNS.Domain.Entities.NhanVien", b =>
                {
                    b.HasOne("QLNS.Domain.Entities.ChucVu", "ChucVu")
                        .WithMany("DanhSachNhanVien")
                        .HasForeignKey("ChucVuId");

                    b.HasOne("QLNS.Domain.Entities.HopDongLaoDong", "HopDongLaoDong")
                        .WithOne("NhanVien")
                        .HasForeignKey("QLNS.Domain.Entities.NhanVien", "HopDongLaoDongId");

                    b.HasOne("QLNS.Domain.Entities.PhongBan", "PhongBan")
                        .WithMany("DanhSachNhanVien")
                        .HasForeignKey("PhongBanId");

                    b.HasOne("QLNS.Domain.Entities.QueQuan", "QueQuan")
                        .WithOne("NhanVien")
                        .HasForeignKey("QLNS.Domain.Entities.NhanVien", "QueQuanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLNS.Domain.Entities.User", "User")
                        .WithOne("NhanVien")
                        .HasForeignKey("QLNS.Domain.Entities.NhanVien", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChucVu");

                    b.Navigation("HopDongLaoDong");

                    b.Navigation("PhongBan");

                    b.Navigation("QueQuan");

                    b.Navigation("User");
                });

            modelBuilder.Entity("QLNS.Domain.Entities.ChucVu", b =>
                {
                    b.Navigation("DanhSachNhanVien");
                });

            modelBuilder.Entity("QLNS.Domain.Entities.HopDongLaoDong", b =>
                {
                    b.Navigation("NhanVien");
                });

            modelBuilder.Entity("QLNS.Domain.Entities.PhongBan", b =>
                {
                    b.Navigation("DanhSachNhanVien");
                });

            modelBuilder.Entity("QLNS.Domain.Entities.QueQuan", b =>
                {
                    b.Navigation("NhanVien");
                });

            modelBuilder.Entity("QLNS.Domain.Entities.User", b =>
                {
                    b.Navigation("NhanVien");
                });
#pragma warning restore 612, 618
        }
    }
}
