using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class ThamGia
    {
        public int ID { get; set; }
        [StringLength(100)]
        public string VaiTro { get; set; }
        [StringLength(50)]
        public string ViTri { get; set; }
        //public ICollection<Sach>? Sach { get; set; }
        public ICollection<TacGia>? TacGia { get; set; }
    }
}
