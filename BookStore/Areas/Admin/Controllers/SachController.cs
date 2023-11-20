using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;
using Slugify;
using System.Linq.Dynamic.Core;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.AspNetCore.Authorization;

namespace BookStore.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class SachController : Controller
    {
        private readonly BookStoreDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public SachController(BookStoreDBContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Sach
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: SanPham/Index_LoadData
        public IActionResult Index_LoadData()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = length != null ? int.Parse(length) : 0;
                int skip = start != null ? int.Parse(start) : 0;
                int totalRecords = 0;
                int filterRecords = 0;
                var sach = from r in _context.Sach
                           select new
                           {
                               ID = r.ID,
                               AnhBia = r.AnhBia,
                               TenTheLoai = r.TheLoai.TenTheLoai,
                               TenNhaSanXuat = r.NhaSanXuat.TenNhaSanXuat,
                               TenTacGia = r.TacGia.TenTacGia,
                               TenSach = r.TenSach,
                               SoLuong = r.SoLuong,
                               DonGia = r.DonGia
                              };
                totalRecords = sach.Count();
                // Sắp xếp
                if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortColumnDirection))
                {
                    sach = sach.OrderBy(sortColumn + " " + sortColumnDirection);
                }
                // Tìm kiếm
                if (!string.IsNullOrEmpty(searchValue) && !string.IsNullOrWhiteSpace(searchValue))
                {
                    sach = sach.Where(r => r.TenTheLoai.Contains(searchValue) ||
                    r.TenNhaSanXuat.Contains(searchValue) ||
					r.TenTacGia.Contains(searchValue) ||
					r.TenSach.Contains(searchValue) ||
                    r.SoLuong.ToString().Contains(searchValue) ||
                    r.DonGia.ToString().Contains(searchValue));
                }
                filterRecords = sach.Count();
                var data = sach.Skip(skip).Take(pageSize).ToList();
                var jsonData = new
                {
                    draw = draw,
                    recordsFiltered = filterRecords,
                    recordsTotal = totalRecords,
                    data = data
                };
                return Json(jsonData, new System.Text.Json.JsonSerializerOptions());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    

// GET: Sach/Details/5
public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sach == null)
            {
                return NotFound();
            }

            var sach = await _context.Sach
                .Include(s => s.NhaSanXuat)
                .Include(s => s.TheLoai)
			    .Include(s => s.TacGia)
				.FirstOrDefaultAsync(m => m.ID == id);
            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }

        // GET: Sach/Create
        public IActionResult Create()
        {
            ViewData["NhaSanXuatID"] = new SelectList(_context.NhaSanXuat, "ID", "TenNhaSanXuat");
            ViewData["TheLoaiID"] = new SelectList(_context.TheLoai, "ID", "TenTheLoai");
			ViewData["TacGiaID"] = new SelectList(_context.TacGia, "ID", "TenTacGia");
			return View();
        }

        // POST: Sach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TheLoaiID,NhaSanXuatID,TacGiaID,TenSach,DonGia,DuLieuHinhAnh,SoLuong,MoTa")] Sach sach)
        {
            if (ModelState.IsValid)
            {
				string path = "";
				// Nếu hình ảnh không bỏ trống thì upload
				if (sach.DuLieuHinhAnh != null)
				{
					string wwwRootPath = _hostEnvironment.WebRootPath;
					string folder = "/uploads/";
					string fileExtension = Path.GetExtension(sach.DuLieuHinhAnh.FileName).ToLower();
					string fileName = sach.TenSach;

					SlugHelper slug = new SlugHelper();
					string fileNameSluged = slug.GenerateSlug(fileName);

					path =   fileNameSluged + fileExtension;
					string physicalPath = Path.Combine(wwwRootPath + folder, fileNameSluged + fileExtension);
					using (var fileStream = new FileStream(physicalPath, FileMode.Create))
					{
						await sach.DuLieuHinhAnh.CopyToAsync(fileStream);
					}
				} 
                // Cập nhật đường dẫn vào CSDL
                sach.AnhBia = path ?? null;

				_context.Add(sach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NhaSanXuatID"] = new SelectList(_context.NhaSanXuat, "ID", "TenNhaSanXuat", sach.NhaSanXuatID);
            ViewData["TheLoaiID"] = new SelectList(_context.TheLoai, "ID", "TenTheLoai", sach.TheLoaiID);
			ViewData["TacGiaID"] = new SelectList(_context.TacGia, "ID", "TenTacGia", sach.TacGiaID);
			return View(sach);
        }

        // GET: Sach/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sach == null)
            {
                return NotFound();
            }

            var sach = await _context.Sach.FindAsync(id);
            if (sach == null)
            {
                return NotFound();
            }
            ViewData["NhaSanXuatID"] = new SelectList(_context.NhaSanXuat, "ID", "TenNhaSanXuat", sach.NhaSanXuatID);
            ViewData["TheLoaiID"] = new SelectList(_context.TheLoai, "ID", "TenTheLoai", sach.TheLoaiID);
			ViewData["TacGiaID"] = new SelectList(_context.TacGia, "ID", "TenTacGia", sach.TacGiaID);
			return View(sach);
        }

        // POST: Sach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TheLoaiID,NhaSanXuatID,TacGiaID,TenSach,DonGia,DuLieuHinhAnh,SoLuong,MoTa")] Sach sach)
        {
            if (id != sach.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string path = "";

                    // Nếu hình ảnh không bỏ trống thì upload ảnh mới

                    if (sach.DuLieuHinhAnh != null)
                    {
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string folder = "/uploads/";
                        string fileExtension = Path.GetExtension(sach.DuLieuHinhAnh.FileName).ToLower();

                        string fileName = sach.TenSach;
                        SlugHelper slug = new SlugHelper();
                        string fileNameSluged = slug.GenerateSlug(fileName);
                        path = fileNameSluged + fileExtension;

                        string physicalPath = Path.Combine(wwwRootPath + folder, fileNameSluged + fileExtension);

                        using (var fileStream = new FileStream(physicalPath, FileMode.Create))
                        {
                            await sach.DuLieuHinhAnh.CopyToAsync(fileStream);
                        }
                    }
                    _context.Update(sach);

                    if (string.IsNullOrEmpty(path))

                        _context.Entry(sach).Property(x => x.AnhBia).IsModified = false;
                    else
                        sach.AnhBia = path;
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SachExists(sach.ID))

                    {

                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["NhaSanXuatID"] = new SelectList(_context.NhaSanXuat, "ID", "TenNhaSanXuat", sach.NhaSanXuatID);
            ViewData["TheLoaiID"] = new SelectList(_context.TheLoai, "ID", "TheLoai", sach.TheLoaiID);
			ViewData["TacGiaID"] = new SelectList(_context.TacGia, "ID", "TacGia", sach.TacGiaID);
			return View(sach);
        }

        // GET: Sach/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sach == null)
            {
                return NotFound();
            }

            var sach = await _context.Sach
                .Include(s => s.NhaSanXuat)
                .Include(s => s.TheLoai)
				.Include(s => s.TacGia)
				.FirstOrDefaultAsync(m => m.ID == id);
            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }

        // POST: Sach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sach == null)
            {
                return Problem("Entity set 'BookStoreDBContext.Sach'  is null.");
            }
            var sach = await _context.Sach.FindAsync(id);
            if (sach != null)
            {
				// Xóa hình ảnh (nếu có)
				if (!string.IsNullOrEmpty(sach.TenSach))
				{
					var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "uploads", sach.AnhBia);
					if (System.IO.File.Exists(imagePath)) System.IO.File.Delete(imagePath);
				}
				_context.Sach.Remove(sach);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SachExists(int id)
        {
          return (_context.Sach?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
