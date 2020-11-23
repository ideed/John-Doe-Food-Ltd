namespace John_Doe_Food_Ltd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedRefNo : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "RefNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "RefNo", c => c.String());
        }
    }
}
