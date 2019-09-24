namespace Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajustOrganizationTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organization", "Valid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Organization", "Valid");
        }
    }
}
