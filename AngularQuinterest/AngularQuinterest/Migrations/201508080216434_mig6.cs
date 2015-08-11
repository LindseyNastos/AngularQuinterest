namespace AngularQuinterest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "DisplayName");
            DropColumn("dbo.AspNetUsers", "ImageUrl");
            DropColumn("dbo.AspNetUsers", "NumBoards");
            DropColumn("dbo.AspNetUsers", "NumPins");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "NumPins", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "NumBoards", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "ImageUrl", c => c.String());
            AddColumn("dbo.AspNetUsers", "DisplayName", c => c.String());
        }
    }
}
