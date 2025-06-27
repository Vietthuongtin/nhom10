using System;
using System.ComponentModel.DataAnnotations;

namespace montanbui.Models
{
    public class NhanVien
    {
        [Key]
        public int MaNV { get; set; }

        [Required(ErrorMessage = "Họ tên không được để trống")]
        [StringLength(100, ErrorMessage = "Họ tên không quá 100 ký tự")]
        [Display(Name = "Họ và tên")]
        public string HoTen { get; set; }

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime? NgaySinh { get; set; }

        [Display(Name = "Giới tính")]
        public string GioiTinh { get; set; }

        [Display(Name = "Địa chỉ")]
        [StringLength(200)]
        public string DiaChi { get; set; }

        [Display(Name = "Số điện thoại")]
        [StringLength(15)]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string SDT { get; set; }

        [Display(Name = "Email")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [Display(Name = "Chức vụ")]
        [StringLength(50)]
        public string ChucVu { get; set; }

        [Display(Name = "Lương")]
        [DataType(DataType.Currency)]
        public decimal? Luong { get; set; }

        [Display(Name = "Ngày vào làm")]
        [DataType(DataType.Date)]
        public DateTime? NgayVaoLam { get; set; }

        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        [StringLength(100)]
        public string MatKhau { get; set; }
    }
}
