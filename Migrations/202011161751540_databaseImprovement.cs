namespace John_Doe_Food_Ltd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseImprovement : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Suppliers", "Supplier_SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Customers", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Catalouges", "SupplierId", "dbo.Suppliers");
            DropIndex("dbo.Catalouges", new[] { "SupplierId" });
            DropIndex("dbo.Suppliers", new[] { "Supplier_SupplierId" });
            DropIndex("dbo.Customers", new[] { "Customer_CustomerId" });
            AddColumn("dbo.Catalouges", "Supplier_SupplierId", c => c.Int());
            AddColumn("dbo.Catalouges", "Supplier_SupplierId1", c => c.Int());
            AddColumn("dbo.Suppliers", "Catalouge_FoodId", c => c.Int());
            AddColumn("dbo.Customers", "Commercial", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "Catalouge_FoodId", c => c.Int());
            CreateIndex("dbo.Catalouges", "Supplier_SupplierId");
            CreateIndex("dbo.Catalouges", "Supplier_SupplierId1");
            CreateIndex("dbo.Customers", "Catalouge_FoodId");
            CreateIndex("dbo.Suppliers", "Catalouge_FoodId");
            AddForeignKey("dbo.Customers", "Catalouge_FoodId", "dbo.Catalouges", "FoodId");
            AddForeignKey("dbo.Catalouges", "Supplier_SupplierId", "dbo.Suppliers", "SupplierId");
            AddForeignKey("dbo.Suppliers", "Catalouge_FoodId", "dbo.Catalouges", "FoodId");
            AddForeignKey("dbo.Catalouges", "Supplier_SupplierId1", "dbo.Suppliers", "SupplierId");
            DropColumn("dbo.Suppliers", "Supplier_SupplierId");
            DropColumn("dbo.Customers", "CustomerType");
            DropColumn("dbo.Customers", "Customer_CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Customer_CustomerId", c => c.Int());
            AddColumn("dbo.Customers", "CustomerType", c => c.String());
            AddColumn("dbo.Suppliers", "Supplier_SupplierId", c => c.Int());
            DropForeignKey("dbo.Catalouges", "Supplier_SupplierId1", "dbo.Suppliers");
            DropForeignKey("dbo.Suppliers", "Catalouge_FoodId", "dbo.Catalouges");
            DropForeignKey("dbo.Catalouges", "Supplier_SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Customers", "Catalouge_FoodId", "dbo.Catalouges");
            DropIndex("dbo.Suppliers", new[] { "Catalouge_FoodId" });
            DropIndex("dbo.Customers", new[] { "Catalouge_FoodId" });
            DropIndex("dbo.Catalouges", new[] { "Supplier_SupplierId1" });
            DropIndex("dbo.Catalouges", new[] { "Supplier_SupplierId" });
            DropColumn("dbo.Customers", "Catalouge_FoodId");
            DropColumn("dbo.Customers", "Commercial");
            DropColumn("dbo.Suppliers", "Catalouge_FoodId");
            DropColumn("dbo.Catalouges", "Supplier_SupplierId1");
            DropColumn("dbo.Catalouges", "Supplier_SupplierId");
            CreateIndex("dbo.Customers", "Customer_CustomerId");
            CreateIndex("dbo.Suppliers", "Supplier_SupplierId");
            CreateIndex("dbo.Catalouges", "SupplierId");
            AddForeignKey("dbo.Catalouges", "SupplierId", "dbo.Suppliers", "SupplierId", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "Customer_CustomerId", "dbo.Customers", "CustomerId");
            AddForeignKey("dbo.Suppliers", "Supplier_SupplierId", "dbo.Suppliers", "SupplierId");
        }
    }
}
