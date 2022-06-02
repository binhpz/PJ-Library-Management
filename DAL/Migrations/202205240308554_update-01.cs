namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update01 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MuonTraSachSaches", newName: "SachMuonTraSaches");
            DropPrimaryKey("dbo.SachMuonTraSaches");
            AddPrimaryKey("dbo.SachMuonTraSaches", new[] { "Sach_MaSach", "MuonTraSach_ID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.SachMuonTraSaches");
            AddPrimaryKey("dbo.SachMuonTraSaches", new[] { "MuonTraSach_ID", "Sach_MaSach" });
            RenameTable(name: "dbo.SachMuonTraSaches", newName: "MuonTraSachSaches");
        }
    }
}
