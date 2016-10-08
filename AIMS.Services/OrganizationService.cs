using AIMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AIMS.Data.Organization;

namespace AIMS.Services
{
    class OrganizationService
    {
        public bool CreateOrganization(int entityId, string name, string description)
        {
            using (var ctx = new AIMSDbContext())
            {
                var newOrganization = new Organization
                {
                    Name = name,
                    Description = description,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow,
                };
                ctx.Organizations.Add(newOrganization);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
