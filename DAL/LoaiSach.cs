using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("LoaiSach")]
    public class LoaiSach
    {
        [Key]
        [DisplayName("Mã loại sách")]
        public long MaLoaiSach { get; set; }

        [DisplayName("Tên loại sách")]
        public string TenLoaiSach { get; set; }

        [Browsable(false)]
        public virtual ICollection<Sach> Sach { get; set; }
    }
}
