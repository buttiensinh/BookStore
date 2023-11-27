using BookStore.Logic;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.ViewComponents
{
	public class GioHangViewComponent : ViewComponent
	{
		private readonly BookStoreDBContext _context;
		public GioHangViewComponent(BookStoreDBContext context)
		{
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			GioHangLogic gioHangLogic = new GioHangLogic(_context);
			decimal tongTien = gioHangLogic.LayTongTienSanPham();
			decimal tongSoLuong = gioHangLogic.LayTongSoLuong();
			TempData["TopMenu_TongTien"] = tongTien;
			TempData["TopMenu_TongSoLuong"] = tongSoLuong;
			return View("Default");
		}
	}
}
