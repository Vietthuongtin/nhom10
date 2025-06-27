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
    public class NguyenLieuxController : Controller
    {
        private readonly DataHe _context;

        public NguyenLieuxController(DataHe context)
        {
            _context = context;
        }

        // GET: NguyenLieux
        public async Task<IActionResult> Index()
        {
            return View(await _context.NguyenLieus.ToListAsync());
        }

        // GET: NguyenLieux/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguyenLieu = await _context.NguyenLieus
                .FirstOrDefaultAsync(m => m.MaNL == id);
            if (nguyenLieu == null)
            {
                return NotFound();
            }

            return View(nguyenLieu);
        }

        // GET: NguyenLieux/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NguyenLieux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNL,TenNL,DonViTinh,SoLuongTon,DonGia,NgayNhap,HanSuDung,TrangThai")] NguyenLieu nguyenLieu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nguyenLieu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nguyenLieu);
        }

        // GET: NguyenLieux/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguyenLieu = await _context.NguyenLieus.FindAsync(id);
            if (nguyenLieu == null)
            {
                return NotFound();
            }
            return View(nguyenLieu);
        }

        // POST: NguyenLieux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaNL,TenNL,DonViTinh,SoLuongTon,DonGia,NgayNhap,HanSuDung,TrangThai")] NguyenLieu nguyenLieu)
        {
            if (id != nguyenLieu.MaNL)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nguyenLieu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NguyenLieuExists(nguyenLieu.MaNL))
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
            return View(nguyenLieu);
        }

        // GET: NguyenLieux/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguyenLieu = await _context.NguyenLieus
                .FirstOrDefaultAsync(m => m.MaNL == id);
            if (nguyenLieu == null)
            {
                return NotFound();
            }

            return View(nguyenLieu);
        }

        // POST: NguyenLieux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nguyenLieu = await _context.NguyenLieus.FindAsync(id);
            if (nguyenLieu != null)
            {
                _context.NguyenLieus.Remove(nguyenLieu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NguyenLieuExists(int id)
        {
            return _context.NguyenLieus.Any(e => e.MaNL == id);
        }
    }
}
