namespace A2projeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SixthCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Feedings", "name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Feedings", "name");
        }
    }
}
