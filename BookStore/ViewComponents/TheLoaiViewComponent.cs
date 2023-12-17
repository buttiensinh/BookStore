using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace BookStore.ViewComponents
{
	public class TheLoaiViewComponent : ViewComponent
	{
		private readonly BookStoreDBContext _context;
		public TheLoaiViewComponent(BookStoreDBContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var theloai = _context.TheLoai.OrderBy(r => r.TenTheLoai);
			return View("Default", theloai);
		}
	}
}
