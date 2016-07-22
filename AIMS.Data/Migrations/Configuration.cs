namespace AIMS.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AIMS.Data.AIMSDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AIMS.Data.AIMSDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.UserRoles.AddOrUpdate(
                p => p.RoleName,
                new Role
                {
                  Id = 1,
                  RoleName = "member",
                  Description = "member",
                  CreatedAt = DateTimeOffset.UtcNow
                }
            );

            context.Entities.AddOrUpdate(
                p => p.MemberType,
                new Entity
                {
                    MemberType = Entity.MemberTypeEnum.Organization,
                    CreatedAt = DateTimeOffset.UtcNow,
                });

            context.Organizations.AddOrUpdate(
                e => e.Name,
                new Organization
                {
                    OrganizationId = 1,
                    Name = "Pending",
                    CreatedAt = DateTimeOffset.UtcNow,
                    Description = "Pending",
                });

            context.Entities.AddOrUpdate(
                e => e.MemberType,
                new Entity
                {
                    MemberType = Entity.MemberTypeEnum.Group,
                    CreatedAt = DateTimeOffset.UtcNow
                });

            context.Groups.AddOrUpdate(
                e => e.Name,
                new Group
                {
                    GroupId = 2,
                    Name = "Pending",
                    CreatedAt = DateTimeOffset.UtcNow,
                    OrganizationId = 1,
                });
        }
    }
}
