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
        public IEnumerable<Contact> GetContactInfo()
        {
            using (var ctx = new AIMSDbContext())
            {
                return
                    ctx
                    .Contacts
                    .Where(e => e.Id == e.EntityId)
                    .Select(e => new Contact
                    {
                        Id = e.Id,
                        EntityId = e.EntityId,
                        ContactDetail = e.ContactDetail,
                        IsPrimary = e.IsPrimary,
                        Label = e.Label,
                        CreatedAt = e.CreatedAt,
                        Type = e.Type,
                        UpdatedAt = e.UpdatedAt
                    })
                    .ToArray();
            }
        }

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
