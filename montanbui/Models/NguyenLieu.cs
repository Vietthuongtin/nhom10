using System;
using System.ComponentModel.DataAnnotations;

namespace montanbui.Models
{
    public class NguyenLieu
    {
        [Key]
        public int MaNL { get; set; }

        [Required(ErrorMessage = "Tên nguyên liệu không được để trống")]
        [StringLength(100)]
        [Display(Name = "Tên nguyên liệu")]
        public string TenNL { get; set; }

        [Display(Name = "Đơn vị tính")]
        [StringLength(20)]
        public string DonViTinh { get; set; }

        [Display(Name = "Số lượng tồn")]
        public int SoLuongTon { get; set; }

        [Display(Name = "Đơn giá")]
        [DataType(DataType.Currency)]
        public decimal DonGia { get; set; }

        [Display(Name = "Ngày nhập")]
        [DataType(DataType.Date)]
        public DateTime NgayNhap { get; set; } = DateTime.Now;

        [Display(Name = "Hạn sử dụng")]
        [DataType(DataType.Date)]
        public DateTime? HanSuDung { get; set; }

        [Display(Name = "Trạng thái")]
        public string TrangThai { get; set; }
    }
}
