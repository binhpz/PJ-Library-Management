using DAL;
using Microsoft.CodeAnalysis.Differencing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SachBus
    {
        AppDBContext db = new AppDBContext { };
        TheLoaiBus theLoaiBus = new TheLoaiBus { };

        public BindingList<Sach> getList()
        {
            var list = db.Sach.ToList();
            return new BindingList<Sach>(list);
        }

        public List<string> Create(
            string tenSach,
            string tenTacGia,
            string nhaXuatBan,
            int namXuatBan,
            int soLuong,
            long maTheLoai)
        {
            var errors = new List<string>();
            var theLoai = theLoaiBus.findByMaLoaiSach(maTheLoai);
            if (theLoai == null)
            {
                errors.Add("Thể loại không tồn tại!");
                return errors;
            }

            var isExist = isExistName(tenSach);
            if (isExist)
            {
                errors.Add("Sách đã tồn tại!");
                return errors;
            }

            var sach = new Sach { };
            sach.TenSach = tenSach;
            sach.TenTacGia = tenTacGia;
            sach.NhaXuatBan = nhaXuatBan;
            sach.NamXuatBan = namXuatBan;
            sach.SoLuong = soLuong;
            sach.LoaiSach = theLoai;

            var result = db.Sach.Add(sach);
            if (result == null)
            {
                errors.Add("Lỗi thêm sách!");
            }
            db.SaveChanges();

            return errors;
        }
        public void delete(long id)
        {
            var s = db.Sach.Where(m => m.MaSach == id).FirstOrDefault();
            if (s != null)
            {
                db.Sach.Remove(s);
                db.SaveChanges();
            }

        }
             /*     public abstract List<string> edit(string tenSach, string tenTacGia);
             var errors = new List<string>();
             var exist = isExistName(tenSach);*/
        private bool isExistName(string name)
        {
            var exist = db.Sach.Where(m => m.TenSach== name).FirstOrDefault();
            if (exist != null)
            {
                return true;
            }
            return false;
        }
    }
}
