namespace John_Doe_Food_Ltd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixeddatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Orders_OrderId", "dbo.Orders");
            DropForeignKey("dbo.Catalouges", "Orders_OrderId", "dbo.Orders");
            DropIndex("dbo.Catalouges", new[] { "Orders_OrderId" });
            DropIndex("dbo.Customers", new[] { "Orders_OrderId" });
            AddColumn("dbo.Orders", "DateOrdered", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "Catalouge_FoodId", c => c.Int());
            AddColumn("dbo.Orders", "Customer_CustomerId", c => c.Int());
            CreateIndex("dbo.Orders", "Catalouge_FoodId");
            CreateIndex("dbo.Orders", "Customer_CustomerId");
            AddForeignKey("dbo.Orders", "Catalouge_FoodId", "dbo.Catalouges", "FoodId");
            AddForeignKey("dbo.Orders", "Customer_CustomerId", "dbo.Customers", "CustomerId");
            DropColumn("dbo.Catalouges", "Orders_OrderId");
            DropColumn("dbo.Customers", "Orders_OrderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Orders_OrderId", c => c.Int());
            AddColumn("dbo.Catalouges", "Orders_OrderId", c => c.Int());
            DropForeignKey("dbo.Orders", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Orders", "Catalouge_FoodId", "dbo.Catalouges");
            DropIndex("dbo.Orders", new[] { "Customer_CustomerId" });
            DropIndex("dbo.Orders", new[] { "Catalouge_FoodId" });
            DropColumn("dbo.Orders", "Customer_CustomerId");
            DropColumn("dbo.Orders", "Catalouge_FoodId");
            DropColumn("dbo.Orders", "DateOrdered");
            CreateIndex("dbo.Customers", "Orders_OrderId");
            CreateIndex("dbo.Catalouges", "Orders_OrderId");
            AddForeignKey("dbo.Catalouges", "Orders_OrderId", "dbo.Orders", "OrderId");
            AddForeignKey("dbo.Customers", "Orders_OrderId", "dbo.Orders", "OrderId");
        }
    }
}
