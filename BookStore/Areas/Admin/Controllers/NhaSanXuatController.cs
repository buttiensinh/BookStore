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
	public class NhaSanXuatController : Controller
    {
        private readonly BookStoreDBContext _context;

        public NhaSanXuatController(BookStoreDBContext context)
        {
            _context = context;
        }

        // GET: NhaSanXuat
        public async Task<IActionResult> Index()
        {
              return _context.NhaSanXuat != null ? 
                          View(await _context.NhaSanXuat.ToListAsync()) :
                          Problem("Entity set 'BookStoreDBContext.NhaSanXuat'  is null.");
        }

        // GET: NhaSanXuat/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NhaSanXuat == null)
            {
                return NotFound();
            }

            var nhaSanXuat = await _context.NhaSanXuat
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nhaSanXuat == null)
            {
                return NotFound();
            }

            return View(nhaSanXuat);
        }

        // GET: NhaSanXuat/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NhaSanXuat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TenNhaSanXuat,DienThoai,DiaChi")] NhaSanXuat nhaSanXuat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhaSanXuat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhaSanXuat);
        }

        // GET: NhaSanXuat/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NhaSanXuat == null)
            {
                return NotFound();
            }

            var nhaSanXuat = await _context.NhaSanXuat.FindAsync(id);
            if (nhaSanXuat == null)
            {
                return NotFound();
            }
            return View(nhaSanXuat);
        }

        // POST: NhaSanXuat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TenNhaSanXuat,DienThoai,DiaChi")] NhaSanXuat nhaSanXuat)
        {
            if (id != nhaSanXuat.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhaSanXuat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhaSanXuatExists(nhaSanXuat.ID))
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
            return View(nhaSanXuat);
        }

        // GET: NhaSanXuat/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NhaSanXuat == null)
            {
                return NotFound();
            }

            var nhaSanXuat = await _context.NhaSanXuat
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nhaSanXuat == null)
            {
                return NotFound();
            }

            return View(nhaSanXuat);
        }

        // POST: NhaSanXuat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NhaSanXuat == null)
            {
                return Problem("Entity set 'BookStoreDBContext.NhaSanXuat'  is null.");
            }
            var nhaSanXuat = await _context.NhaSanXuat.FindAsync(id);
            if (nhaSanXuat != null)
            {
                _context.NhaSanXuat.Remove(nhaSanXuat);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhaSanXuatExists(int id)
        {
          return (_context.NhaSanXuat?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
