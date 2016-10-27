namespace AIMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrganizationAdds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organization", "Address", c => c.String(maxLength: 100));
            AddColumn("dbo.Organization", "City", c => c.String(maxLength: 50));
            AddColumn("dbo.Organization", "State", c => c.String(maxLength: 50));
            AddColumn("dbo.Organization", "ZipCode", c => c.String(maxLength: 20));
            AddColumn("dbo.Organization", "PhoneNumber", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Organization", "PhoneNumber");
            DropColumn("dbo.Organization", "ZipCode");
            DropColumn("dbo.Organization", "State");
            DropColumn("dbo.Organization", "City");
            DropColumn("dbo.Organization", "Address");
        }
    }
}
