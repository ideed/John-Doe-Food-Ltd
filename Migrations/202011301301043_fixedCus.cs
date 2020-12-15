namespace John_Doe_Food_Ltd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedCus : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderCustomers", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderCustomers", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Orders", "CustomerDTO_CustomerId", "dbo.CustomerDTOes");
            DropIndex("dbo.Orders", new[] { "CustomerDTO_CustomerId" });
            DropIndex("dbo.OrderCustomers", new[] { "Order_OrderId" });
            DropIndex("dbo.OrderCustomers", new[] { "Customer_CustomerId" });
            AddColumn("dbo.Customers", "Order_OrderId", c => c.Int());
            CreateIndex("dbo.Customers", "Order_OrderId");
            AddForeignKey("dbo.Customers", "Order_OrderId", "dbo.Orders", "OrderId");
            DropColumn("dbo.Orders", "CustomerDTO_CustomerId");
            DropTable("dbo.OrderCustomers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderCustomers",
                c => new
                    {
                        Order_OrderId = c.Int(nullable: false),
                        Customer_CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_OrderId, t.Customer_CustomerId });
            
            AddColumn("dbo.Orders", "CustomerDTO_CustomerId", c => c.Int());
            DropForeignKey("dbo.Customers", "Order_OrderId", "dbo.Orders");
            DropIndex("dbo.Customers", new[] { "Order_OrderId" });
            DropColumn("dbo.Customers", "Order_OrderId");
            CreateIndex("dbo.OrderCustomers", "Customer_CustomerId");
            CreateIndex("dbo.OrderCustomers", "Order_OrderId");
            CreateIndex("dbo.Orders", "CustomerDTO_CustomerId");
            AddForeignKey("dbo.Orders", "CustomerDTO_CustomerId", "dbo.CustomerDTOes", "CustomerId");
            AddForeignKey("dbo.OrderCustomers", "Customer_CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
            AddForeignKey("dbo.OrderCustomers", "Order_OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
        }
    }
}
