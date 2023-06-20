namespace A2projeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeventhCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Foods", "feedings_id", c => c.Int());
            CreateIndex("dbo.Foods", "feedings_id");
            AddForeignKey("dbo.Foods", "feedings_id", "dbo.Feedings", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Foods", "feedings_id", "dbo.Feedings");
            DropIndex("dbo.Foods", new[] { "feedings_id" });
            DropColumn("dbo.Foods", "feedings_id");
        }
    }
}
