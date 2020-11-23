namespace John_Doe_Food_Ltd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedrefNo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "RefNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "RefNo");
        }
    }
}
