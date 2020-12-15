namespace John_Doe_Food_Ltd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateContext : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Suppliers", "CatalougeDTO_FoodId", "dbo.CatalougeDTOes");
            DropForeignKey("dbo.CustomerDTOes", "OrderDTO_OrderId", "dbo.OrderDTOes");
            DropForeignKey("dbo.CatalougeDTOes", "OrderDTO_OrderId", "dbo.OrderDTOes");
            DropIndex("dbo.CatalougeDTOes", new[] { "OrderDTO_OrderId" });
            DropIndex("dbo.Suppliers", new[] { "CatalougeDTO_FoodId" });
            DropIndex("dbo.CustomerDTOes", new[] { "OrderDTO_OrderId" });
            DropColumn("dbo.Suppliers", "CatalougeDTO_FoodId");
            DropTable("dbo.CatalougeDTOes");
            DropTable("dbo.OrderDTOes");
            DropTable("dbo.CustomerDTOes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CustomerDTOes",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        Commercial = c.Boolean(nullable: false),
                        TelephoneNo = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        OrderDTO_OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.OrderDTOes",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        DateOrdered = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.CatalougeDTOes",
                c => new
                    {
                        FoodId = c.Int(nullable: false, identity: true),
                        FoodName = c.String(),
                        FoodType = c.String(),
                        CommericalGood = c.Boolean(nullable: false),
                        OrderDTO_OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.FoodId);
            
            AddColumn("dbo.Suppliers", "CatalougeDTO_FoodId", c => c.Int());
            CreateIndex("dbo.CustomerDTOes", "OrderDTO_OrderId");
            CreateIndex("dbo.Suppliers", "CatalougeDTO_FoodId");
            CreateIndex("dbo.CatalougeDTOes", "OrderDTO_OrderId");
            AddForeignKey("dbo.CatalougeDTOes", "OrderDTO_OrderId", "dbo.OrderDTOes", "OrderId");
            AddForeignKey("dbo.CustomerDTOes", "OrderDTO_OrderId", "dbo.OrderDTOes", "OrderId");
            AddForeignKey("dbo.Suppliers", "CatalougeDTO_FoodId", "dbo.CatalougeDTOes", "FoodId");
        }
    }
}
