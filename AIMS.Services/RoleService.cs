using AIMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMS.Services
{
    class RoleService
    {
        public int CreateRole()
        {
            using (var ctx = new AIMSDbContext())
            {
                var role = new Role
                {
                    CreatedAt = DateTimeOffset.UtcNow,
                };
                ctx.UserRoles.Add(role);
                ctx.SaveChanges();
                return role.Id;
            }
        }
    }
}
