namespace AIMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteredEntityProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EntityProperty", "Title", c => c.String(maxLength: 256));
            AddColumn("dbo.EntityProperty", "Description", c => c.String(maxLength: 256));
            AddColumn("dbo.EntityProperty", "Link", c => c.String(maxLength: 256));
            AddColumn("dbo.EntityProperty", "ImageURL", c => c.String(maxLength: 256));
            DropColumn("dbo.EntityProperty", "Value");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EntityProperty", "Value", c => c.String(maxLength: 256));
            DropColumn("dbo.EntityProperty", "ImageURL");
            DropColumn("dbo.EntityProperty", "Link");
            DropColumn("dbo.EntityProperty", "Description");
            DropColumn("dbo.EntityProperty", "Title");
        }
    }
}
