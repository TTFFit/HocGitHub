using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApiApp.Data;

namespace WebApiApp.Models
{
    public class HangHoaModel
    {
        public Guid MaHH { get; set; }
        public string TenHH { get; set; }
        public string Mota { get; set; }
        [Range(0, double.MaxValue)]
        public double DonGia { get; set; }
        public byte GiamGia { get; set; }
        public int? MaLoaiHH { get; set; }
        public string TenLoaiHH { get;set; }
    }
}
