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
    public class CT_DonHangController : Controller
    {
        private readonly DataHe _context;

        public CT_DonHangController(DataHe context)
        {
            _context = context;
        }

        // GET: CT_DonHang
        public async Task<IActionResult> Index()
        {
            var dataHe = _context.CT_DonHangs.Include(c => c.DonHang).Include(c => c.MonAn);
            return View(await dataHe.ToListAsync());
        }

        // GET: CT_DonHang/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cT_DonHang = await _context.CT_DonHangs
                .Include(c => c.DonHang)
                .Include(c => c.MonAn)
                .FirstOrDefaultAsync(m => m.MaCT == id);
            if (cT_DonHang == null)
            {
                return NotFound();
            }

            return View(cT_DonHang);
        }

        // GET: CT_DonHang/Create
        public IActionResult Create()
        {
            ViewData["MaDH"] = new SelectList(_context.DonHangs, "MaDH", "TrangThai");
            ViewData["MaMon"] = new SelectList(_context.MonAns, "MaMon", "TenMon");
            return View();
        }

        // POST: CT_DonHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaCT,MaDH,MaMon,SoLuong,DonGia")] CT_DonHang cT_DonHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cT_DonHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaDH"] = new SelectList(_context.DonHangs, "MaDH", "TrangThai", cT_DonHang.MaDH);
            ViewData["MaMon"] = new SelectList(_context.MonAns, "MaMon", "TenMon", cT_DonHang.MaMon);
            return View(cT_DonHang);
        }

        // GET: CT_DonHang/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cT_DonHang = await _context.CT_DonHangs.FindAsync(id);
            if (cT_DonHang == null)
            {
                return NotFound();
            }
            ViewData["MaDH"] = new SelectList(_context.DonHangs, "MaDH", "TrangThai", cT_DonHang.MaDH);
            ViewData["MaMon"] = new SelectList(_context.MonAns, "MaMon", "TenMon", cT_DonHang.MaMon);
            return View(cT_DonHang);
        }

        // POST: CT_DonHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaCT,MaDH,MaMon,SoLuong,DonGia")] CT_DonHang cT_DonHang)
        {
            if (id != cT_DonHang.MaCT)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cT_DonHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CT_DonHangExists(cT_DonHang.MaCT))
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
            ViewData["MaDH"] = new SelectList(_context.DonHangs, "MaDH", "TrangThai", cT_DonHang.MaDH);
            ViewData["MaMon"] = new SelectList(_context.MonAns, "MaMon", "TenMon", cT_DonHang.MaMon);
            return View(cT_DonHang);
        }

        // GET: CT_DonHang/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cT_DonHang = await _context.CT_DonHangs
                .Include(c => c.DonHang)
                .Include(c => c.MonAn)
                .FirstOrDefaultAsync(m => m.MaCT == id);
            if (cT_DonHang == null)
            {
                return NotFound();
            }

            return View(cT_DonHang);
        }

        // POST: CT_DonHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cT_DonHang = await _context.CT_DonHangs.FindAsync(id);
            if (cT_DonHang != null)
            {
                _context.CT_DonHangs.Remove(cT_DonHang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CT_DonHangExists(int id)
        {
            return _context.CT_DonHangs.Any(e => e.MaCT == id);
        }
    }
}
