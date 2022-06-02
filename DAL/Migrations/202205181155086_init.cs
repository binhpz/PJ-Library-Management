namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DocGias",
                c => new
                    {
                        MaDG = c.Long(nullable: false, identity: true),
                        NgaySinh = c.DateTime(),
                        NgayHetHanThe = c.DateTime(),
                        SoCMT = c.String(),
                        SDT = c.String(),
                        DiaChi = c.String(),
                    })
                .PrimaryKey(t => t.MaDG);
            
            CreateTable(
                "dbo.LoaiSaches",
                c => new
                    {
                        MaLoaiSach = c.Long(nullable: false, identity: true),
                        TenLoaiSach = c.String(),
                    })
                .PrimaryKey(t => t.MaLoaiSach);
            
            CreateTable(
                "dbo.Saches",
                c => new
                    {
                        MaSach = c.Long(nullable: false),
                        TenSach = c.String(),
                        TenTacGia = c.String(),
                        NhaXuatBan = c.String(),
                        NamXuatBan = c.Int(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        MaLoaiSach = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.MaSach)
                .ForeignKey("dbo.LoaiSaches", t => t.MaSach)
                .Index(t => t.MaSach);
            
            CreateTable(
                "dbo.MuonTraSaches",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        MaDG = c.Long(nullable: false),
                        MaThuThu = c.Long(nullable: false),
                        NgayMuon = c.DateTime(),
                        NgayHenTra = c.DateTime(),
                        NgayTra = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DocGias", t => t.MaDG, cascadeDelete: true)
                .ForeignKey("dbo.ThuThus", t => t.MaThuThu, cascadeDelete: true)
                .Index(t => t.MaDG)
                .Index(t => t.MaThuThu);
            
            CreateTable(
                "dbo.ThuThus",
                c => new
                    {
                        MaThuThu = c.Long(nullable: false, identity: true),
                        TenThuThu = c.String(),
                        TaiKhoan = c.String(),
                        MatKhau = c.String(),
                    })
                .PrimaryKey(t => t.MaThuThu);
            
            CreateTable(
                "dbo.MuonTraSachSaches",
                c => new
                    {
                        MuonTraSach_ID = c.Long(nullable: false),
                        Sach_MaSach = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.MuonTraSach_ID, t.Sach_MaSach })
                .ForeignKey("dbo.MuonTraSaches", t => t.MuonTraSach_ID, cascadeDelete: true)
                .ForeignKey("dbo.Saches", t => t.Sach_MaSach, cascadeDelete: true)
                .Index(t => t.MuonTraSach_ID)
                .Index(t => t.Sach_MaSach);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MuonTraSaches", "MaThuThu", "dbo.ThuThus");
            DropForeignKey("dbo.MuonTraSachSaches", "Sach_MaSach", "dbo.Saches");
            DropForeignKey("dbo.MuonTraSachSaches", "MuonTraSach_ID", "dbo.MuonTraSaches");
            DropForeignKey("dbo.MuonTraSaches", "MaDG", "dbo.DocGias");
            DropForeignKey("dbo.Saches", "MaSach", "dbo.LoaiSaches");
            DropIndex("dbo.MuonTraSachSaches", new[] { "Sach_MaSach" });
            DropIndex("dbo.MuonTraSachSaches", new[] { "MuonTraSach_ID" });
            DropIndex("dbo.MuonTraSaches", new[] { "MaThuThu" });
            DropIndex("dbo.MuonTraSaches", new[] { "MaDG" });
            DropIndex("dbo.Saches", new[] { "MaSach" });
            DropTable("dbo.MuonTraSachSaches");
            DropTable("dbo.ThuThus");
            DropTable("dbo.MuonTraSaches");
            DropTable("dbo.Saches");
            DropTable("dbo.LoaiSaches");
            DropTable("dbo.DocGias");
        }
    }
}
