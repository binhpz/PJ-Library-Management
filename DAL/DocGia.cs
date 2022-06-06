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
    [Table("DocGia")]
    public class DocGia
    {
        [Key]
        [DisplayName("Mã độc giả")]
        public long MaDG { get; set; }

        [DisplayName("Tên độc giả")]
        public string TenDG { get; set; }

        [DisplayName("Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime? NgaySinh { get; set; }

        [DisplayName("Ngày hết hạn thẻ")]
        [DataType(DataType.Date)]
        public DateTime? NgayHetHanThe { get; set; }

        [DisplayName("Số CMT")]
        public string SoCMT { get; set; }

        [DisplayName("Số điện thoại")]
        public string SDT { get; set; }

        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }
    }
}
