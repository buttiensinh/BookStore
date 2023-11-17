using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;
using Microsoft.AspNetCore.Authorization;

namespace BookStore.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class DonHang_ChiTietController : Controller
    {
        private readonly BookStoreDBContext _context;

        public DonHang_ChiTietController(BookStoreDBContext context)
        {
            _context = context;
        }

        // GET: DonHang_ChiTiet
        public async Task<IActionResult> Index()
        {
            var bookStoreDBContext = _context.DonHang_ChiTiet.Include(d => d.DonHang).Include(d => d.Sach);
            return View(await bookStoreDBContext.ToListAsync());
        }

        // GET: DonHang_ChiTiet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DonHang_ChiTiet == null)
            {
                return NotFound();
            }

            var donHang_ChiTiet = await _context.DonHang_ChiTiet
                .Include(d => d.DonHang)
                .Include(d => d.Sach)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (donHang_ChiTiet == null)
            {
                return NotFound();
            }

            return View(donHang_ChiTiet);
        }

        // GET: DonHang_ChiTiet/Create
        public IActionResult Create()
        {
            ViewData["DonHangID"] = new SelectList(_context.DonHang, "ID", "ID");
            ViewData["SachID"] = new SelectList(_context.Sach, "ID", "ID");
            return View();
        }

        // POST: DonHang_ChiTiet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DonHangID,SachID,SoLuong,DonGia")] DonHang_ChiTiet donHang_ChiTiet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donHang_ChiTiet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DonHangID"] = new SelectList(_context.DonHang, "ID", "ID", donHang_ChiTiet.DonHangID);
            ViewData["SachID"] = new SelectList(_context.Sach, "ID", "ID", donHang_ChiTiet.SachID);
            return View(donHang_ChiTiet);
        }

        // GET: DonHang_ChiTiet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DonHang_ChiTiet == null)
            {
                return NotFound();
            }

            var donHang_ChiTiet = await _context.DonHang_ChiTiet.FindAsync(id);
            if (donHang_ChiTiet == null)
            {
                return NotFound();
            }
            ViewData["DonHangID"] = new SelectList(_context.DonHang, "ID", "ID", donHang_ChiTiet.DonHangID);
            ViewData["SachID"] = new SelectList(_context.Sach, "ID", "ID", donHang_ChiTiet.SachID);
            return View(donHang_ChiTiet);
        }

        // POST: DonHang_ChiTiet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DonHangID,SachID,SoLuong,DonGia")] DonHang_ChiTiet donHang_ChiTiet)
        {
            if (id != donHang_ChiTiet.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donHang_ChiTiet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonHang_ChiTietExists(donHang_ChiTiet.ID))
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
            ViewData["DonHangID"] = new SelectList(_context.DonHang, "ID", "ID", donHang_ChiTiet.DonHangID);
            ViewData["SachID"] = new SelectList(_context.Sach, "ID", "ID", donHang_ChiTiet.SachID);
            return View(donHang_ChiTiet);
        }

        // GET: DonHang_ChiTiet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DonHang_ChiTiet == null)
            {
                return NotFound();
            }

            var donHang_ChiTiet = await _context.DonHang_ChiTiet
                .Include(d => d.DonHang)
                .Include(d => d.Sach)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (donHang_ChiTiet == null)
            {
                return NotFound();
            }

            return View(donHang_ChiTiet);
        }

        // POST: DonHang_ChiTiet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DonHang_ChiTiet == null)
            {
                return Problem("Entity set 'BookStoreDBContext.DonHang_ChiTiet'  is null.");
            }
            var donHang_ChiTiet = await _context.DonHang_ChiTiet.FindAsync(id);
            if (donHang_ChiTiet != null)
            {
                _context.DonHang_ChiTiet.Remove(donHang_ChiTiet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonHang_ChiTietExists(int id)
        {
          return (_context.DonHang_ChiTiet?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
