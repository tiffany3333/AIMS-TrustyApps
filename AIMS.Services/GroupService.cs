using AIMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AIMS.Data.Group;

namespace AIMS.Services
{
    public class GroupService
    {
        public int? CreateGroup(int? organizationId, string name)
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
                ctx.SaveChanges();
                return organizationId;
            }
        }
    }
}
