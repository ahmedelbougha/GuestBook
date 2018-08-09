namespace GuestBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Owner = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Guest",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Comment = c.String(),
                        FaceID = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Book", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Face", t => t.FaceID, cascadeDelete: true)
                .Index(t => t.FaceID)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.Face",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Guest", "FaceID", "dbo.Face");
            DropForeignKey("dbo.Guest", "BookID", "dbo.Book");
            DropIndex("dbo.Guest", new[] { "BookID" });
            DropIndex("dbo.Guest", new[] { "FaceID" });
            DropTable("dbo.Country");
            DropTable("dbo.Face");
            DropTable("dbo.Guest");
            DropTable("dbo.Book");
        }
    }
}
