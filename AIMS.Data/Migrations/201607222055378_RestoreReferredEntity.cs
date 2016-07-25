namespace AIMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestoreReferredEntity : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.EntityRole", "ReferredEntityId");
            AddForeignKey("dbo.EntityRole", "ReferredEntityId", "dbo.Entity", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EntityRole", "ReferredEntityId", "dbo.Entity");
            DropIndex("dbo.EntityRole", new[] { "ReferredEntityId" });
        }
    }
}
