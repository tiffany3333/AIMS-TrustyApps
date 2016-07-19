using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AIMS.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class AIMSDbContext : IdentityDbContext
    {
        public AIMSDbContext()
            : base("DefaultConnection")
        {
        }

        public static AIMSDbContext Create()
        {
            return new AIMSDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder
                .Configurations
                    .Add(new IdentityUserLoginConfiguration())
                    .Add(new IdentityUserRoleConfiguration());
        }

        //public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Entity> Entities { get; set; }
        public DbSet<EntityLocation> EntityLocations { get; set; }
        public DbSet<EntityProperty> EntityProperties { get; set; }
        public DbSet<EntityRole> EntityRoles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<PropertyDef> PropertyDefs { get; set; }
        public DbSet<Role> UserRoles { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyGroup> SurveyGroups { get; set; }
        public DbSet<SurveyInstance> SurveyInstances { get; set; }
        public DbSet<SurveyQuestion> SurveyQuestions { get; set; }
        public DbSet<SurveyResponse> SurveyResponses { get; set; }
        //Users for variable name already existed
        public DbSet<User> User { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserTimesheet> UserTimesheets { get; set; }
    }

    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentityUserLoginConfiguration()
        {
            HasKey(iul => iul.UserId);
        }
    }

    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityUserRoleConfiguration()
        {
            HasKey(iur => iur.RoleId);
        }
    }
}
