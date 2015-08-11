namespace AngularQuinterest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DisplayName", c => c.String());
            AddColumn("dbo.AspNetUsers", "ImageUrl", c => c.String());
            AddColumn("dbo.AspNetUsers", "NumBoards", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "NumPins", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "NumPins");
            DropColumn("dbo.AspNetUsers", "NumBoards");
            DropColumn("dbo.AspNetUsers", "ImageUrl");
            DropColumn("dbo.AspNetUsers", "DisplayName");
        }
    }
}
