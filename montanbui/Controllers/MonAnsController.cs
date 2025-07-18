﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using montanbui.Models;

namespace montanbui.Controllers
{
    public class MonAnsController : Controller
    {
        private readonly DataHe _context;

        public MonAnsController(DataHe context)
        {
            _context = context;
        }

        // GET: MonAns
        public async Task<IActionResult> Index()
        {
            var dataHe = _context.MonAn.Include(m => m.LoaiMonAn);
            return View(await dataHe.ToListAsync());
        }

        // GET: MonAns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monAn = await _context.MonAn
                .Include(m => m.LoaiMonAn)
                .FirstOrDefaultAsync(m => m.MaMon == id);
            if (monAn == null)
            {
                return NotFound();
            }

            return View(monAn);
        }

        // GET: MonAns/Create
        public IActionResult Create()
        {
            ViewData["MaLoai"] = new SelectList(_context.LoaiMonAn, "MaLoai", "TenLoai");
            return View();
        }

        // POST: MonAns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaMon,TenMon,MaLoai,GiaBan,MoTa,HinhAnh")] MonAn monAn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monAn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLoai"] = new SelectList(_context.LoaiMonAn, "MaLoai", "TenLoai", monAn.MaLoai);
            return View(monAn);
        }

        // GET: MonAns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monAn = await _context.MonAn.FindAsync(id);
            if (monAn == null)
            {
                return NotFound();
            }
            ViewData["MaLoai"] = new SelectList(_context.LoaiMonAn, "MaLoai", "TenLoai", monAn.MaLoai);
            return View(monAn);
        }

        // POST: MonAns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaMon,TenMon,MaLoai,GiaBan,MoTa,HinhAnh")] MonAn monAn)
        {
            if (id != monAn.MaMon)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monAn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonAnExists(monAn.MaMon))
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
            ViewData["MaLoai"] = new SelectList(_context.LoaiMonAn, "MaLoai", "TenLoai", monAn.MaLoai);
            return View(monAn);
        }

        // GET: MonAns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monAn = await _context.MonAn
                .Include(m => m.LoaiMonAn)
                .FirstOrDefaultAsync(m => m.MaMon == id);
            if (monAn == null)
            {
                return NotFound();
            }

            return View(monAn);
        }

        // POST: MonAns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monAn = await _context.MonAn.FindAsync(id);
            if (monAn != null)
            {
                _context.MonAn.Remove(monAn);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonAnExists(int id)
        {
            return _context.MonAn.Any(e => e.MaMon == id);
        }
        public class MonAnController : Controller
        {
            public IActionResult Index()
            {
                return View();
            }
        }   
        [HttpPost]
        public IActionResult Mua(int id, int SoLuong)
        {
            var mon = _context.MonAn.Find(id);
            if (mon == null)
            {
                return NotFound();
            }

            var donHang = new DonHang
            {
                MaKH = 1, // đảm bảo tồn tại MaKH = 1
                MaNV = 1, // đảm bảo tồn tại MaNV = 1
                NgayDat = DateTime.Now,
                TrangThai = "Chờ xử lý",
                TongTien = mon.GiaBan *SoLuong,
                GhiChu = ""
            };

            _context.DonHang.Add(donHang);
            _context.SaveChanges(); // ❗ Cần dòng này trước để có donHang.MaDH

            var ct = new CT_DonHang
            {
                MaDH = donHang.MaDH,
                MaMon = mon.MaMon,
                SoLuong = SoLuong,
                DonGia = mon.GiaBan
            };
            TempData["SuccessMessage"] = "🛒 Mua hàng thành công!";
            return RedirectToAction("Index");


            _context.CT_DonHang.Add(ct);
            _context.SaveChanges();

            return RedirectToAction("Index");
            
            
        }


    }

}

