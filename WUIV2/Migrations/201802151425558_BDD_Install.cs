namespace WUIV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BDD_Install : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animal",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nom = c.String(),
                        proprietaireId = c.Int(),
                        description = c.String(),
                        age = c.Int(nullable: false),
                        tatouage = c.Boolean(nullable: false),
                        puce = c.Boolean(nullable: false),
                        vaccin = c.Boolean(nullable: false),
                        castre = c.Boolean(nullable: false),
                        typeAnimalId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Utilisateur", t => t.proprietaireId)
                .ForeignKey("dbo.TypeAnimal", t => t.typeAnimalId)
                .Index(t => t.proprietaireId)
                .Index(t => t.typeAnimalId);
            
            CreateTable(
                "dbo.Utilisateur",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        mail = c.String(),
                        mdp = c.String(),
                        role = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        titre = c.String(),
                        contenu = c.String(),
                        messageParentId = c.Int(),
                        avisDeRecherche_id = c.Int(),
                        expediteur_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AvisDeRecherche", t => t.avisDeRecherche_id)
                .ForeignKey("dbo.Utilisateur", t => t.expediteur_id)
                .ForeignKey("dbo.Message", t => t.messageParentId)
                .Index(t => t.messageParentId)
                .Index(t => t.avisDeRecherche_id)
                .Index(t => t.expediteur_id);
            
            CreateTable(
                "dbo.AvisDeRecherche",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        titre = c.String(),
                        description = c.String(),
                        animal_id = c.Int(),
                        emplacement_Id = c.Int(),
                        membre_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Animal", t => t.animal_id)
                .ForeignKey("dbo.Emplacement", t => t.emplacement_Id)
                .ForeignKey("dbo.Utilisateur", t => t.membre_id)
                .Index(t => t.animal_id)
                .Index(t => t.emplacement_Id)
                .Index(t => t.membre_id);
            
            CreateTable(
                "dbo.Signalement",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        commentaire = c.String(),
                        emplacement_Id = c.Int(),
                        utilisateur_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Emplacement", t => t.emplacement_Id)
                .ForeignKey("dbo.Utilisateur", t => t.utilisateur_id)
                .Index(t => t.emplacement_Id)
                .Index(t => t.utilisateur_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Signalement", "utilisateur_id", "dbo.Utilisateur");
            DropForeignKey("dbo.Signalement", "emplacement_Id", "dbo.Emplacement");
            DropForeignKey("dbo.Animal", "typeAnimalId", "dbo.TypeAnimal");
            DropForeignKey("dbo.Animal", "proprietaireId", "dbo.Utilisateur");
            DropForeignKey("dbo.Message", "messageParentId", "dbo.Message");
            DropForeignKey("dbo.Message", "expediteur_id", "dbo.Utilisateur");
            DropForeignKey("dbo.Message", "avisDeRecherche_id", "dbo.AvisDeRecherche");
            DropForeignKey("dbo.AvisDeRecherche", "membre_id", "dbo.Utilisateur");
            DropForeignKey("dbo.AvisDeRecherche", "emplacement_Id", "dbo.Emplacement");
            DropForeignKey("dbo.AvisDeRecherche", "animal_id", "dbo.Animal");
            DropIndex("dbo.Signalement", new[] { "utilisateur_id" });
            DropIndex("dbo.Signalement", new[] { "emplacement_Id" });
            DropIndex("dbo.AvisDeRecherche", new[] { "membre_id" });
            DropIndex("dbo.AvisDeRecherche", new[] { "emplacement_Id" });
            DropIndex("dbo.AvisDeRecherche", new[] { "animal_id" });
            DropIndex("dbo.Message", new[] { "expediteur_id" });
            DropIndex("dbo.Message", new[] { "avisDeRecherche_id" });
            DropIndex("dbo.Message", new[] { "messageParentId" });
            DropIndex("dbo.Animal", new[] { "typeAnimalId" });
            DropIndex("dbo.Animal", new[] { "proprietaireId" });
            DropTable("dbo.Signalement");
            DropTable("dbo.AvisDeRecherche");
            DropTable("dbo.Message");
            DropTable("dbo.Utilisateur");
            DropTable("dbo.Animal");
        }
    }
}
