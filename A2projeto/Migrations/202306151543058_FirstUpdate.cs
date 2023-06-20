namespace A2projeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HealthRecords", "pregnancyIdentificationDay", c => c.DateTime());
            AlterColumn("dbo.HealthRecords", "pregnancyDay", c => c.DateTime());
            AlterColumn("dbo.HealthRecords", "dateOfDelivery", c => c.DateTime());
        }

        public override void Down()
        {
            AlterColumn("dbo.HealthRecords", "pregnancyIdentificationDay", c => c.DateTime(nullable: true));
            AlterColumn("dbo.HealthRecords", "pregnancyDay", c => c.DateTime(nullable: true));
            AlterColumn("dbo.HealthRecords", "dateOfDelivery", c => c.DateTime(nullable: true));
        }
    }
}
