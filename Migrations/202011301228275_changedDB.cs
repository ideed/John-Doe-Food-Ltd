namespace John_Doe_Food_Ltd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "CatId", "dbo.Catalouges");
            DropForeignKey("dbo.Orders", "CusId", "dbo.Customers");
            DropForeignKey("dbo.Catalouges", "Supplier_SupplierId", "dbo.Suppliers");
            DropIndex("dbo.Catalouges", new[] { "Supplier_SupplierId" });
            DropIndex("dbo.Orders", new[] { "CatId" });
            DropIndex("dbo.Orders", new[] { "CusId" });
            CreateTable(
                "dbo.OrderCustomers",
                c => new
                    {
                        Order_OrderId = c.Int(nullable: false),
                        Customer_CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_OrderId, t.Customer_CustomerId })
                .ForeignKey("dbo.Orders", t => t.Order_OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId, cascadeDelete: true)
                .Index(t => t.Order_OrderId)
                .Index(t => t.Customer_CustomerId);
            
            AddColumn("dbo.Catalouges", "Order_OrderId", c => c.Int());
            AddColumn("dbo.Suppliers", "Catalouge_FoodId", c => c.Int());
            CreateIndex("dbo.Catalouges", "Order_OrderId");
            CreateIndex("dbo.Suppliers", "Catalouge_FoodId");
            AddForeignKey("dbo.Suppliers", "Catalouge_FoodId", "dbo.Catalouges", "FoodId");
            AddForeignKey("dbo.Catalouges", "Order_OrderId", "dbo.Orders", "OrderId");
            DropColumn("dbo.Catalouges", "Supplier_SupplierId");
            DropColumn("dbo.Orders", "CatId");
            DropColumn("dbo.Orders", "CusId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "CusId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "CatId", c => c.Int(nullable: false));
            AddColumn("dbo.Catalouges", "Supplier_SupplierId", c => c.Int());
            DropForeignKey("dbo.Catalouges", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderCustomers", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.OrderCustomers", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.Suppliers", "Catalouge_FoodId", "dbo.Catalouges");
            DropIndex("dbo.OrderCustomers", new[] { "Customer_CustomerId" });
            DropIndex("dbo.OrderCustomers", new[] { "Order_OrderId" });
            DropIndex("dbo.Suppliers", new[] { "Catalouge_FoodId" });
            DropIndex("dbo.Catalouges", new[] { "Order_OrderId" });
            DropColumn("dbo.Suppliers", "Catalouge_FoodId");
            DropColumn("dbo.Catalouges", "Order_OrderId");
            DropTable("dbo.OrderCustomers");
            CreateIndex("dbo.Orders", "CusId");
            CreateIndex("dbo.Orders", "CatId");
            CreateIndex("dbo.Catalouges", "Supplier_SupplierId");
            AddForeignKey("dbo.Catalouges", "Supplier_SupplierId", "dbo.Suppliers", "SupplierId");
            AddForeignKey("dbo.Orders", "CusId", "dbo.Customers", "CustomerId", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "CatId", "dbo.Catalouges", "FoodId", cascadeDelete: true);
        }
    }
}
