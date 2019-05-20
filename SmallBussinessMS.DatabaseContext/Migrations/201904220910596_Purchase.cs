namespace SmallBussinessMS.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Purchase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(maxLength: 50),
                        Address = c.String(maxLength: 100),
                        Email = c.String(maxLength: 50),
                        Contact = c.String(maxLength: 11),
                        LoyalityPoint = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        File = c.Binary(),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        ReoderLevel = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ProductFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        File = c.Binary(),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        InvoiceNo = c.String(),
                        SupplierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.PurchaseDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ManufacturedDate = c.DateTime(nullable: false),
                        ExpireDate = c.DateTime(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NewCostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NewMRP = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Purchases", t => t.PurchaseId, cascadeDelete: true)
                .Index(t => t.PurchaseId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(maxLength: 50),
                        Address = c.String(maxLength: 100),
                        Email = c.String(maxLength: 50),
                        Contact = c.String(maxLength: 11),
                        ContactPerson = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SupplierFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupplierId = c.Int(nullable: false),
                        File = c.Binary(),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.SupplierFiles", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.PurchaseDetails", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.PurchaseDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductFiles", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.CustomerFiles", "CustomerId", "dbo.Customers");
            DropIndex("dbo.SupplierFiles", new[] { "SupplierId" });
            DropIndex("dbo.PurchaseDetails", new[] { "ProductId" });
            DropIndex("dbo.PurchaseDetails", new[] { "PurchaseId" });
            DropIndex("dbo.Purchases", new[] { "SupplierId" });
            DropIndex("dbo.ProductFiles", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.CustomerFiles", new[] { "CustomerId" });
            DropTable("dbo.SupplierFiles");
            DropTable("dbo.Suppliers");
            DropTable("dbo.PurchaseDetails");
            DropTable("dbo.Purchases");
            DropTable("dbo.ProductFiles");
            DropTable("dbo.Products");
            DropTable("dbo.CustomerFiles");
            DropTable("dbo.Customers");
            DropTable("dbo.Categories");
        }
    }
}
