using System.ComponentModel.DataAnnotations;

namespace montanbui.Models
{
    public class LoaiMonAn
    {
        [Key]
        public int MaLoai { get; set; }

        [Required(ErrorMessage = "Tên loại không được để trống")]
        [StringLength(100)]
        [Display(Name = "Tên loại món")]
        public string TenLoai { get; set; }

        [Display(Name = "Mô tả")]
        [StringLength(200)]
        public string MoTa { get; set; }
    }
}
