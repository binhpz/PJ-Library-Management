using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MuonSachBus
    {
        AppDBContext db = new AppDBContext { };
        TheLoaiBus theLoaiBus = new TheLoaiBus { };

        public BindingList<MuonTraSach> getList()
        {
            var list = db.MuonTraSach.ToList();
            return new BindingList<MuonTraSach>(list);
        }

    }
}
