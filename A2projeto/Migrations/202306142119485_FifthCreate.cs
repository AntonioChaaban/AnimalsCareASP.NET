namespace A2projeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FifthCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personnels", "CPFFormatado", c => c.String());
            AlterColumn("dbo.Personnels", "documentNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Personnels", "documentNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Personnels", "CPFFormatado");
        }
    }
}
