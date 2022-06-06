namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DocGia",
                c => new
                    {
                        MaDG = c.Long(nullable: false, identity: true),
                        TenDG = c.String(),
                        NgaySinh = c.DateTime(),
                        NgayHetHanThe = c.DateTime(),
                        SoCMT = c.String(),
                        SDT = c.String(),
                        DiaChi = c.String(),
                    })
                .PrimaryKey(t => t.MaDG);
            
            CreateTable(
                "dbo.LoaiSach",
                c => new
                    {
                        MaLoaiSach = c.Long(nullable: false, identity: true),
                        TenLoaiSach = c.String(),
                    })
                .PrimaryKey(t => t.MaLoaiSach);
            
            CreateTable(
                "dbo.Sach",
                c => new
                    {
                        MaSach = c.Long(nullable: false, identity: true),
                        TenSach = c.String(),
                        TenTacGia = c.String(),
                        NhaXuatBan = c.String(),
                        NamXuatBan = c.Int(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        MaLoaiSach = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.MaSach)
                .ForeignKey("dbo.LoaiSach", t => t.MaLoaiSach, cascadeDelete: true)
                .Index(t => t.MaLoaiSach);
            
            CreateTable(
                "dbo.MuonTraSach",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        MaDG = c.Long(nullable: false),
                        MaThuThu = c.Long(nullable: false),
                        NgayMuon = c.DateTime(),
                        NgayHenTra = c.DateTime(),
                        NgayTra = c.DateTime(),
                        TrangThai = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DocGia", t => t.MaDG, cascadeDelete: true)
                .ForeignKey("dbo.ThuThu", t => t.MaThuThu, cascadeDelete: true)
                .Index(t => t.MaDG)
                .Index(t => t.MaThuThu);
            
            CreateTable(
                "dbo.ThuThu",
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
                .ForeignKey("dbo.MuonTraSach", t => t.MuonTraSach_ID, cascadeDelete: true)
                .ForeignKey("dbo.Sach", t => t.Sach_MaSach, cascadeDelete: true)
                .Index(t => t.MuonTraSach_ID)
                .Index(t => t.Sach_MaSach);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MuonTraSach", "MaThuThu", "dbo.ThuThu");
            DropForeignKey("dbo.MuonTraSachSaches", "Sach_MaSach", "dbo.Sach");
            DropForeignKey("dbo.MuonTraSachSaches", "MuonTraSach_ID", "dbo.MuonTraSach");
            DropForeignKey("dbo.MuonTraSach", "MaDG", "dbo.DocGia");
            DropForeignKey("dbo.Sach", "MaLoaiSach", "dbo.LoaiSach");
            DropIndex("dbo.MuonTraSachSaches", new[] { "Sach_MaSach" });
            DropIndex("dbo.MuonTraSachSaches", new[] { "MuonTraSach_ID" });
            DropIndex("dbo.MuonTraSach", new[] { "MaThuThu" });
            DropIndex("dbo.MuonTraSach", new[] { "MaDG" });
            DropIndex("dbo.Sach", new[] { "MaLoaiSach" });
            DropTable("dbo.MuonTraSachSaches");
            DropTable("dbo.ThuThu");
            DropTable("dbo.MuonTraSach");
            DropTable("dbo.Sach");
            DropTable("dbo.LoaiSach");
            DropTable("dbo.DocGia");
        }
    }
}
