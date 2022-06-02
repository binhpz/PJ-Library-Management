namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editdocgia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DocGias", "TenDG", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DocGias", "TenDG");
        }
    }
}
