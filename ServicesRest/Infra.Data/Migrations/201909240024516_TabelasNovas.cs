namespace Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelasNovas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        ContactName = c.String(),
                        Email = c.String(),
                        Landline = c.String(),
                        CellPhone = c.String(),
                        Organization_ID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Organization", t => t.Organization_ID, cascadeDelete: true)
                .Index(t => t.Organization_ID);
            
            CreateTable(
                "dbo.Organization",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        CNPJ = c.String(),
                        User_ID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_ID, cascadeDelete: true)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        First_name = c.String(nullable: false, maxLength: 50),
                        Last_name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contact", "Organization_ID", "dbo.Organization");
            DropForeignKey("dbo.Organization", "User_ID", "dbo.Users");
            DropIndex("dbo.Contact", new[] { "Organization_ID" });
            DropIndex("dbo.Organization", new[] { "User_ID" });
            DropTable("dbo.Users");
            DropTable("dbo.Organization");
            DropTable("dbo.Contact");
        }
    }
}
