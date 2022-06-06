using DAL;
using Microsoft.CodeAnalysis.Differencing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
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

        public List<string> edit(long id, string tenSach, string tenTacGia, long loaiSach, string nhaXuatBan, int namXuatBan, int soLuong )
        {

            var errors = new List<string>();


            var sach = findByMaSach(id);
            if (sach == null)
            {
                errors.Add("Sách không tồn tại!");
                return errors;

            }

            var loaiSachRsl = theLoaiBus.findByMaLoaiSach(loaiSach);
            if (loaiSachRsl == null)
            {
                errors.Add("Thể loại không tồn tại!");
                return errors;
            }

            /*
            bool isExisted = isExistName(tenSach);
            if (isExisted)
            {
                errors.Add("Tên sách đã tồn tại");
                return errors;

            }
            */

            var s = new Sach { };
            s.TenSach = tenSach;
            s.TenTacGia = tenTacGia;
            s.LoaiSach = loaiSachRsl;
            s.MaLoaiSach = loaiSach;
            s.NhaXuatBan = nhaXuatBan;
            s.NamXuatBan = namXuatBan;
            s.SoLuong = soLuong;

            var existingParent = db.Sach
        .Where(p => p.MaSach == id)
        .Include(p => p.LoaiSach)
        .SingleOrDefault();

            if (existingParent != null)
            {

                s.MaSach = existingParent.MaSach;
                s.MaSach = existingParent.MaSach;
                // Update parent
                db.Entry(existingParent).CurrentValues.SetValues(s);

                /*
                // Delete children
                foreach (var existingChild in existingParent.Children.ToList())
                {
                    if (!model.Children.Any(c => c.Id == existingChild.Id))
                        _dbContext.Children.Remove(existingChild);
                }

                // Update and Insert children
                foreach (var childModel in model.Children)
                {
                    var existingChild = existingParent.Children
                        .Where(c => c.Id == childModel.Id)
                        .SingleOrDefault();

                    if (existingChild != null)
                        // Update child
                        _dbContext.Entry(existingChild).CurrentValues.SetValues(childModel);
                    else
                    {
                        // Insert child
                        var newChild = new Child
                        {
                            Data = childModel.Data,
                            //...
                        };
                        existingParent.Children.Add(newChild);
                    }
                }
                */
                db.SaveChanges();
            }

            return errors;

        }

        public Sach findByMaSach(long maSach)
        {
            var result = db.Sach.Where(m => m.MaSach == maSach).FirstOrDefault();
            return result;
        }

        private bool isExistName(string name)
        {
            var exist = db.Sach.Where(m => m.TenSach== name).FirstOrDefault();
            if (exist != null)
            {
                return true;
            }
            return false;
        }

        public List<Sach> findListByTenSach(string tenSach)
        {
            var exist = db.Sach.Where(m => m.TenSach.ToLower().Contains(tenSach.ToLower())).ToList();
            return exist;
        }
    }
}
