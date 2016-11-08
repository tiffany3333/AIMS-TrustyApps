using AIMS.Data;
using System;
using static AIMS.Data.Entity;

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
