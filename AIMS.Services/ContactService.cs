using AIMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AIMS.Data.Contact;

namespace AIMS.Services
{
    public class ContactService
    {
        private readonly EntityService _entitySvc = new EntityService();

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

        public bool CreateContact(int entityId, string contactDetail, string label, TypeEnum type)
        {
            using (var ctx = new AIMSDbContext())
            {
                var newContact =
                    new Contact
                    {
                        EntityId = entityId,
                        ContactDetail = contactDetail,
                        CreatedAt = DateTimeOffset.UtcNow,
                        IsPrimary = true,
                        Label = label,
                        Type = type,
                    };
                ctx.Contacts.Add(newContact);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
