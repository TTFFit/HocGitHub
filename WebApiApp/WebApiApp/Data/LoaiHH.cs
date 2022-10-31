using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiApp.Data
{
    [Table("LoaiHH")]
    public class LoaiHH
    {
        [Key]
        public int MaLoaiHH { get; set; }
        [Required]
        [MaxLength(50)]
        public string TenLoaiHH { get; set; }

        public virtual ICollection<HangHoa> HangHoas { get; set; }
    }
}
