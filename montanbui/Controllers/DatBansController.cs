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
    public class DatBansController : Controller
    {
        private readonly DataHe _context;

        public DatBansController(DataHe context)
        {
            _context = context;
        }

        // GET: DatBans
        public async Task<IActionResult> Index()
        {
            var dataHe = _context.DatBan.Include(d => d.KhachHang);
            return View(await dataHe.ToListAsync());
        }

        // GET: DatBans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datBan = await _context.DatBan
                .Include(d => d.KhachHang)
                .FirstOrDefaultAsync(m => m.MaDatBan == id);
            if (datBan == null)
            {
                return NotFound();
            }

            return View(datBan);
        }

        // GET: DatBans/Create
        public IActionResult Create()
        {
            ViewData["MaKH"] = new SelectList(_context.KhachHang, "MaKH", "HoTen");
            return View();
        }

        // POST: DatBans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDatBan,MaKH,NgayDat,ThoiGianDen,SoNguoi,TrangThai,TienCoc,GhiChu")] DatBan datBan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(datBan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKH"] = new SelectList(_context.KhachHang, "MaKH", "HoTen", datBan.MaKH);
            return View(datBan);
        }

        // GET: DatBans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datBan = await _context.DatBan.FindAsync(id);
            if (datBan == null)
            {
                return NotFound();
            }
            ViewData["MaKH"] = new SelectList(_context.KhachHang, "MaKH", "HoTen", datBan.MaKH);
            return View(datBan);
        }

        // POST: DatBans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaDatBan,MaKH,NgayDat,ThoiGianDen,SoNguoi,TrangThai,TienCoc,GhiChu")] DatBan datBan)
        {
            if (id != datBan.MaDatBan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(datBan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatBanExists(datBan.MaDatBan))
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
            ViewData["MaKH"] = new SelectList(_context.KhachHang, "MaKH", "HoTen", datBan.MaKH);
            return View(datBan);
        }

        // GET: DatBans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datBan = await _context.DatBan
                .Include(d => d.KhachHang)
                .FirstOrDefaultAsync(m => m.MaDatBan == id);
            if (datBan == null)
            {
                return NotFound();
            }

            return View(datBan);
        }

        // POST: DatBans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var datBan = await _context.DatBan.FindAsync(id);
            if (datBan != null)
            {
                _context.DatBan.Remove(datBan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatBanExists(int id)
        {
            return _context.DatBan.Any(e => e.MaDatBan == id);
        }
    }
}
