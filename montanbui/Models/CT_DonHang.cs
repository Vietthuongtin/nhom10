using montanbui.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace montanbui.Models
{
    public class CT_DonHang
    {
        [Key]
        public int MaCT { get; set; }

        public int MaDH { get; set; }

        [ForeignKey("MaDH")]
        public DonHang DonHang { get; set; }

        public int MaMon { get; set; }

        [ForeignKey("MaMon")]
        public MonAn MonAn { get; set; }

        [Required]
        [Display(Name = "Số lượng")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0")]
        public int SoLuong { get; set; }

        [Required]
        [Display(Name = "Đơn giá")]
        [DataType(DataType.Currency)]
        public decimal DonGia { get; set; }
    }
}
