namespace A2projeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        tag_code = c.String(),
                        specimen = c.Int(nullable: false),
                        dateBirth = c.DateTime(nullable: false),
                        age = c.Int(nullable: false),
                        gender = c.String(),
                        locomotion = c.String(),
                        color = c.String(),
                        characteristics = c.String(),
                        extinct = c.Boolean(nullable: false),
                        reproduction_characteristcs = c.String(),
                        standards_of_care = c.String(),
                        feedings_id = c.Int(),
                        sector_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Feedings", t => t.feedings_id)
                .ForeignKey("dbo.Sectors", t => t.sector_id)
                .Index(t => t.feedings_id)
                .Index(t => t.sector_id);
            
            CreateTable(
                "dbo.Feedings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        feedingSchedule = c.String(),
                        feedingFrequencyPerDay = c.Int(nullable: false),
                        eatingHabits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.PerformFeedings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        quantity = c.Int(nullable: false),
                        feedingDate = c.DateTime(nullable: false),
                        food_id = c.Int(),
                        Feedings_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Foods", t => t.food_id)
                .ForeignKey("dbo.Feedings", t => t.Feedings_id)
                .Index(t => t.food_id)
                .Index(t => t.Feedings_id);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        manufacturer = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Sectors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        playGround = c.String(),
                        availableForVisit = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Animals", "sector_id", "dbo.Sectors");
            DropForeignKey("dbo.Animals", "feedings_id", "dbo.Feedings");
            DropForeignKey("dbo.PerformFeedings", "Feedings_id", "dbo.Feedings");
            DropForeignKey("dbo.PerformFeedings", "food_id", "dbo.Foods");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PerformFeedings", new[] { "Feedings_id" });
            DropIndex("dbo.PerformFeedings", new[] { "food_id" });
            DropIndex("dbo.Animals", new[] { "sector_id" });
            DropIndex("dbo.Animals", new[] { "feedings_id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Sectors");
            DropTable("dbo.Foods");
            DropTable("dbo.PerformFeedings");
            DropTable("dbo.Feedings");
            DropTable("dbo.Animals");
        }
    }
}
