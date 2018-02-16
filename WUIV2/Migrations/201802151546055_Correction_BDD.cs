namespace WUIV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correction_BDD : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TypeAnimal", "libelle", c => c.String());
            AlterColumn("dbo.TypeAnimal", "description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TypeAnimal", "description", c => c.Single(nullable: false));
            AlterColumn("dbo.TypeAnimal", "libelle", c => c.Single(nullable: false));
        }
    }
}
