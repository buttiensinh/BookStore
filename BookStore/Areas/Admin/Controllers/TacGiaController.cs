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
	public class TacGiaController : Controller
    {
        private readonly BookStoreDBContext _context;

        public TacGiaController(BookStoreDBContext context)
        {
            _context = context;
        }

        // GET: TacGia
        public async Task<IActionResult> Index()
        {
              return _context.TacGia != null ? 
                          View(await _context.TacGia.ToListAsync()) :
                          Problem("Entity set 'BookStoreDBContext.TacGia'  is null.");
        }

        // GET: TacGia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TacGia == null)
            {
                return NotFound();
            }

            var tacGia = await _context.TacGia
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tacGia == null)
            {
                return NotFound();
            }

            return View(tacGia);
        }

        // GET: TacGia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TacGia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TenTacGia,DienThoai,DiaChi,TieuSu")] TacGia tacGia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tacGia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tacGia);
        }

        // GET: TacGia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TacGia == null)
            {
                return NotFound();
            }

            var tacGia = await _context.TacGia.FindAsync(id);
            if (tacGia == null)
            {
                return NotFound();
            }
            return View(tacGia);
        }

        // POST: TacGia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TenTacGia,DienThoai,DiaChi,TieuSu")] TacGia tacGia)
        {
            if (id != tacGia.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tacGia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TacGiaExists(tacGia.ID))
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
            return View(tacGia);
        }

        // GET: TacGia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TacGia == null)
            {
                return NotFound();
            }

            var tacGia = await _context.TacGia
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tacGia == null)
            {
                return NotFound();
            }

            return View(tacGia);
        }

        // POST: TacGia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TacGia == null)
            {
                return Problem("Entity set 'BookStoreDBContext.TacGia'  is null.");
            }
            var tacGia = await _context.TacGia.FindAsync(id);
            if (tacGia != null)
            {
                _context.TacGia.Remove(tacGia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TacGiaExists(int id)
        {
          return (_context.TacGia?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
