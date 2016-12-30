namespace AIMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityId = c.Int(),
                        IsPrimary = c.Boolean(nullable: false),
                        Address1 = c.String(maxLength: 256),
                        Address2 = c.String(maxLength: 256),
                        Address3 = c.String(maxLength: 256),
                        City = c.String(maxLength: 128),
                        State = c.String(maxLength: 128),
                        Country = c.String(maxLength: 128),
                        Zipcode = c.String(maxLength: 128),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdatedAt = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entity", t => t.EntityId)
                .Index(t => t.EntityId);
            
            CreateTable(
                "dbo.Entity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberType = c.Int(nullable: false),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EntityProperty",
                c => new
                    {
                        EntityId = c.Int(nullable: false),
                        PropertyDefId = c.Int(nullable: false),
                        Value = c.String(maxLength: 256),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdatedAt = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => new { t.EntityId, t.PropertyDefId })
                .ForeignKey("dbo.Entity", t => t.EntityId, cascadeDelete: true)
                .ForeignKey("dbo.PropertyDef", t => t.PropertyDefId, cascadeDelete: true)
                .Index(t => t.EntityId)
                .Index(t => t.PropertyDefId);
            
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
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        GroupId = c.Int(nullable: false),
                        OrganizationId = c.Int(nullable: false),
                        Name = c.String(maxLength: 128),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdatedAt = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.GroupId)
                .ForeignKey("dbo.Entity", t => t.GroupId)
                .ForeignKey("dbo.Organization", t => t.OrganizationId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Organization",
                c => new
                    {
                        OrganizationId = c.Int(nullable: false),
                        Name = c.String(maxLength: 256),
                        Description = c.String(maxLength: 512),
                        Address = c.String(maxLength: 100),
                        City = c.String(maxLength: 50),
                        State = c.String(maxLength: 50),
                        ZipCode = c.String(maxLength: 20),
                        PhoneNumber = c.String(maxLength: 20),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdatedAt = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.OrganizationId)
                .ForeignKey("dbo.Entity", t => t.OrganizationId)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.SurveyGroup",
                c => new
                    {
                        SurveyId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        LastSent = c.DateTimeOffset(nullable: false, precision: 7),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdatedAt = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => new { t.SurveyId, t.GroupId })
                .ForeignKey("dbo.Group", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Survey", t => t.SurveyId, cascadeDelete: true)
                .Index(t => t.SurveyId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Survey",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 45),
                        IsDeactivated = c.Boolean(nullable: false),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdatedAt = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SurveyQuestion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SurveyId = c.Int(nullable: false),
                        Question = c.String(maxLength: 256),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdatedAt = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Survey", t => t.SurveyId, cascadeDelete: true)
                .Index(t => t.SurveyId);
            
            CreateTable(
                "dbo.SurveyResponse",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SurveyQuestionId = c.Int(nullable: false),
                        TextResponse = c.String(maxLength: 512),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdatedAt = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SurveyQuestion", t => t.SurveyQuestionId, cascadeDelete: true)
                .Index(t => t.SurveyQuestionId);
            
            CreateTable(
                "dbo.UserGroup",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => new { t.UserId, t.GroupId })
                .ForeignKey("dbo.Group", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        FirstName = c.String(maxLength: 45),
                        LastName = c.String(maxLength: 45),
                        UserType = c.Int(nullable: false),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdatedAt = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Entity", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityId = c.Int(),
                        Type = c.Int(nullable: false),
                        IsPrimary = c.Boolean(nullable: false),
                        Label = c.String(maxLength: 45),
                        ContactDetail = c.String(maxLength: 140),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdatedAt = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entity", t => t.EntityId)
                .Index(t => t.EntityId);
            
            CreateTable(
                "dbo.EntityLocation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityId = c.Int(),
                        Label = c.String(maxLength: 45),
                        Latitude = c.Single(nullable: false),
                        Longtitude = c.Single(nullable: false),
                        Radius = c.Int(nullable: false),
                        Unit = c.String(maxLength: 4),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdatedAt = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entity", t => t.EntityId)
                .Index(t => t.EntityId);
            
            CreateTable(
                "dbo.UserTimesheet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        userId = c.Int(),
                        EntityLocationId = c.Int(nullable: false),
                        TimeIn = c.DateTimeOffset(nullable: false, precision: 7),
                        TimeOut = c.DateTimeOffset(nullable: false, precision: 7),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdatedAt = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EntityLocation", t => t.EntityLocationId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.userId)
                .Index(t => t.userId)
                .Index(t => t.EntityLocationId);
            
            CreateTable(
                "dbo.EntityRole",
                c => new
                    {
                        EntityId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        ReferredEntityId = c.Int(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => new { t.EntityId, t.RoleId })
                .ForeignKey("dbo.Entity", t => t.EntityId, cascadeDelete: true)
                .ForeignKey("dbo.Entity", t => t.ReferredEntityId)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.EntityId)
                .Index(t => t.RoleId)
                .Index(t => t.ReferredEntityId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        Description = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdatedAt = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityId = c.Int(),
                        EntityLocationId = c.Int(),
                        Name = c.String(maxLength: 45),
                        StartTime = c.DateTimeOffset(nullable: false, precision: 7),
                        EndTime = c.DateTimeOffset(nullable: false, precision: 7),
                        Description = c.String(maxLength: 256),
                        CreatedId = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdatedId = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entity", t => t.EntityId)
                .ForeignKey("dbo.EntityLocation", t => t.EntityLocationId)
                .Index(t => t.EntityId)
                .Index(t => t.EntityLocationId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.IdentityUser", t => t.IdentityUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.IdentityUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentityUser", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityUser", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "IdentityUser_Id", "dbo.IdentityUser");
            DropForeignKey("dbo.IdentityUserLogin", "IdentityUser_Id", "dbo.IdentityUser");
            DropForeignKey("dbo.IdentityUserClaim", "IdentityUser_Id", "dbo.IdentityUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Event", "EntityLocationId", "dbo.EntityLocation");
            DropForeignKey("dbo.Event", "EntityId", "dbo.Entity");
            DropForeignKey("dbo.EntityRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.EntityRole", "ReferredEntityId", "dbo.Entity");
            DropForeignKey("dbo.EntityRole", "EntityId", "dbo.Entity");
            DropForeignKey("dbo.UserTimesheet", "userId", "dbo.User");
            DropForeignKey("dbo.UserTimesheet", "EntityLocationId", "dbo.EntityLocation");
            DropForeignKey("dbo.EntityLocation", "EntityId", "dbo.Entity");
            DropForeignKey("dbo.Contact", "EntityId", "dbo.Entity");
            DropForeignKey("dbo.Address", "EntityId", "dbo.Entity");
            DropForeignKey("dbo.UserGroup", "UserId", "dbo.User");
            DropForeignKey("dbo.User", "UserId", "dbo.Entity");
            DropForeignKey("dbo.UserGroup", "GroupId", "dbo.Group");
            DropForeignKey("dbo.SurveyGroup", "SurveyId", "dbo.Survey");
            DropForeignKey("dbo.SurveyResponse", "SurveyQuestionId", "dbo.SurveyQuestion");
            DropForeignKey("dbo.SurveyQuestion", "SurveyId", "dbo.Survey");
            DropForeignKey("dbo.SurveyGroup", "GroupId", "dbo.Group");
            DropForeignKey("dbo.Group", "OrganizationId", "dbo.Organization");
            DropForeignKey("dbo.Organization", "OrganizationId", "dbo.Entity");
            DropForeignKey("dbo.Group", "GroupId", "dbo.Entity");
            DropForeignKey("dbo.EntityProperty", "PropertyDefId", "dbo.PropertyDef");
            DropForeignKey("dbo.EntityProperty", "EntityId", "dbo.Entity");
            DropIndex("dbo.IdentityUserLogin", new[] { "IdentityUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "IdentityUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Event", new[] { "EntityLocationId" });
            DropIndex("dbo.Event", new[] { "EntityId" });
            DropIndex("dbo.EntityRole", new[] { "ReferredEntityId" });
            DropIndex("dbo.EntityRole", new[] { "RoleId" });
            DropIndex("dbo.EntityRole", new[] { "EntityId" });
            DropIndex("dbo.UserTimesheet", new[] { "EntityLocationId" });
            DropIndex("dbo.UserTimesheet", new[] { "userId" });
            DropIndex("dbo.EntityLocation", new[] { "EntityId" });
            DropIndex("dbo.Contact", new[] { "EntityId" });
            DropIndex("dbo.User", new[] { "UserId" });
            DropIndex("dbo.UserGroup", new[] { "GroupId" });
            DropIndex("dbo.UserGroup", new[] { "UserId" });
            DropIndex("dbo.SurveyResponse", new[] { "SurveyQuestionId" });
            DropIndex("dbo.SurveyQuestion", new[] { "SurveyId" });
            DropIndex("dbo.SurveyGroup", new[] { "GroupId" });
            DropIndex("dbo.SurveyGroup", new[] { "SurveyId" });
            DropIndex("dbo.Organization", new[] { "OrganizationId" });
            DropIndex("dbo.Group", new[] { "OrganizationId" });
            DropIndex("dbo.Group", new[] { "GroupId" });
            DropIndex("dbo.EntityProperty", new[] { "PropertyDefId" });
            DropIndex("dbo.EntityProperty", new[] { "EntityId" });
            DropIndex("dbo.Address", new[] { "EntityId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.IdentityUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Event");
            DropTable("dbo.Role");
            DropTable("dbo.EntityRole");
            DropTable("dbo.UserTimesheet");
            DropTable("dbo.EntityLocation");
            DropTable("dbo.Contact");
            DropTable("dbo.User");
            DropTable("dbo.UserGroup");
            DropTable("dbo.SurveyResponse");
            DropTable("dbo.SurveyQuestion");
            DropTable("dbo.Survey");
            DropTable("dbo.SurveyGroup");
            DropTable("dbo.Organization");
            DropTable("dbo.Group");
            DropTable("dbo.PropertyDef");
            DropTable("dbo.EntityProperty");
            DropTable("dbo.Entity");
            DropTable("dbo.Address");
        }
    }
}
