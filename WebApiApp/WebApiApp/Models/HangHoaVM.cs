using System.ComponentModel.DataAnnotations;

namespace WebApiApp.Models
{
    public class HangHoaVM
    {
        [Required]
        public string TenHH { get; set; }
        public string Mota { get; set; }
        public double DonGia { get; set; }
        public byte GiamGia { get; set; }

        [Required]
        public int MaLoaiHH { get; set; }
    }
}
