using Microsoft.EntityFrameworkCore;

namespace BookStore.Models
{
    public class BookStoreDBContext : DbContext
    {
        public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options) : base(options) { }
        public DbSet<DonHang> DonHang { get; set; }
        public DbSet<NhaSanXuat> NhaSanXuat { get; set; }
        public DbSet<Sach> Sach { get; set; }
        public DbSet<NguoiDung> NguoiDung { get; set; }
        public DbSet<TacGia> TacGia { get; set; }
        public DbSet<ThamGia> ThamGia { get; set; }
        public DbSet<TheLoai> TheLoai { get; set; }
        public DbSet<TinhTrang> TinhTrang { get; set; }
        public DbSet<DonHang_ChiTiet> DonHang_ChiTiet { get; set; }
		public DbSet<GioHang> GioHang { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>().ToTable("DonHang");
            modelBuilder.Entity<NhaSanXuat>().ToTable("NhaSanXuat");
            modelBuilder.Entity<Sach>().ToTable("Sach");
            modelBuilder.Entity<NguoiDung>().ToTable("NguoiDung");
            modelBuilder.Entity<TacGia>().ToTable("TacGia");
            modelBuilder.Entity<ThamGia>().ToTable("ThamGia");
            modelBuilder.Entity<TheLoai>().ToTable("TheLoai");
            modelBuilder.Entity<TinhTrang>().ToTable("TinhTrang");
            modelBuilder.Entity<DonHang_ChiTiet>().ToTable("DonHang_ChiTiet");
			modelBuilder.Entity<GioHang>().ToTable("GioHang");
		}
    }
}
