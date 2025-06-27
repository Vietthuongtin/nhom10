using montanbui.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace montanbui.Models
{
    public class MonAn
    {
        [Key]
        public int MaMon { get; set; }

        [Required(ErrorMessage = "Tên món không được để trống")]
        [StringLength(100)]
        [Display(Name = "Tên món")]
        public string TenMon { get; set; }

        [Display(Name = "Loại món")]
        public int? MaLoai { get; set; }

        [ForeignKey("MaLoai")]
        public LoaiMonAn LoaiMonAn { get; set; }

        [Required(ErrorMessage = "Giá bán không được để trống")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá bán phải lớn hơn 0")]
        [Display(Name = "Giá bán")]
        [DataType(DataType.Currency)]
        public decimal GiaBan { get; set; }

        [Display(Name = "Mô tả")]
        [StringLength(200)]
        public string MoTa { get; set; }

        [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }
    }
}
