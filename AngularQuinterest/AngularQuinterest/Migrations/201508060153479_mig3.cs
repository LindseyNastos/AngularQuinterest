namespace AngularQuinterest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pins", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Pins", new[] { "CategoryId" });
            DropColumn("dbo.Pins", "CategoryId");
            DropColumn("dbo.Categories", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Name", c => c.String());
            AddColumn("dbo.Pins", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pins", "CategoryId");
            AddForeignKey("dbo.Pins", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
