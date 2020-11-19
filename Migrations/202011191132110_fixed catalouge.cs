namespace John_Doe_Food_Ltd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedcatalouge : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SupplierCatalouges", "Supplier_SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.SupplierCatalouges", "Catalouge_FoodId", "dbo.Catalouges");
            DropIndex("dbo.SupplierCatalouges", new[] { "Supplier_SupplierId" });
            DropIndex("dbo.SupplierCatalouges", new[] { "Catalouge_FoodId" });
            AddColumn("dbo.Catalouges", "Supplier_SupplierId", c => c.Int());
            CreateIndex("dbo.Catalouges", "Supplier_SupplierId");
            AddForeignKey("dbo.Catalouges", "Supplier_SupplierId", "dbo.Suppliers", "SupplierId");
            DropTable("dbo.SupplierCatalouges");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SupplierCatalouges",
                c => new
                    {
                        Supplier_SupplierId = c.Int(nullable: false),
                        Catalouge_FoodId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Supplier_SupplierId, t.Catalouge_FoodId });
            
            DropForeignKey("dbo.Catalouges", "Supplier_SupplierId", "dbo.Suppliers");
            DropIndex("dbo.Catalouges", new[] { "Supplier_SupplierId" });
            DropColumn("dbo.Catalouges", "Supplier_SupplierId");
            CreateIndex("dbo.SupplierCatalouges", "Catalouge_FoodId");
            CreateIndex("dbo.SupplierCatalouges", "Supplier_SupplierId");
            AddForeignKey("dbo.SupplierCatalouges", "Catalouge_FoodId", "dbo.Catalouges", "FoodId", cascadeDelete: true);
            AddForeignKey("dbo.SupplierCatalouges", "Supplier_SupplierId", "dbo.Suppliers", "SupplierId", cascadeDelete: true);
        }
    }
}
