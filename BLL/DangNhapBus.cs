using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DangNhapBus
    {
        private AppDBContext db = new AppDBContext();

        public bool Login(string username, string password)
        {
            var exist = db.ThuThu.Where(t => t.TaiKhoan == username && t.MatKhau == password).FirstOrDefault();
            if (exist != null)
            {
                return true;
            }
            return false;
        }

    }
}
