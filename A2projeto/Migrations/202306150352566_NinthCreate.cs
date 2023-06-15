namespace A2projeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NinthCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PerformFeedings", "feedings", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PerformFeedings", "feedings");
        }
    }
}
