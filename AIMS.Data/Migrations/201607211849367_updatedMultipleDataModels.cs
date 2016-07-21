namespace AIMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedMultipleDataModels : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.User", "Avatar");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Avatar", c => c.Binary());
        }
    }
}
