namespace AIMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedKeyToAPIToken : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.APIToken",
                c => new
                    {
                        token = c.String(nullable: false, maxLength: 128),
                        expiration = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.token);
            
            CreateTable(
                "dbo.SurveyInstance",
                c => new
                    {
                        SurveyInstanceId = c.Int(nullable: false, identity: true),
                        SurveyId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdatedAt = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.SurveyInstanceId);
            
            AddColumn("dbo.SurveyResponse", "SurveyInstance_SurveyInstanceId", c => c.Int());
            CreateIndex("dbo.SurveyResponse", "SurveyInstance_SurveyInstanceId");
            AddForeignKey("dbo.SurveyResponse", "SurveyInstance_SurveyInstanceId", "dbo.SurveyInstance", "SurveyInstanceId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SurveyResponse", "SurveyInstance_SurveyInstanceId", "dbo.SurveyInstance");
            DropIndex("dbo.SurveyResponse", new[] { "SurveyInstance_SurveyInstanceId" });
            DropColumn("dbo.SurveyResponse", "SurveyInstance_SurveyInstanceId");
            DropTable("dbo.SurveyInstance");
            DropTable("dbo.APIToken");
        }
    }
}
