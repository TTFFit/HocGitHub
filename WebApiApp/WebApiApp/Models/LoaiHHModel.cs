using System.ComponentModel.DataAnnotations;

namespace WebApiApp.Models
{
    public class LoaiHHModel
    {
        [Required]
        [MaxLength(50)]
        public string TenLoaiHH { get; set; }
    }
}
