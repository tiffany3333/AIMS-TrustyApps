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
              p => p.Id,
              new Role { Id = 0, RoleName = "member", Description = "member", CreatedAt = DateTimeOffset.UtcNow }
            );
            //
        }
    }
}
