namespace AIMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tookOutReferredEntity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EntityRole", "ReferredEntityId", "dbo.Entity");
            DropIndex("dbo.EntityRole", new[] { "ReferredEntityId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.EntityRole", "ReferredEntityId");
            AddForeignKey("dbo.EntityRole", "ReferredEntityId", "dbo.Entity", "Id");
        }
    }
}
