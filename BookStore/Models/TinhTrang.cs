using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class TinhTrang
    {
        public int ID { get; set; }


        [StringLength(255)]
        [Required(ErrorMessage = "Mô tả không được bỏ trống!")]
        public string MoTa { get; set; }

        public ICollection<DonHang>? DonHang { get; set; }
    }
}
