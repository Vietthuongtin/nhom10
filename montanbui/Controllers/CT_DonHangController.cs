using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Index()
        {
            var chiTietDonHang = _context.CT_DonHang
                .Include(c => c.DonHang)
                .Include(c => c.MonAn);

            return View(await chiTietDonHang.ToListAsync());
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cT_DonHang = await _context.CT_DonHang
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
            var cT_DonHang = await _context.CT_DonHang.FindAsync(id);
            if (cT_DonHang != null)
            {
                _context.CT_DonHang.Remove(cT_DonHang);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
