namespace A2projeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EighthCreate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Foods", "feedings_id", "dbo.Feedings");
            DropForeignKey("dbo.PerformFeedings", "food_id", "dbo.Foods");
            DropForeignKey("dbo.Animals", "feedings_id", "dbo.Feedings");
            DropForeignKey("dbo.Animals", "sector_id", "dbo.Sectors");
            DropForeignKey("dbo.HealthRecords", "animal_id", "dbo.Animals");
            DropForeignKey("dbo.Reproductions", "animalFemale_id", "dbo.Animals");
            DropForeignKey("dbo.Reproductions", "animalMale_id", "dbo.Animals");
            DropIndex("dbo.Animals", new[] { "feedings_id" });
            DropIndex("dbo.Animals", new[] { "sector_id" });
            DropIndex("dbo.PerformFeedings", new[] { "food_id" });
            DropIndex("dbo.Foods", new[] { "feedings_id" });
            DropIndex("dbo.HealthRecords", new[] { "animal_id" });
            DropIndex("dbo.Reproductions", new[] { "animalFemale_id" });
            DropIndex("dbo.Reproductions", new[] { "animalMale_id" });
            AddColumn("dbo.Animals", "feedings", c => c.String());
            AddColumn("dbo.Animals", "sector", c => c.String());
            AddColumn("dbo.PerformFeedings", "food", c => c.String());
            AddColumn("dbo.HealthRecords", "animal", c => c.String());
            AddColumn("dbo.Reproductions", "animalMale", c => c.String());
            AddColumn("dbo.Reproductions", "animalFemale", c => c.String());
            DropColumn("dbo.Animals", "feedings_id");
            DropColumn("dbo.Animals", "sector_id");
            DropColumn("dbo.PerformFeedings", "food_id");
            DropColumn("dbo.Foods", "feedings_id");
            DropColumn("dbo.HealthRecords", "animal_id");
            DropColumn("dbo.Reproductions", "animalFemale_id");
            DropColumn("dbo.Reproductions", "animalMale_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reproductions", "animalMale_id", c => c.Int());
            AddColumn("dbo.Reproductions", "animalFemale_id", c => c.Int());
            AddColumn("dbo.HealthRecords", "animal_id", c => c.Int());
            AddColumn("dbo.Foods", "feedings_id", c => c.Int());
            AddColumn("dbo.PerformFeedings", "food_id", c => c.Int());
            AddColumn("dbo.Animals", "sector_id", c => c.Int());
            AddColumn("dbo.Animals", "feedings_id", c => c.Int());
            DropColumn("dbo.Reproductions", "animalFemale");
            DropColumn("dbo.Reproductions", "animalMale");
            DropColumn("dbo.HealthRecords", "animal");
            DropColumn("dbo.PerformFeedings", "food");
            DropColumn("dbo.Animals", "sector");
            DropColumn("dbo.Animals", "feedings");
            CreateIndex("dbo.Reproductions", "animalMale_id");
            CreateIndex("dbo.Reproductions", "animalFemale_id");
            CreateIndex("dbo.HealthRecords", "animal_id");
            CreateIndex("dbo.Foods", "feedings_id");
            CreateIndex("dbo.PerformFeedings", "food_id");
            CreateIndex("dbo.Animals", "sector_id");
            CreateIndex("dbo.Animals", "feedings_id");
            AddForeignKey("dbo.Reproductions", "animalMale_id", "dbo.Animals", "id");
            AddForeignKey("dbo.Reproductions", "animalFemale_id", "dbo.Animals", "id");
            AddForeignKey("dbo.HealthRecords", "animal_id", "dbo.Animals", "id");
            AddForeignKey("dbo.Animals", "sector_id", "dbo.Sectors", "id");
            AddForeignKey("dbo.Animals", "feedings_id", "dbo.Feedings", "id");
            AddForeignKey("dbo.PerformFeedings", "food_id", "dbo.Foods", "id");
            AddForeignKey("dbo.Foods", "feedings_id", "dbo.Feedings", "id");
        }
    }
}
