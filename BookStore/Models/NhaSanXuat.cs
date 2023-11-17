using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class NhaSanXuat
    {
        public int ID { get; set; }


        [StringLength(250)]
        [Required(ErrorMessage = "Tên nhà xuất bản không được bỏ trống!")]
        public string TenNhaSanXuat { get; set; }


        [StringLength(20)]
        [Required(ErrorMessage = "Điện thoại giao hàng không được bỏ trống!")]
        [RegularExpression("[0-9]{10}", ErrorMessage = "Điện thoại phải là 10 chữ số!")]
        public string? DienThoai { get; set; }


        [StringLength(255)]
        [Required(ErrorMessage = "Địa chỉ giao hàng không được bỏ trống!")]
        public string? DiaChi { get; set; }


        public ICollection<Sach>? Sach { get; set; }
    }
}
