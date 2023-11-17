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
	public class DonHangController : Controller
    {
        private readonly BookStoreDBContext _context;

        public DonHangController(BookStoreDBContext context)
        {
            _context = context;
        }

        // GET: DonHang
        public async Task<IActionResult> Index()
        {
            var bookStoreDBContext = _context.DonHang.Include(d => d.NguoiDung).Include(d => d.TinhTrang);
            return View(await bookStoreDBContext.ToListAsync());
        }

        // GET: DonHang/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DonHang == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHang
                .Include(d => d.NguoiDung)
                .Include(d => d.TinhTrang)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (donHang == null)
            {
                return NotFound();
            }

            return View(donHang);
        }

        // GET: DonHang/Create
        public IActionResult Create()
        {
            ViewData["NguoiDungID"] = new SelectList(_context.NguoiDung, "ID", "HoVaTen");
            ViewData["TinhTrangID"] = new SelectList(_context.TinhTrang, "ID", "MoTa");
            return View();
        }

        // POST: DonHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NguoiDungID,TinhTrangID,DienThoaiGiaoHang,DiaChiGiaoHang,NgayDatHang")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NguoiDungID"] = new SelectList(_context.NguoiDung, "ID", "HoVaTen", donHang.NguoiDungID);
            ViewData["TinhTrangID"] = new SelectList(_context.TinhTrang, "ID", "MoTa", donHang.TinhTrangID);
            return View(donHang);
        }

        // GET: DonHang/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DonHang == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHang.FindAsync(id);
            if (donHang == null)
            {
                return NotFound();
            }
            ViewData["NguoiDungID"] = new SelectList(_context.NguoiDung, "ID", "HoVaTen", donHang.NguoiDungID);
            ViewData["TinhTrangID"] = new SelectList(_context.TinhTrang, "ID", "MoTa", donHang.TinhTrangID);
            return View(donHang);
        }

        // POST: DonHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NguoiDungID,TinhTrangID,DienThoaiGiaoHang,DiaChiGiaoHang,NgayDatHang")] DonHang donHang)
        {
            if (id != donHang.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonHangExists(donHang.ID))
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
            ViewData["NguoiDungID"] = new SelectList(_context.NguoiDung, "ID", "HoVaTen", donHang.NguoiDungID);
            ViewData["TinhTrangID"] = new SelectList(_context.TinhTrang, "ID", "MoTa", donHang.TinhTrangID);
            return View(donHang);
        }

        // GET: DonHang/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DonHang == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHang
                .Include(d => d.NguoiDung)
                .Include(d => d.TinhTrang)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (donHang == null)
            {
                return NotFound();
            }

            return View(donHang);
        }

        // POST: DonHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DonHang == null)
            {
                return Problem("Entity set 'BookStoreDBContext.DonHang'  is null.");
            }
            var donHang = await _context.DonHang.FindAsync(id);
            if (donHang != null)
            {
                _context.DonHang.Remove(donHang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonHangExists(int id)
        {
          return (_context.DonHang?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
