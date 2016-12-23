namespace AIMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedImageFilenameResponsetoSurveyResponse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SurveyResponse", "ImageFilenameRepsonse", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SurveyResponse", "ImageFilenameRepsonse");
        }
    }
}
