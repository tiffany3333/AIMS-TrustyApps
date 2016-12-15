namespace AIMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedavalueparametertotheSurveyResponsemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SurveyResponse", "ValueResponse", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SurveyResponse", "ValueResponse");
        }
    }
}
