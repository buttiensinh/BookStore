namespace BookStore.Models
{
    public class DonHang_ChiTiet
    {
        public int ID { get; set; }
        public int DonHangID { get; set; }
        public int SachID { get; set; }
        public short SoLuong { get; set; }
        public int DonGia { get; set; }
        public DonHang? DonHang { get; set; }
        public Sach? Sach { get; set; }
    }
}
