namespace A2projeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourthCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Personnels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        documentNumber = c.Int(nullable: false),
                        gender = c.String(),
                        workShift = c.String(),
                        expertises = c.Int(nullable: false),
                        memberSince = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Personnels");
        }
    }
}
