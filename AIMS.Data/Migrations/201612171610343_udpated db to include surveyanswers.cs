namespace AIMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class udpateddbtoincludesurveyanswers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SurveyResponse", "SurveyInstance_SurveyInstanceId", "dbo.SurveyInstance");
            DropIndex("dbo.SurveyResponse", new[] { "SurveyInstance_SurveyInstanceId" });
            CreateTable(
                "dbo.SurveyAnswer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SurveyQuestionId = c.Int(nullable: false),
                        TextResponse = c.String(maxLength: 512),
                        ValueResponse = c.Int(nullable: false),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdatedAt = c.DateTimeOffset(precision: 7),
                        SurveyInstance_SurveyInstanceId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SurveyInstance", t => t.SurveyInstance_SurveyInstanceId)
                .Index(t => t.SurveyInstance_SurveyInstanceId);
            
            DropColumn("dbo.SurveyResponse", "SurveyInstance_SurveyInstanceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SurveyResponse", "SurveyInstance_SurveyInstanceId", c => c.Int());
            DropForeignKey("dbo.SurveyAnswer", "SurveyInstance_SurveyInstanceId", "dbo.SurveyInstance");
            DropIndex("dbo.SurveyAnswer", new[] { "SurveyInstance_SurveyInstanceId" });
            DropTable("dbo.SurveyAnswer");
            CreateIndex("dbo.SurveyResponse", "SurveyInstance_SurveyInstanceId");
            AddForeignKey("dbo.SurveyResponse", "SurveyInstance_SurveyInstanceId", "dbo.SurveyInstance", "SurveyInstanceId");
        }
    }
}
