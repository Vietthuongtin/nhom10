using Microsoft.EntityFrameworkCore;

namespace montanbui.Models
{
    public class DataHe : DbContext
    {
        public DataHe(DbContextOptions<DataHe> options)
            : base(options)
        {
        }

        public DbSet<NhanVien> NhanVien { get; set; }
        public DbSet<KhachHang> KhachHang { get; set; }
        public DbSet<NguyenLieu> NguyenLieu { get; set; }
        public DbSet<LoaiMonAn> LoaiMonAn { get; set; }
        public DbSet<MonAn> MonAn { get; set; }
        public DbSet<DonHang> DonHang { get; set; }
        public DbSet<CT_DonHang> CT_DonHang { get; set; }
        public DbSet<DatBan> DatBan { get; set; }
        public DbSet<PhanHoi> PhanHoi { get; set; }
        public DbSet<dangnhap> dangnhap { get; set; }

    }
}
