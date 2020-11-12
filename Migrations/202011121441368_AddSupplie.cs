namespace John_Doe_Food_Ltd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSupplie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catalouges",
                c => new
                    {
                        FoodId = c.Int(nullable: false, identity: true),
                        FoodName = c.String(),
                        FoodType = c.String(),
                        Acess = c.String(),
                        SupplierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FoodId)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(),
                        SupplierType = c.String(),
                        TelephoneNo = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Supplier_SupplierId = c.Int(),
                    })
                .PrimaryKey(t => t.SupplierId)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_SupplierId)
                .Index(t => t.Supplier_SupplierId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        CustomerType = c.String(),
                        TelephoneNo = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Customer_CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .Index(t => t.Customer_CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Catalouges", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Suppliers", "Supplier_SupplierId", "dbo.Suppliers");
            DropIndex("dbo.Customers", new[] { "Customer_CustomerId" });
            DropIndex("dbo.Suppliers", new[] { "Supplier_SupplierId" });
            DropIndex("dbo.Catalouges", new[] { "SupplierId" });
            DropTable("dbo.Customers");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Catalouges");
        }
    }
}
