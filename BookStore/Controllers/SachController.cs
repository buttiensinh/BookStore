using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Slugify;

namespace BookStore.Controllers
{
	public class SachController : Controller
	{
		private readonly BookStoreDBContext _context;
		public SachController(BookStoreDBContext context)
		{
			_context = context;
		}
		// GET: Index
		public IActionResult Index(int? trang)
		{
			var danhSach = LayDanhSachSanPham(trang ?? 1);
			if (danhSach.Sach.Count == 0)
				return NotFound();
			else
				return View(danhSach);
		}
	private PhanTrangSanPham LayDanhSachSanPham(int trangHienTai)
		{
			int maxRows = 20;
			PhanTrangSanPham phanTrang = new PhanTrangSanPham();
			phanTrang.Sach = _context.Sach
			.Include(s => s.NhaSanXuat)
			.Include(s => s.TheLoai)
			.OrderBy(r => r.TheLoaiID)
			.Skip((trangHienTai - 1) * maxRows)
			.Take(maxRows).ToList();
			decimal tongSoTrang = Convert.ToDecimal(_context.Sach.Count()) / Convert.ToDecimal(maxRows);
			phanTrang.TongSoTrang = (int)Math.Ceiling(tongSoTrang);
			phanTrang.TrangHienTai = trangHienTai;
			return phanTrang;
		}

		// GET: PhanLoai
		public IActionResult PhanLoai(int? trang, string tenLoai)
		{
			var danhSachPhanLoai = LayDanhSachSanPhamTheoPhanLoai(trang ?? 1, tenLoai);
			if (danhSachPhanLoai.Sach.Count == 0)
				return NotFound();
			else
				return View(danhSachPhanLoai);
		}
		private PhanTrangSanPham LayDanhSachSanPhamTheoPhanLoai(int trangHienTai, string tenLoai)
		{
			int maxRows = 20;
			SlugHelper slug = new SlugHelper();
			var sanPhamPhanLoai = _context.Sach
			.Include(s => s.NhaSanXuat)
			.Include(s => s.TheLoai)
			.AsEnumerable().Where(r => slug.GenerateSlug(r.TheLoai.TenTheLoai) == tenLoai);
			PhanTrangSanPham phanTrang = new PhanTrangSanPham();
			phanTrang.Sach = sanPhamPhanLoai.OrderBy(r => r.TheLoaiID)
			.Skip((trangHienTai - 1) * maxRows)
			.Take(maxRows).ToList();
			decimal tongSoTrang = Convert.ToDecimal(sanPhamPhanLoai.Count()) / Convert.ToDecimal(maxRows);
			phanTrang.TongSoTrang = (int)Math.Ceiling(tongSoTrang);
			phanTrang.TrangHienTai = trangHienTai;
			return phanTrang;
		}

		// GET: ChiTiet
		public IActionResult ChiTiet(string tenSanPham)
		{
			SlugHelper slug = new SlugHelper();
			var sanPham = _context.Sach
			.Include(s => s.NhaSanXuat)
			.Include(s => s.TheLoai)
			.AsEnumerable().Where(r => slug.GenerateSlug(r.TenSach) == tenSanPham).SingleOrDefault();
			if (sanPham == null)
				return NotFound();
			else
				return View(sanPham);
		}

	}
}