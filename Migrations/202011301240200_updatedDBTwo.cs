namespace John_Doe_Food_Ltd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedDBTwo : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.FoodId)
                .ForeignKey("dbo.OrderDTOes", t => t.OrderDTO_OrderId)
                .Index(t => t.OrderDTO_OrderId);
            
            CreateTable(
                "dbo.OrderDTOes",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        DateOrdered = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
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
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.OrderDTOes", t => t.OrderDTO_OrderId)
                .Index(t => t.OrderDTO_OrderId);
            
            AddColumn("dbo.Suppliers", "CatalougeDTO_FoodId", c => c.Int());
            AddColumn("dbo.Orders", "CustomerDTO_CustomerId", c => c.Int());
            CreateIndex("dbo.Suppliers", "CatalougeDTO_FoodId");
            CreateIndex("dbo.Orders", "CustomerDTO_CustomerId");
            AddForeignKey("dbo.Suppliers", "CatalougeDTO_FoodId", "dbo.CatalougeDTOes", "FoodId");
            AddForeignKey("dbo.Orders", "CustomerDTO_CustomerId", "dbo.CustomerDTOes", "CustomerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CatalougeDTOes", "OrderDTO_OrderId", "dbo.OrderDTOes");
            DropForeignKey("dbo.CustomerDTOes", "OrderDTO_OrderId", "dbo.OrderDTOes");
            DropForeignKey("dbo.Orders", "CustomerDTO_CustomerId", "dbo.CustomerDTOes");
            DropForeignKey("dbo.Suppliers", "CatalougeDTO_FoodId", "dbo.CatalougeDTOes");
            DropIndex("dbo.CustomerDTOes", new[] { "OrderDTO_OrderId" });
            DropIndex("dbo.Orders", new[] { "CustomerDTO_CustomerId" });
            DropIndex("dbo.Suppliers", new[] { "CatalougeDTO_FoodId" });
            DropIndex("dbo.CatalougeDTOes", new[] { "OrderDTO_OrderId" });
            DropColumn("dbo.Orders", "CustomerDTO_CustomerId");
            DropColumn("dbo.Suppliers", "CatalougeDTO_FoodId");
            DropTable("dbo.CustomerDTOes");
            DropTable("dbo.OrderDTOes");
            DropTable("dbo.CatalougeDTOes");
        }
    }
}
