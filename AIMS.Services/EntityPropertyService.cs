using AIMS.Data;
using AIMS.Models;
using System;

namespace AIMS.Services
{
    public class EntityPropertyService
    {
        public int CreateProperty(EntityPropertyViewModel entityPropertyVM)
        {
            using (var ctx = new AIMSDbContext())
            {
                EntityProperty newProperty = new EntityProperty
                {
                    EntityId = entityPropertyVM.EntityId,
                   
                    Title = entityPropertyVM.Title,
                    Description = entityPropertyVM.Description,
                    Link = entityPropertyVM.Link,
                    ImageURL = entityPropertyVM.ImageURL,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow,
                };

                Entity myEntity = ctx.Entities.Find(entityPropertyVM.EntityId);
                myEntity.EntityProperties.Add(newProperty);
                ctx.EntityProperties.Add(newProperty);

                ctx.SaveChanges();

                return newProperty.EntityPropertyId;
            }
        }
    }
}
