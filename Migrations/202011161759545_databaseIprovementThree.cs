namespace John_Doe_Food_Ltd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseIprovementThree : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Catalouges", "Supplier_SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Catalouges", "Supplier_SupplierId1", "dbo.Suppliers");
            DropForeignKey("dbo.Suppliers", "Catalouge_FoodId", "dbo.Catalouges");
            DropIndex("dbo.Catalouges", new[] { "Supplier_SupplierId" });
            DropIndex("dbo.Catalouges", new[] { "Supplier_SupplierId1" });
            DropIndex("dbo.Suppliers", new[] { "Catalouge_FoodId" });
            CreateTable(
                "dbo.SupplierCatalouges",
                c => new
                    {
                        Supplier_SupplierId = c.Int(nullable: false),
                        Catalouge_FoodId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Supplier_SupplierId, t.Catalouge_FoodId })
                .ForeignKey("dbo.Suppliers", t => t.Supplier_SupplierId, cascadeDelete: true)
                .ForeignKey("dbo.Catalouges", t => t.Catalouge_FoodId, cascadeDelete: true)
                .Index(t => t.Supplier_SupplierId)
                .Index(t => t.Catalouge_FoodId);
            
            DropColumn("dbo.Catalouges", "SupplierId");
            DropColumn("dbo.Catalouges", "Supplier_SupplierId");
            DropColumn("dbo.Catalouges", "Supplier_SupplierId1");
            DropColumn("dbo.Suppliers", "Catalouge_FoodId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Suppliers", "Catalouge_FoodId", c => c.Int());
            AddColumn("dbo.Catalouges", "Supplier_SupplierId1", c => c.Int());
            AddColumn("dbo.Catalouges", "Supplier_SupplierId", c => c.Int());
            AddColumn("dbo.Catalouges", "SupplierId", c => c.Int(nullable: false));
            DropForeignKey("dbo.SupplierCatalouges", "Catalouge_FoodId", "dbo.Catalouges");
            DropForeignKey("dbo.SupplierCatalouges", "Supplier_SupplierId", "dbo.Suppliers");
            DropIndex("dbo.SupplierCatalouges", new[] { "Catalouge_FoodId" });
            DropIndex("dbo.SupplierCatalouges", new[] { "Supplier_SupplierId" });
            DropTable("dbo.SupplierCatalouges");
            CreateIndex("dbo.Suppliers", "Catalouge_FoodId");
            CreateIndex("dbo.Catalouges", "Supplier_SupplierId1");
            CreateIndex("dbo.Catalouges", "Supplier_SupplierId");
            AddForeignKey("dbo.Suppliers", "Catalouge_FoodId", "dbo.Catalouges", "FoodId");
            AddForeignKey("dbo.Catalouges", "Supplier_SupplierId1", "dbo.Suppliers", "SupplierId");
            AddForeignKey("dbo.Catalouges", "Supplier_SupplierId", "dbo.Suppliers", "SupplierId");
        }
    }
}
