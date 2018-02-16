namespace WUIV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctifs_user : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Utilisateur", "role", c => c.String(nullable: false));
            //gestion de l'enum
            Sql(@"ALTER TABLE [dbo].[Utilisateur] ADD CONSTRAINT [FK_dbo.Utilisateur_dbo.UtilisateurConstraints_ConstraintCode] CHECK (role IN ('ADMINISTRATEUR','MEMBRE'))");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Utilisateur", "role", c => c.String());

            Sql(@"ALTER TABLE [dbo].[Utilisateur] DROP CONSTRAINT [FK_dbo.Utilisateur_dbo.UtilisateurConstraints_ConstraintCode]");
        }
    }
}
