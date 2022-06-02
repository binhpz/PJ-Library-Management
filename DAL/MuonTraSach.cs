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
    public class MuonTraSach
    {
        [Key]
        [DisplayName("ID")]
        public long ID { get; set; }


        [DisplayName("Mã độc giả")]
        public long MaDG { get; set; }


        [Browsable(false)]
        [ForeignKey("MaDG")] public virtual DocGia DocGia { get; set; }

        
        [DisplayName("Mã thủ thư")]
        public long MaThuThu { get; set; }

        [Browsable(false)]
        [ForeignKey("MaThuThu")] public virtual ThuThu ThuThu { get; set; }

        [DisplayName("Sách")]
        public virtual ICollection<Sach> Sach { get; set; }

        [DisplayName("Ngày mượn")]
        [DataType(DataType.Date)] public DateTime? NgayMuon { get; set; }

        [DisplayName("Ngày hẹn trả")]
        [DataType(DataType.Date)] public DateTime? NgayHenTra { get; set; }

        [DisplayName("Ngày trả")]
        [DataType(DataType.Date)] public DateTime? NgayTra { get; set; }

        [DisplayName("Trạng thái")]
        public TrangThai TrangThai { get; set; }
    }

    public enum TrangThai
    {
        DangMuon,
        DaTra
    }

}
