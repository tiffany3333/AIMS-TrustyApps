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
