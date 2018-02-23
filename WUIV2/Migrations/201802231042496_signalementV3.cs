namespace WUIV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class signalementV3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Signalement", "dateSignalement", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Signalement", "dateSignalement");
        }
    }
}
