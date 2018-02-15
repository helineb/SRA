namespace WUIV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Emplacement",
                c => new
                    {
                        EmplacementId = c.Int(nullable: false, identity: true),
                        longitude = c.Single(nullable: false),
                        latitude = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.EmplacementId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Emplacement");
        }
    }
}
