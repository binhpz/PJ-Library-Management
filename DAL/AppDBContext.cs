 using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() : base("name=LibraryConnectionString")
        {
        }

        public DbSet<LoaiSach> LoaiSach { get; set; }
        public DbSet<Sach> Sach { get; set; }
        public DbSet<ThuThu> ThuThu { get; set; }
        public DbSet<DocGia> DocGia { get; set; }
        public DbSet<MuonTraSach> MuonTraSach { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        private void FixEfProviderServicesProblem()
        {
            // The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
            // for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            // Make sure the provider assembly is available to the running application. 
            // See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

    }
}
