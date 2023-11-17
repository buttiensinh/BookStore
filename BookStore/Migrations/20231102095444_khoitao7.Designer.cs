﻿// <auto-generated />
using System;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStore.Migrations
{
    [DbContext(typeof(BookStoreDBContext))]
    [Migration("20231102095444_khoitao7")]
    partial class khoitao7
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookStore.Models.DonHang", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("DiaChiGiaoHang")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("DienThoaiGiaoHang")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("NgayDatHang")
                        .HasColumnType("datetime2");

                    b.Property<int>("NguoiDungID")
                        .HasColumnType("int");

                    b.Property<int>("TinhTrangID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("NguoiDungID");

                    b.HasIndex("TinhTrangID");

                    b.ToTable("DonHang", (string)null);
                });

            modelBuilder.Entity("BookStore.Models.DonHang_ChiTiet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("DonGia")
                        .HasColumnType("int");

                    b.Property<int>("DonHangID")
                        .HasColumnType("int");

                    b.Property<int>("SachID")
                        .HasColumnType("int");

                    b.Property<short>("SoLuong")
                        .HasColumnType("smallint");

                    b.HasKey("ID");

                    b.HasIndex("DonHangID");

                    b.HasIndex("SachID");

                    b.ToTable("DonHang_ChiTiet", (string)null);
                });

            modelBuilder.Entity("BookStore.Models.NguoiDung", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("DiaChi")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("DienThoai")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("HoVaTen")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("Quyen")
                        .HasColumnType("bit");

                    b.Property<string>("TenDangNhap")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("NguoiDung", (string)null);
                });

            modelBuilder.Entity("BookStore.Models.NhaSanXuat", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("DienThoai")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("TenNhaSanXuat")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("NhaSanXuat", (string)null);
                });

            modelBuilder.Entity("BookStore.Models.Sach", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("AnhBia")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("DonGia")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasColumnType("ntext");

                    b.Property<DateTime>("NgayNhap")
                        .HasColumnType("datetime2");

                    b.Property<int>("NhaSanXuatID")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("TenSach")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TheLoaiID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("NhaSanXuatID");

                    b.HasIndex("TheLoaiID");

                    b.ToTable("Sach", (string)null);
                });

            modelBuilder.Entity("BookStore.Models.TacGia", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("DienThoai")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("TenTacGia")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ThamGiaID")
                        .HasColumnType("int");

                    b.Property<string>("TieuSu")
                        .HasColumnType("ntext");

                    b.HasKey("ID");

                    b.HasIndex("ThamGiaID");

                    b.ToTable("TacGia", (string)null);
                });

            modelBuilder.Entity("BookStore.Models.ThamGia", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("VaiTro")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ViTri")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("ThamGia", (string)null);
                });

            modelBuilder.Entity("BookStore.Models.TheLoai", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("TenTheLoai")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("TheLoai", (string)null);
                });

            modelBuilder.Entity("BookStore.Models.TinhTrang", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ID");

                    b.ToTable("TinhTrang", (string)null);
                });

            modelBuilder.Entity("BookStore.Models.DonHang", b =>
                {
                    b.HasOne("BookStore.Models.NguoiDung", "NguoiDung")
                        .WithMany("DonHang")
                        .HasForeignKey("NguoiDungID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStore.Models.TinhTrang", "TinhTrang")
                        .WithMany("DonHang")
                        .HasForeignKey("TinhTrangID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiDung");

                    b.Navigation("TinhTrang");
                });

            modelBuilder.Entity("BookStore.Models.DonHang_ChiTiet", b =>
                {
                    b.HasOne("BookStore.Models.DonHang", "DonHang")
                        .WithMany("DonHang_ChiTiet")
                        .HasForeignKey("DonHangID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStore.Models.Sach", "Sach")
                        .WithMany("DonHang_ChiTiet")
                        .HasForeignKey("SachID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonHang");

                    b.Navigation("Sach");
                });

            modelBuilder.Entity("BookStore.Models.Sach", b =>
                {
                    b.HasOne("BookStore.Models.NhaSanXuat", "NhaSanXuat")
                        .WithMany("Sach")
                        .HasForeignKey("NhaSanXuatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStore.Models.TheLoai", "TheLoai")
                        .WithMany("Sach")
                        .HasForeignKey("TheLoaiID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NhaSanXuat");

                    b.Navigation("TheLoai");
                });

            modelBuilder.Entity("BookStore.Models.TacGia", b =>
                {
                    b.HasOne("BookStore.Models.ThamGia", null)
                        .WithMany("TacGia")
                        .HasForeignKey("ThamGiaID");
                });

            modelBuilder.Entity("BookStore.Models.DonHang", b =>
                {
                    b.Navigation("DonHang_ChiTiet");
                });

            modelBuilder.Entity("BookStore.Models.NguoiDung", b =>
                {
                    b.Navigation("DonHang");
                });

            modelBuilder.Entity("BookStore.Models.NhaSanXuat", b =>
                {
                    b.Navigation("Sach");
                });

            modelBuilder.Entity("BookStore.Models.Sach", b =>
                {
                    b.Navigation("DonHang_ChiTiet");
                });

            modelBuilder.Entity("BookStore.Models.ThamGia", b =>
                {
                    b.Navigation("TacGia");
                });

            modelBuilder.Entity("BookStore.Models.TheLoai", b =>
                {
                    b.Navigation("Sach");
                });

            modelBuilder.Entity("BookStore.Models.TinhTrang", b =>
                {
                    b.Navigation("DonHang");
                });
#pragma warning restore 612, 618
        }
    }
}
