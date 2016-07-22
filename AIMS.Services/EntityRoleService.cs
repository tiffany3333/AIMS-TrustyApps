using AIMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMS.Services
{
    class EntityRoleService
    {
        public bool CreateEntityRole(int entityId, int roleId, int referredEntity)
        {
            using (var ctx = new AIMSDbContext())
            {
                var newEntityRole = new EntityRole
                {
                    EntityId = entityId,
                    RoleId = roleId,
                    ReferredEntityId = referredEntity,
                    CreatedAt = DateTimeOffset.UtcNow
                };
                ctx.EntityRoles.Add(newEntityRole);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
