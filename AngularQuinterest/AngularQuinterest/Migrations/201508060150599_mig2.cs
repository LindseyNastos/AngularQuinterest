namespace AngularQuinterest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BoardName = c.String(),
                        ImageUrl = c.String(),
                        Description = c.String(),
                        UserId = c.String(maxLength: 128),
                        NumPinsOnBoard = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Pins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ImageUrl = c.String(),
                        Website = c.String(),
                        BoardId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        ShortDescription = c.String(),
                        LongDescription = c.String(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Boards", t => t.BoardId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.BoardId)
                .Index(t => t.CategoryId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Words = c.String(),
                        PinId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pins", t => t.PinId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.PinId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Boards", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Pins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "PinId", "dbo.Pins");
            DropForeignKey("dbo.Pins", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Pins", "BoardId", "dbo.Boards");
            DropIndex("dbo.Comments", new[] { "PinId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Pins", new[] { "UserId" });
            DropIndex("dbo.Pins", new[] { "CategoryId" });
            DropIndex("dbo.Pins", new[] { "BoardId" });
            DropIndex("dbo.Boards", new[] { "UserId" });
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
            DropTable("dbo.Pins");
            DropTable("dbo.Boards");
        }
    }
}
