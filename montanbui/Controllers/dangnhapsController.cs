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
    public class dangnhapsController : Controller
    {
        private readonly DataHe _context;

        public dangnhapsController(DataHe context)
        {
            _context = context;
        }

        // GET: dangnhaps
        public async Task<IActionResult> Index()
        {
            return View(await _context.dangnhap.ToListAsync());
        }

        // GET: dangnhaps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dangnhap = await _context.dangnhap
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dangnhap == null)
            {
                return NotFound();
            }

            return View(dangnhap);
        }

        // GET: dangnhaps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: dangnhaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenDangNhap,MatKhau")] dangnhap dangnhap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dangnhap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dangnhap);
        }

        // GET: dangnhaps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dangnhap = await _context.dangnhap.FindAsync(id);
            if (dangnhap == null)
            {
                return NotFound();
            }
            return View(dangnhap);
        }

        // POST: dangnhaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenDangNhap,MatKhau")] dangnhap dangnhap)
        {
            if (id != dangnhap.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dangnhap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!dangnhapExists(dangnhap.Id))
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
            return View(dangnhap);
        }

        // GET: dangnhaps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dangnhap = await _context.dangnhap
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dangnhap == null)
            {
                return NotFound();
            }

            return View(dangnhap);
        }

        // POST: dangnhaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dangnhap = await _context.dangnhap.FindAsync(id);
            if (dangnhap != null)
            {
                _context.dangnhap.Remove(dangnhap);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool dangnhapExists(int id)
        {
            return _context.dangnhap.Any(e => e.Id == id);
        }
    }
}
