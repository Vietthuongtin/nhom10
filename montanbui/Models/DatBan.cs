using montanbui.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace montanbui.Models
{
    public class DatBan
    {
        [Key]
        public int MaDatBan { get; set; }

        public int? MaKH { get; set; }

        [ForeignKey("MaKH")]
        public KhachHang KhachHang { get; set; }

        [Required]
        [Display(Name = "Ngày đặt")]
        public DateTime NgayDat { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Thời gian đến")]
        public DateTime ThoiGianDen { get; set; }

        [Required]
        [Display(Name = "Số người")]
        [Range(1, 20, ErrorMessage = "Số người từ 1 đến 20")]
        public int SoNguoi { get; set; }

        [Required]
        [Display(Name = "Trạng thái")]
        public string TrangThai { get; set; } = "Đã đặt";

        [Display(Name = "Tiền cọc")]
        [DataType(DataType.Currency)]
        public decimal TienCoc { get; set; } = 0;

        [Display(Name = "Ghi chú")]
        [StringLength(200)]
        public string GhiChu { get; set; }
    }
}
