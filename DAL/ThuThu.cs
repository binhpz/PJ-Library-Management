using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ThuThu
    {
        [Key]
        public long MaThuThu { get; set; }

        public string TenThuThu { get; set; }
        public string TaiKhoan { get; set; }

        public string MatKhau { get; set; }
    }
}
