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
	public class ThamGiaController : Controller
    {
        private readonly BookStoreDBContext _context;

        public ThamGiaController(BookStoreDBContext context)
        {
            _context = context;
        }

        // GET: ThamGia
        public async Task<IActionResult> Index()
        {
              return _context.ThamGia != null ? 
                          View(await _context.ThamGia.ToListAsync()) :
                          Problem("Entity set 'BookStoreDBContext.ThamGia'  is null.");
        }

        // GET: ThamGia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ThamGia == null)
            {
                return NotFound();
            }

            var thamGia = await _context.ThamGia
                .FirstOrDefaultAsync(m => m.ID == id);
            if (thamGia == null)
            {
                return NotFound();
            }

            return View(thamGia);
        }

        // GET: ThamGia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ThamGia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,VaiTro,ViTri")] ThamGia thamGia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thamGia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thamGia);
        }

        // GET: ThamGia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ThamGia == null)
            {
                return NotFound();
            }

            var thamGia = await _context.ThamGia.FindAsync(id);
            if (thamGia == null)
            {
                return NotFound();
            }
            return View(thamGia);
        }

        // POST: ThamGia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,VaiTro,ViTri")] ThamGia thamGia)
        {
            if (id != thamGia.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thamGia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThamGiaExists(thamGia.ID))
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
            return View(thamGia);
        }

        // GET: ThamGia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ThamGia == null)
            {
                return NotFound();
            }

            var thamGia = await _context.ThamGia
                .FirstOrDefaultAsync(m => m.ID == id);
            if (thamGia == null)
            {
                return NotFound();
            }

            return View(thamGia);
        }

        // POST: ThamGia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ThamGia == null)
            {
                return Problem("Entity set 'BookStoreDBContext.ThamGia'  is null.");
            }
            var thamGia = await _context.ThamGia.FindAsync(id);
            if (thamGia != null)
            {
                _context.ThamGia.Remove(thamGia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThamGiaExists(int id)
        {
          return (_context.ThamGia?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
