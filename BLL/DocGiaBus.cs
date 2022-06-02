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
    }
}
