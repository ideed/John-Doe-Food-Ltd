namespace John_Doe_Food_Ltd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CatIdCusId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Catalouge_FoodId", "dbo.Catalouges");
            DropForeignKey("dbo.Orders", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "Catalouge_FoodId" });
            DropIndex("dbo.Orders", new[] { "Customer_CustomerId" });
            RenameColumn(table: "dbo.Orders", name: "Catalouge_FoodId", newName: "CatId");
            RenameColumn(table: "dbo.Orders", name: "Customer_CustomerId", newName: "CusId");
            AlterColumn("dbo.Orders", "CatId", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "CusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "CatId");
            CreateIndex("dbo.Orders", "CusId");
            AddForeignKey("dbo.Orders", "CatId", "dbo.Catalouges", "FoodId", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "CusId", "dbo.Customers", "CustomerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CusId", "dbo.Customers");
            DropForeignKey("dbo.Orders", "CatId", "dbo.Catalouges");
            DropIndex("dbo.Orders", new[] { "CusId" });
            DropIndex("dbo.Orders", new[] { "CatId" });
            AlterColumn("dbo.Orders", "CusId", c => c.Int());
            AlterColumn("dbo.Orders", "CatId", c => c.Int());
            RenameColumn(table: "dbo.Orders", name: "CusId", newName: "Customer_CustomerId");
            RenameColumn(table: "dbo.Orders", name: "CatId", newName: "Catalouge_FoodId");
            CreateIndex("dbo.Orders", "Customer_CustomerId");
            CreateIndex("dbo.Orders", "Catalouge_FoodId");
            AddForeignKey("dbo.Orders", "Customer_CustomerId", "dbo.Customers", "CustomerId");
            AddForeignKey("dbo.Orders", "Catalouge_FoodId", "dbo.Catalouges", "FoodId");
        }
    }
}
