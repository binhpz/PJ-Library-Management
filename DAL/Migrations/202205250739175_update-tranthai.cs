namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetranthai : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MuonTraSaches", "TrangThai", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MuonTraSaches", "TrangThai");
        }
    }
}
