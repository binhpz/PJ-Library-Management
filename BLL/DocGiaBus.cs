using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DocGiaBus
    {
        AppDBContext db = new AppDBContext { };
        public BindingList<DocGia> getList()
        {
            var list = db.DocGia.ToList();
            return new BindingList<DocGia>(list);
        }

        public List<string> add(string ten, DateTime ngaySinh, string diaChi, string cmnd, string sdt, DateTime nhh)
        {
            var errors = new List<string>();
            var exist = db.DocGia.Where(dg => dg.SoCMT == cmnd || dg.SDT == sdt).FirstOrDefault();
            if (exist != null)
            {
                errors.Add("Số cmnd hoặc số điện thoại đã tồn tại!");
                return errors;
            }

            var docgia = new DocGia { };
            docgia.TenDG = ten;
            docgia.NgaySinh = ngaySinh;
            docgia.DiaChi = diaChi;
            docgia.SoCMT = cmnd;
            docgia.SDT = sdt;
            docgia.NgayHetHanThe = nhh;

            db.DocGia.Add(docgia);
            db.SaveChanges();

            return errors;
        }

        public List<string> edit(long maDG, string ten, DateTime ngaySinh, string diaChi, string cmnd, string sdt, DateTime nhh)
        {
            var errors = new List<string>();
            var docgia = db.DocGia.Where(dg => dg.MaDG == maDG).FirstOrDefault();
            if (docgia == null)
            {
                errors.Add("Độc giả không tồn tại!");
                return errors;
            }

            docgia.TenDG = ten;
            docgia.NgaySinh = ngaySinh;
            docgia.DiaChi = diaChi;
            docgia.SoCMT = cmnd;
            docgia.SDT = sdt;
            docgia.NgayHetHanThe = nhh;

            db.SaveChanges();

            return errors;
        }

        public List<string> delete(long maDG)
        {
            var errors = new List<string>();
            var docgia = db.DocGia.Where(dg => dg.MaDG == maDG).FirstOrDefault();
            if (docgia == null)
            {
                errors.Add("Độc giả không tồn tại!");
                return errors;
            }

            db.DocGia.Remove(docgia);

            db.SaveChanges();

            return errors;
        }

        public List<DocGia> search(string tenDocGia, string sdt, string cmnd)
        {
            var exist = db.DocGia.Where(m => m.TenDG.ToLower().Contains(tenDocGia.ToLower()) || m.SDT == sdt || m.SoCMT == cmnd).ToList();
            return exist;
        }
    }

}

