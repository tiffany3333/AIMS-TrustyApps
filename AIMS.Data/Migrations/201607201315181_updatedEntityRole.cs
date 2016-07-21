namespace AIMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedEntityRole : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EntityRole", "ReferredEntityId", "dbo.Entity");
            DropIndex("dbo.EntityRole", new[] { "ReferredEntityId" });
            AlterColumn("dbo.EntityRole", "ReferredEntityId", c => c.Int());
            CreateIndex("dbo.EntityRole", "ReferredEntityId");
            AddForeignKey("dbo.EntityRole", "ReferredEntityId", "dbo.Entity", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EntityRole", "ReferredEntityId", "dbo.Entity");
            DropIndex("dbo.EntityRole", new[] { "ReferredEntityId" });
            AlterColumn("dbo.EntityRole", "ReferredEntityId", c => c.Int(nullable: false));
            CreateIndex("dbo.EntityRole", "ReferredEntityId");
            AddForeignKey("dbo.EntityRole", "ReferredEntityId", "dbo.Entity", "Id", cascadeDelete: true);
        }
    }
}
