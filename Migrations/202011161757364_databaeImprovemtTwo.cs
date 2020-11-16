namespace John_Doe_Food_Ltd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaeImprovemtTwo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Catalouges", "CommericalGood", c => c.Boolean(nullable: false));
            DropColumn("dbo.Catalouges", "Acess");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Catalouges", "Acess", c => c.String());
            DropColumn("dbo.Catalouges", "CommericalGood");
        }
    }
}
