using BookStore.Logic;
using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using BC = BCrypt.Net.BCrypt;

namespace BookStore.Controllers
{
	[Authorize(Roles = "Admin, User")]
	public class KhachHangController : Controller
	{
		private readonly BookStoreDBContext _context;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IMailLogic _mailLogic;
		public KhachHangController(BookStoreDBContext context, IHttpContextAccessor httpContextAccessor, IMailLogic mailLogic)
		{
			_context = context;
			_httpContextAccessor = httpContextAccessor;
			_mailLogic = mailLogic;
		}
		// GET: Index
		public IActionResult Index(string? successMessage)
		{
			int maNguoiDung = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "ID")?.Value);
			var nguoiDung = _context.NguoiDung.Where(r => r.ID == maNguoiDung).Include(s => s.DonHang).SingleOrDefault();
			if (nguoiDung == null)
			{
				return NotFound();
			}
			int soLuongDonHang = nguoiDung.DonHang.Count();
			TempData["SoLuongDonHang"] = soLuongDonHang;
			if (!string.IsNullOrEmpty(successMessage))
				TempData["ThongBao"] = successMessage;
			return View(new NguoiDung_ChinhSua(nguoiDung));
		}

		// GET: DonHangCuaToi
		public async Task<IActionResult> DonHangCuaToi()
		{
			int maNguoiDung = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "ID")?.Value);
			var datHang = _context.DonHang.Where(r => r.NguoiDungID == maNguoiDung)
			.Include(d => d.NguoiDung)
			.Include(d => d.TinhTrang)
			.Include(d => d.DonHang_ChiTiet)
			.ThenInclude(s => s.Sach);
			return View(await datHang.ToListAsync());
		}

		// GET: CapNhatHoSo
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CapNhatHoSo(int id, [Bind("ID,HoVaTen,Email,DienThoai,DiaChi,TenDangNhap,MatKhau,XacNhanMatKhau")] NguoiDung_ChinhSua nguoiDung)
		{
			if (id != nguoiDung.ID)
			{
				return NotFound();
			}
			if (ModelState.IsValid)
			{
			try
				{
					var n = _context.NguoiDung.Find(id);
					// Giữ nguyên mật khẩu cũ
					if (nguoiDung.MatKhau == null)
					{
						n.ID = nguoiDung.ID;
						n.HoVaTen = nguoiDung.HoVaTen;
						n.DienThoai = nguoiDung.DienThoai;
						n.DiaChi = nguoiDung.DiaChi;
						n.TenDangNhap = n.TenDangNhap;
						n.XacNhanMatKhau = n.MatKhau;
						n.Quyen = n.Quyen;
					}
					else // Cập nhật mật khẩu mới
					{
						n.ID = nguoiDung.ID;
						n.HoVaTen = nguoiDung.HoVaTen;
						n.DienThoai = nguoiDung.DienThoai;
						n.DiaChi = nguoiDung.DiaChi;
						n.TenDangNhap = n.TenDangNhap;
						n.MatKhau = BC.HashPassword(nguoiDung.MatKhau);
						n.XacNhanMatKhau = BC.HashPassword(nguoiDung.MatKhau);
						n.Quyen = n.Quyen;
					}
					_context.Update(n);
					await _context.SaveChangesAsync();
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message.ToString());
				}
				return RedirectToAction("Index", "KhachHang", new { Area = "", successMessage = "Đã cập nhật thông tin thành công." });
			}
			return View("Index", nguoiDung);
		}
	// GET: DatHang
		public IActionResult DatHang()
		{
			GioHangLogic gioHangLogic = new GioHangLogic(_context);
			var gioHang = gioHangLogic.LayGioHang();
			decimal tongTien = gioHangLogic.LayTongTienSanPham();
			TempData["TongTien"] = tongTien;
			return View(gioHang);
		}
		// GET: DatHang
		[HttpPost]
		public async Task<IActionResult> DatHang(DonHang datHang)
		{
			GioHangLogic gioHangLogic = new GioHangLogic(_context);
			var gioHang = gioHangLogic.LayGioHang();
			if (string.IsNullOrWhiteSpace(datHang.DienThoaiGiaoHang) || string.IsNullOrWhiteSpace(datHang.DiaChiGiaoHang))
			{
				decimal tongTien = gioHangLogic.LayTongTienSanPham();
				TempData["TongTien"] = tongTien;
				TempData["ThongBaoLoi"] = "Thông tin giao hàng không được bỏ trống.";
				return View(gioHang);
			}
			else
			{
				DonHang dh = new DonHang();
				dh.NguoiDungID = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "ID")?.Value);
				dh.TinhTrangID = 1; // Đơn hàng mới
				dh.DienThoaiGiaoHang = datHang.DienThoaiGiaoHang;
				dh.DiaChiGiaoHang = datHang.DiaChiGiaoHang;
				dh.NgayDatHang = DateTime.Now;
				_context.DonHang.Add(dh);
				await _context.SaveChangesAsync();
				foreach (var item in gioHang)
				{
					DonHang_ChiTiet ct = new DonHang_ChiTiet();
					ct.DonHangID = dh.ID;
					ct.SachID = item.SachID;
					ct.SoLuong = Convert.ToInt16(item.SoLuongTrongGio);
					ct.DonGia = item.Sach.DonGia;
					_context.DonHang_ChiTiet.Add(ct);
					await _context.SaveChangesAsync();
				} 
				// Gởi email
			try
				{
					MailInfo mailInfo = new MailInfo();
					mailInfo.Subject = "Đặt hàng thành công tại BookStore.Com.Vn";
					var datHangInfo = _context.DonHang.Where(r => r.ID == dh.ID)
					.Include(s => s.NguoiDung)
					.Include(s => s.DonHang_ChiTiet).SingleOrDefault();
					await _mailLogic.SendEmailDatHangThanhCong(datHangInfo, mailInfo);
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message.ToString());
				}
				return RedirectToAction("DatHangThanhCong", "KhachHang", new { Area = "" });
			}
		}
		// GET: DatHangThanhCong
		public IActionResult DatHangThanhCong()
		{
			// Xóa giỏ hàng sau khi hoàn tất đặt hàng
			GioHangLogic gioHangLogic = new GioHangLogic(_context);
			gioHangLogic.XoaTatCa();
			return View();
		}
	}
}
