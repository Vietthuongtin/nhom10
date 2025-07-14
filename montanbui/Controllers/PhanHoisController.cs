using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using montanbui.Models;

namespace montanbui.Controllers
{
    public class PhanHoisController : Controller
    {
        private readonly DataHe _context;

        public PhanHoisController(DataHe context)
        {
            _context = context;
        }

        // GET: PhanHois
        public async Task<IActionResult> Index()
        {
            var dataHe = _context.PhanHoi.Include(p => p.KhachHang);
            return View(await dataHe.ToListAsync());
        }

        // GET: PhanHois/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanHoi = await _context.PhanHoi
                .Include(p => p.KhachHang)
                .FirstOrDefaultAsync(m => m.MaPH == id);
            if (phanHoi == null)
            {
                return NotFound();
            }

            return View(phanHoi);
        }

        // GET: PhanHois/Create
        public IActionResult Create()
        {
            ViewData["MaKH"] = new SelectList(_context.KhachHang, "MaKH", "HoTen");
            return View();
        }

        // POST: PhanHois/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaPH,MaKH,NoiDung,DiemDanhGia,NgayPH")] PhanHoi phanHoi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phanHoi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKH"] = new SelectList(_context.KhachHang, "MaKH", "HoTen", phanHoi.MaKH);
            return View(phanHoi);
        }

        // GET: PhanHois/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanHoi = await _context.PhanHoi.FindAsync(id);
            if (phanHoi == null)
            {
                return NotFound();
            }
            ViewData["MaKH"] = new SelectList(_context.KhachHang, "MaKH", "HoTen", phanHoi.MaKH);
            return View(phanHoi);
        }

        // POST: PhanHois/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaPH,MaKH,NoiDung,DiemDanhGia,NgayPH")] PhanHoi phanHoi)
        {
            if (id != phanHoi.MaPH)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phanHoi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhanHoiExists(phanHoi.MaPH))
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
            ViewData["MaKH"] = new SelectList(_context.KhachHang, "MaKH", "HoTen", phanHoi.MaKH);
            return View(phanHoi);
        }

        // GET: PhanHois/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanHoi = await _context.PhanHoi
                .Include(p => p.KhachHang)
                .FirstOrDefaultAsync(m => m.MaPH == id);
            if (phanHoi == null)
            {
                return NotFound();
            }

            return View(phanHoi);
        }

        // POST: PhanHois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phanHoi = await _context.PhanHoi.FindAsync(id);
            if (phanHoi != null)
            {
                _context.PhanHoi.Remove(phanHoi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhanHoiExists(int id)
        {
            return _context.PhanHoi.Any(e => e.MaPH == id);
        }
    }
}
