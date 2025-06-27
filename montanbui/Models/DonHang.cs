using montanbui.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace montanbui.Models
{
    public class DonHang
    {
        [Key]
        public int MaDH { get; set; }

        [Display(Name = "Khách hàng")]
        public int? MaKH { get; set; }

        [ForeignKey("MaKH")]
        public KhachHang KhachHang { get; set; }

        [Display(Name = "Nhân viên")]
        public int? MaNV { get; set; }

        [ForeignKey("MaNV")]
        public NhanVien NhanVien { get; set; }

        [Required]
        [Display(Name = "Ngày đặt")]
        public DateTime NgayDat { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Trạng thái")]
        public string TrangThai { get; set; } = "Đang chế biến";

        [Display(Name = "Tổng tiền")]
        [DataType(DataType.Currency)]
        public decimal TongTien { get; set; }

        [Display(Name = "Ghi chú")]
        [StringLength(200)]
        public string GhiChu { get; set; }
    }
}
