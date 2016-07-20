using AIMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMS.Services
{
    public class ContactService
    {


        public bool CreateContact(Entity entity, Contact contact)
        {
            using (var ctx = new AIMSDbContext())
            {
                var newContact =
                    new Contact
                    {
                        Id = contact.Id,
                        EntityId = entity.Id,
                        ContactDetail = contact.ContactDetail,
                        CreatedAt = DateTimeOffset.UtcNow,
                        IsPrimary = false,
                        Label = contact.Label,
                        Type = contact.Type,
                        UpdatedAt = contact.UpdatedAt
                    };
                ctx.Contacts.Add(newContact);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
