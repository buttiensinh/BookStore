using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Sach
    {
        internal object EnrollmentDate;
        public int ID { get; set; }


        [Required(ErrorMessage = "Thể loại không được bỏ trống!")]
        public int TheLoaiID { get; set; }


        [Required(ErrorMessage = "Tên nhà xuất bản không được bỏ trống!")]
        public int NhaSanXuatID { get; set; }

		[Required(ErrorMessage = "Tên tác giả không được bỏ trống!")]
		public int TacGiaID { get; set; }


		[StringLength(250)]
        [Required(ErrorMessage = "Tên sách không được bỏ trống!")]
        public string TenSach { get; set; }


        
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Đơn giá không được bỏ trống!")]
        public int DonGia { get; set; }


        [StringLength(255)]
        public string? AnhBia { get; set; }
		//Tạo trường thông tin mới để lưu dữ liệu ảnh
		[NotMapped]
		[Display(Name = "Hình ảnh sản phẩm")]
		public IFormFile? DuLieuHinhAnh { get; set; }


		/*[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Ngày nhập hàng không được bỏ trống!")]
        public DateTime NgayNhap { get; set; }*/



		[DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Số lượng không được bỏ trống!")]
        public int SoLuong {  get; set; }


        [Column(TypeName = "ntext")]
        [DataType(DataType.MultilineText)]
        public string? MoTa { get; set; }


        public ICollection<DonHang_ChiTiet>? DonHang_ChiTiet { get; set; }
        public TheLoai? TheLoai { get; set; }
        public NhaSanXuat? NhaSanXuat { get; set; }
		public TacGia? TacGia { get; set; }

    }
}
