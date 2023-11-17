using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class TacGia
    {
        public int ID { get; set; }
         

        [StringLength(50)]
        [Required(ErrorMessage = "Tên tác giả không được bỏ trống!")]
        public string TenTacGia { get; set; }


        [StringLength(20)]
        [Required(ErrorMessage = "Điện thoại giao hàng không được bỏ trống!")]
        [RegularExpression("[0-9]{10}", ErrorMessage = "Điện thoại phải là 10 chữ số!")]
        public string? DienThoai { get; set; }


        [StringLength(255)]
        [Required(ErrorMessage = "Địa chỉ giao hàng không được bỏ trống!")]
        public string? DiaChi { get; set; }


        [Column(TypeName = "ntext")]
        public string? TieuSu { get; set; }

		public ICollection<Sach>? Sach { get; set; }
	}
}
