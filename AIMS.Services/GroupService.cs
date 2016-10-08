using AIMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AIMS.Data.Group;

namespace AIMS.Services
{
    class GroupService
    {
        public bool CreateGroup(int? organizationId, string name)
        {
            using (var ctx = new AIMSDbContext())
            {
                var newGroup =
                    new Group
                    {
                        OrganizationId = organizationId,
                        Name = name,
                        CreatedAt = DateTimeOffset.UtcNow,
                        UpdatedAt = DateTimeOffset.UtcNow,
                    };
                ctx.Groups.Add(newGroup);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
