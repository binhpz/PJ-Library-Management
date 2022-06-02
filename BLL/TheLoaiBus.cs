using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class TheLoaiBus
    {
        private AppDBContext db = new AppDBContext { };
       public BindingList<LoaiSach> getList()
        {
            var list = db.LoaiSach.ToList();
            return new BindingList<LoaiSach>(list);
        }

        public List<LoaiSach> getAll()
        {
            return db.LoaiSach.ToList();
        }


        public bool add(string tenTheLoai)
        {
            var exist = db.LoaiSach.Where(m => m.TenLoaiSach == tenTheLoai).FirstOrDefault();
            if (exist == null)
            {
                var loaiSach = new LoaiSach();
                loaiSach.TenLoaiSach = tenTheLoai;

                var result = db.LoaiSach.Add(loaiSach);
                db.SaveChanges();

                return true;
            }
            return false;
        }

        public void delete(long id)
        {
            var ls = db.LoaiSach.Where(m => m.MaLoaiSach == id).FirstOrDefault();
            if (ls != null)
            {
                db.LoaiSach.Remove(ls);
                db.SaveChanges();
            }
           
        }

        public List<string> edit(long id, string tenTL)
        {
            var errors = new List<string>();
            var exist = isExistName(tenTL);
            if(exist)
            {
                errors.Add("Thể loại đã tồn tại!");
            }
            
            if(errors.Count <= 0)
            {
                var ls = db.LoaiSach.Where(m => m.MaLoaiSach == id).FirstOrDefault();
                if (ls != null)
                {
                    ls.TenLoaiSach = tenTL;
                    db.SaveChanges();
                }
            }
          
            return errors;
        }

        private bool isExistName(string name)
        {
            var exist = db.LoaiSach.Where(m => m.TenLoaiSach == name).FirstOrDefault();
            if (exist != null)
            {
                return true;
            }
            return false;
        }

        public LoaiSach findByMaLoaiSach(long maTheLoai)
        {
            var result = db.LoaiSach.Where(m => m.MaLoaiSach == maTheLoai).FirstOrDefault();
            return result;        
        }

        private bool isExistId(string name)
        {
            var exist = db.LoaiSach.Where(m => m.TenLoaiSach == name).FirstOrDefault();
            if (exist != null)
            {
                return true;
            }
            return false;
        }

        public List<LoaiSach> findListByMaTheLoai(long id)
        {
            var exist = db.LoaiSach.Where(m => m.MaLoaiSach == id).ToList();
            return exist;
        }
    }
}
