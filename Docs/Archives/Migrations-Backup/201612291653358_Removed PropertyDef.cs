namespace AIMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedPropertyDef : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EntityProperty", "PropertyDefId", "dbo.PropertyDef");
            DropIndex("dbo.EntityProperty", new[] { "PropertyDefId" });
            DropPrimaryKey("dbo.EntityProperty");
            AddColumn("dbo.EntityProperty", "EntityPropertyId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.EntityProperty", "EntityPropertyId");
            DropColumn("dbo.EntityProperty", "PropertyDefId");
            DropTable("dbo.PropertyDef");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PropertyDef",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 45),
                        Description = c.String(maxLength: 256),
                        ValueType = c.String(maxLength: 45),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdatedAt = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.EntityProperty", "PropertyDefId", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.EntityProperty");
            DropColumn("dbo.EntityProperty", "EntityPropertyId");
            AddPrimaryKey("dbo.EntityProperty", new[] { "EntityId", "PropertyDefId" });
            CreateIndex("dbo.EntityProperty", "PropertyDefId");
            AddForeignKey("dbo.EntityProperty", "PropertyDefId", "dbo.PropertyDef", "Id", cascadeDelete: true);
        }
    }
}
