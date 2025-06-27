using montanbui.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace montanbui.Models
{
    public class PhanHoi
    {
        [Key]
        public int MaPH { get; set; }

        public int? MaKH { get; set; }

        [ForeignKey("MaKH")]
        public KhachHang KhachHang { get; set; }

        [Required]
        [Display(Name = "Nội dung")]
        [StringLength(500)]
        public string NoiDung { get; set; }

        [Required]
        [Display(Name = "Điểm đánh giá")]
        [Range(1, 5, ErrorMessage = "Điểm từ 1 đến 5")]
        public int DiemDanhGia { get; set; } = 5;

        [Required]
        [Display(Name = "Ngày phản hồi")]
        public DateTime NgayPH { get; set; } = DateTime.Now;
    }
}
