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
    [Table("Sach")]
    public class Sach
    {
        [Key]
        [DisplayName("Mã sách")]
        public long MaSach { get; set; }

        [DisplayName("Tên sách")]

        public string TenSach { get; set; }


        [DisplayName("Tên tác giả")]
        public string TenTacGia { get; set; }


        [DisplayName("Nhà xuất bản")]
        public string NhaXuatBan { get; set; }

        [DisplayName("Năm xuất bản")]
        public int NamXuatBan { get; set; }

        [DisplayName("Số lượng")]
        public int SoLuong { get; set; }

        [Browsable(false)]
        public ICollection<MuonTraSach> MuonTraSach { get; set; }

        [Browsable(false)]
        [ForeignKey("MaLoaiSach")] public virtual LoaiSach LoaiSach { get; set; }

        [Browsable(false)]
        public long MaLoaiSach { get; set; }
    }
}
