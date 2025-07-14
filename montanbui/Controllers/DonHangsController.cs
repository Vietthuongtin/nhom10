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
    public class DonHangsController : Controller
    {
        private readonly DataHe _context;

        public DonHangsController(DataHe context)
        {
            _context = context;
        }

        // GET: DonHangs
        public async Task<IActionResult> Index()
        {
            var dataHe = _context.DonHang.Include(d => d.KhachHang).Include(d => d.NhanVien);
            return View(await dataHe.ToListAsync());
        }

        // GET: DonHangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHang
                .Include(d => d.KhachHang)
                .Include(d => d.NhanVien)
                .FirstOrDefaultAsync(m => m.MaDH == id);
            if (donHang == null)
            {
                return NotFound();
            }

            return View(donHang);
        }

        // GET: DonHangs/Create
        public IActionResult Create()
        {
            ViewData["MaKH"] = new SelectList(_context.KhachHang, "MaKH", "HoTen");
            ViewData["MaNV"] = new SelectList(_context.NhanVien, "MaNV", "HoTen");
            return View();
        }

        // POST: DonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDH,MaKH,MaNV,NgayDat,TrangThai,TongTien,GhiChu")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKH"] = new SelectList(_context.KhachHang, "MaKH", "HoTen", donHang.MaKH);
            ViewData["MaNV"] = new SelectList(_context.NhanVien, "MaNV", "HoTen", donHang.MaNV);
            return View(donHang);
        }

        // GET: DonHangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHang.FindAsync(id);
            if (donHang == null)
            {
                return NotFound();
            }
            ViewData["MaKH"] = new SelectList(_context.KhachHang, "MaKH", "HoTen", donHang.MaKH);
            ViewData["MaNV"] = new SelectList(_context.NhanVien, "MaNV", "HoTen", donHang.MaNV);
            return View(donHang);
        }

        // POST: DonHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaDH,MaKH,MaNV,NgayDat,TrangThai,TongTien,GhiChu")] DonHang donHang)
        {
            if (id != donHang.MaDH)
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
                    if (!DonHangExists(donHang.MaDH))
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
            ViewData["MaKH"] = new SelectList(_context.KhachHang, "MaKH", "HoTen", donHang.MaKH);
            ViewData["MaNV"] = new SelectList(_context.NhanVien, "MaNV", "HoTen", donHang.MaNV);
            return View(donHang);
        }

        // GET: DonHangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHang
                .Include(d => d.KhachHang)
                .Include(d => d.NhanVien)
                .FirstOrDefaultAsync(m => m.MaDH == id);
            if (donHang == null)
            {
                return NotFound();
            }

            return View(donHang);
        }

        // POST: DonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
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
            return _context.DonHang.Any(e => e.MaDH == id);
        }
        [HttpPost]
        public async Task<IActionResult> Mua(int maMon, decimal giaBan)
        {
            // Giả sử MaKH = 1, MaNV = 1 để test
            var hoaDon = new DonHang
            {
                MaKH = 1,
                MaNV = 1,
                NgayDat = DateTime.Now,
                TrangThai = "Chờ xác nhận",
                TongTien = giaBan,
                GhiChu = "",
            };

            _context.DonHang.Add(hoaDon);
            await _context.SaveChangesAsync();

            var chiTiet = new CT_DonHang
            {
                MaDH = hoaDon.MaDH,
                MaMon = maMon,
                SoLuong = 1,
                DonGia = giaBan
            };

            _context.CT_DonHang.Add(chiTiet);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "MonAns");
        }

    }
}
