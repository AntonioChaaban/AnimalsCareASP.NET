namespace A2projeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HealthRecords",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        physicalHealth = c.String(),
                        pregnancyIdentificationDay = c.DateTime(nullable: false),
                        pregnancyStage = c.String(),
                        pregnancyDay = c.DateTime(nullable: false),
                        dateOfDelivery = c.DateTime(nullable: false),
                        numberOfOffspring = c.Int(nullable: false),
                        description = c.String(),
                        animal_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Animals", t => t.animal_id)
                .Index(t => t.animal_id);
            
            CreateTable(
                "dbo.Infirms",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        physicalTreatment = c.String(),
                        pharmaceuticalTreatment = c.String(),
                        vaccine = c.String(),
                        frequencyOfTreatment = c.String(),
                        durationOfTreatment = c.String(),
                        treatmentStartDate = c.DateTime(nullable: false),
                        UserId = c.String(),
                        HealthRecords_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.HealthRecords", t => t.HealthRecords_id)
                .Index(t => t.HealthRecords_id);
            
            CreateTable(
                "dbo.Reproductions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        expectedMatingDate = c.DateTime(nullable: false),
                        matingDateHeld = c.DateTime(nullable: false),
                        scenarioDescription = c.String(),
                        descriptionAct = c.String(),
                        pregnancy = c.Boolean(nullable: false),
                        animalFemale_id = c.Int(),
                        animalMale_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Animals", t => t.animalFemale_id)
                .ForeignKey("dbo.Animals", t => t.animalMale_id)
                .Index(t => t.animalFemale_id)
                .Index(t => t.animalMale_id);
            
            AddColumn("dbo.PerformFeedings", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reproductions", "animalMale_id", "dbo.Animals");
            DropForeignKey("dbo.Reproductions", "animalFemale_id", "dbo.Animals");
            DropForeignKey("dbo.Infirms", "HealthRecords_id", "dbo.HealthRecords");
            DropForeignKey("dbo.HealthRecords", "animal_id", "dbo.Animals");
            DropIndex("dbo.Reproductions", new[] { "animalMale_id" });
            DropIndex("dbo.Reproductions", new[] { "animalFemale_id" });
            DropIndex("dbo.Infirms", new[] { "HealthRecords_id" });
            DropIndex("dbo.HealthRecords", new[] { "animal_id" });
            DropColumn("dbo.PerformFeedings", "UserId");
            DropTable("dbo.Reproductions");
            DropTable("dbo.Infirms");
            DropTable("dbo.HealthRecords");
        }
    }
}
