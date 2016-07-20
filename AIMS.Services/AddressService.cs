using AIMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMS.Services
{
    public class AddressService
    {

        public IEnumerable<Address> GetAddresses()
        {
            using (var ctx = new AIMSDbContext())
            {
                return
                    ctx
                    .Addresses
                    .Where(e => e.Id == e.EntityId)
                    .Select(e => new Address
                    {
                        Address1 = e.Address1,
                        Address2 = e.Address2,
                        Address3 = e.Address3,
                        City = e.City,
                        Country = e.Country,
                        CreatedAt = e.CreatedAt,
                        EntityId = e.EntityId,
                        Id = e.Id,
                        IsPrimary = e.IsPrimary,
                        State = e.State,
                        UpdatedAt = e.UpdatedAt,
                        Zipcode = e.Zipcode
                    })
                    .ToArray();
            }
        }

        public bool CreateAddress(Entity entity, Address address)
        {
            using (var ctx = new AIMSDbContext())
            {
                var newAddress =
                    new Address
                    {
                        Id = address.Id,
                        EntityId = entity.Id,
                        Address1 = address.Address1,
                        Address2 = address.Address2,
                        Address3 = address.Address3,
                        City = address.City,
                        Country = address.Country,
                        CreatedAt = DateTimeOffset.UtcNow,
                        IsPrimary = true,
                        State = address.State,
                        Zipcode = address.Zipcode,

                    };
                ctx.Addresses.Add(newAddress);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
