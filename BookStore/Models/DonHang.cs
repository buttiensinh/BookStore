using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class DonHang
    {
        public int ID { get; set; }


        [Required(ErrorMessage = "Người dùng không được bỏ trống!")]
        public int NguoiDungID { get; set; }


        [Required(ErrorMessage = "Tình trạng không được bỏ trống!")]
        public int TinhTrangID { get; set; }


        [StringLength(20)]
        [Required(ErrorMessage = "Điện thoại giao hàng không được bỏ trống!")]
        [RegularExpression("[0-9]{10}", ErrorMessage = "Điện thoại phải là 10 chữ số!")]
        public string DienThoaiGiaoHang { get; set; }


        [StringLength(255)]
        [Required(ErrorMessage = "Địa chỉ giao hàng không được bỏ trống!")]
        public string DiaChiGiaoHang { get; set; }

		[Required(ErrorMessage = "Ngày đặt hàng không được bỏ trống!")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayDatHang { get; set; }


        public ICollection<DonHang_ChiTiet>? DonHang_ChiTiet { get; set; }
        public NguoiDung? NguoiDung { get; set; }
        public TinhTrang? TinhTrang { get; set; }
    }
}
