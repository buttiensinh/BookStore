﻿using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
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
		}
	}
}
