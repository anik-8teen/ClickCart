namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Price = c.Int(),
                        Qty = c.Int(nullable: false),
                        CId = c.Int(nullable: false),
                        SId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CId, cascadeDelete: true)
                .ForeignKey("dbo.Sellers", t => t.SId, cascadeDelete: true)
                .Index(t => t.CId)
                .Index(t => t.SId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        PId = c.Int(nullable: false),
                        UId = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.PId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UId)
                .Index(t => t.PId)
                .Index(t => t.UId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 10),
                        Name = c.String(nullable: false, maxLength: 100),
                        Email = c.String(),
                        Password = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        Status = c.String(),
                        Amount = c.Int(nullable: false),
                        OrderedById = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.OrderedById)
                .Index(t => t.OrderedById);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Qty = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        PId = c.Int(nullable: false),
                        OId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.PId, cascadeDelete: true)
                .Index(t => t.PId)
                .Index(t => t.OId);
            
            CreateTable(
                "dbo.Wishlists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PId = c.Int(nullable: false),
                        UId = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.PId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UId)
                .Index(t => t.PId)
                .Index(t => t.UId);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false),
                        SellerContact = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SId", "dbo.Sellers");
            DropForeignKey("dbo.Reviews", "UId", "dbo.Users");
            DropForeignKey("dbo.Wishlists", "UId", "dbo.Users");
            DropForeignKey("dbo.Wishlists", "PId", "dbo.Products");
            DropForeignKey("dbo.Orders", "OrderedById", "dbo.Users");
            DropForeignKey("dbo.OrderDetails", "PId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OId", "dbo.Orders");
            DropForeignKey("dbo.Reviews", "PId", "dbo.Products");
            DropForeignKey("dbo.Products", "CId", "dbo.Categories");
            DropIndex("dbo.Wishlists", new[] { "UId" });
            DropIndex("dbo.Wishlists", new[] { "PId" });
            DropIndex("dbo.OrderDetails", new[] { "OId" });
            DropIndex("dbo.OrderDetails", new[] { "PId" });
            DropIndex("dbo.Orders", new[] { "OrderedById" });
            DropIndex("dbo.Reviews", new[] { "UId" });
            DropIndex("dbo.Reviews", new[] { "PId" });
            DropIndex("dbo.Products", new[] { "SId" });
            DropIndex("dbo.Products", new[] { "CId" });
            DropTable("dbo.Sellers");
            DropTable("dbo.Wishlists");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.Users");
            DropTable("dbo.Reviews");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
