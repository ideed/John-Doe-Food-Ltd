namespace John_Doe_Food_Ltd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOrdrs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Catalouge_FoodId", "dbo.Catalouges");
            DropIndex("dbo.Customers", new[] { "Catalouge_FoodId" });
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.OrderId);
            
            AddColumn("dbo.Catalouges", "Orders_OrderId", c => c.Int());
            AddColumn("dbo.Customers", "Orders_OrderId", c => c.Int());
            CreateIndex("dbo.Catalouges", "Orders_OrderId");
            CreateIndex("dbo.Customers", "Orders_OrderId");
            AddForeignKey("dbo.Customers", "Orders_OrderId", "dbo.Orders", "OrderId");
            AddForeignKey("dbo.Catalouges", "Orders_OrderId", "dbo.Orders", "OrderId");
            DropColumn("dbo.Customers", "Catalouge_FoodId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Catalouge_FoodId", c => c.Int());
            DropForeignKey("dbo.Catalouges", "Orders_OrderId", "dbo.Orders");
            DropForeignKey("dbo.Customers", "Orders_OrderId", "dbo.Orders");
            DropIndex("dbo.Customers", new[] { "Orders_OrderId" });
            DropIndex("dbo.Catalouges", new[] { "Orders_OrderId" });
            DropColumn("dbo.Customers", "Orders_OrderId");
            DropColumn("dbo.Catalouges", "Orders_OrderId");
            DropTable("dbo.Orders");
            CreateIndex("dbo.Customers", "Catalouge_FoodId");
            AddForeignKey("dbo.Customers", "Catalouge_FoodId", "dbo.Catalouges", "FoodId");
        }
    }
}
