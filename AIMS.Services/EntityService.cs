using AIMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AIMS.Data.Entity;
using static AIMS.Data.User;

namespace AIMS.Services
{
    class EntityService
    {
        public int CreateEntity(MemberTypeEnum type)
        {
            using (var ctx = new AIMSDbContext())
            {
                var entity = new Entity
                {
                    CreatedAt = DateTimeOffset.UtcNow,
                    MemberType = type
                };
                ctx.Entities.Add(entity);
                ctx.SaveChanges();
                return entity.Id;
            }
                
        }
    }
}
