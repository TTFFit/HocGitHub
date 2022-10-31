
using System;

namespace WebApiApp.Data
{
    public class DonHangChiTiet
    {
        public Guid MaDonHang { get; set; }
        public Guid MaHH { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public byte GiamGia { get; set; }

        public DonHang DonHang { get; set; }
        public HangHoa HangHoa { get; set; }
    }
}
