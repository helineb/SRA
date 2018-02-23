namespace WUIV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class signalementUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Signalement", "adresse", c => c.String());
            AddColumn("dbo.Signalement", "ville", c => c.String());
            AddColumn("dbo.Signalement", "avisDeRecherche_id", c => c.Int());
            CreateIndex("dbo.Signalement", "avisDeRecherche_id");
            AddForeignKey("dbo.Signalement", "avisDeRecherche_id", "dbo.AvisDeRecherche", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Signalement", "avisDeRecherche_id", "dbo.AvisDeRecherche");
            DropIndex("dbo.Signalement", new[] { "avisDeRecherche_id" });
            DropColumn("dbo.Signalement", "avisDeRecherche_id");
            DropColumn("dbo.Signalement", "ville");
            DropColumn("dbo.Signalement", "adresse");
        }
    }
}
