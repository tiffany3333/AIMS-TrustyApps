namespace AIMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removednullableinorgmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Group", "OrganizationId", "dbo.Organization");
            DropIndex("dbo.Group", new[] { "OrganizationId" });
            AlterColumn("dbo.Group", "OrganizationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Group", "OrganizationId");
            AddForeignKey("dbo.Group", "OrganizationId", "dbo.Organization", "OrganizationId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Group", "OrganizationId", "dbo.Organization");
            DropIndex("dbo.Group", new[] { "OrganizationId" });
            AlterColumn("dbo.Group", "OrganizationId", c => c.Int());
            CreateIndex("dbo.Group", "OrganizationId");
            AddForeignKey("dbo.Group", "OrganizationId", "dbo.Organization", "OrganizationId");
        }
    }
}
