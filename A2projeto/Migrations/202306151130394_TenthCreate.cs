namespace A2projeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TenthCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "healthRecords", c => c.String());
            AddColumn("dbo.HealthRecords", "name", c => c.String());
            AddColumn("dbo.Infirms", "healthRecords", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Infirms", "healthRecords");
            DropColumn("dbo.HealthRecords", "name");
            DropColumn("dbo.Animals", "healthRecords");
        }
    }
}
