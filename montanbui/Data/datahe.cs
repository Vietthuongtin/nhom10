using Microsoft.EntityFrameworkCore;

namespace montanbui.Models
{
    public class DataHe : DbContext
    {
        public DataHe(DbContextOptions<DataHe> options)
            : base(options)
        {
        }

        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<NguyenLieu> NguyenLieus { get; set; }
        public DbSet<LoaiMonAn> LoaiMonAns { get; set; }
        public DbSet<MonAn> MonAns { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<CT_DonHang> CT_DonHangs { get; set; }
        public DbSet<DatBan> DatBans { get; set; }
        public DbSet<PhanHoi> PhanHois { get; set; }
    }
}
