namespace A2projeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HealthRecords", "numberOfOffspring", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HealthRecords", "numberOfOffspring", c => c.Int(nullable: true));
        }
    }
}
