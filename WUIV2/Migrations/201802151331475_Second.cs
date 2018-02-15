namespace WUIV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Emplacement");
            CreateTable(
                "dbo.TypeAnimal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        libelle = c.Single(nullable: false),
                        description = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            DropColumn("dbo.Emplacement", "EmplacementId");
            AddColumn("dbo.Emplacement", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Emplacement", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Emplacement", "EmplacementId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Emplacement");
            DropColumn("dbo.Emplacement", "Id");
            DropTable("dbo.TypeAnimal");
            AddPrimaryKey("dbo.Emplacement", "EmplacementId");
        }
    }
}
