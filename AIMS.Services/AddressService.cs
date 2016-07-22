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

        public bool CreateAddress(int entityId, string address1, string address2, string address3, string city, string country, string state, string zipCode)
        {
            using (var ctx = new AIMSDbContext())
            {
                var newAddress =
                    new Address
                    {
                        EntityId = entityId,
                        Address1 = address1,
                        Address2 = address2,
                        Address3 = address3,
                        City = city,
                        Country = country,
                        CreatedAt = DateTimeOffset.UtcNow,
                        IsPrimary = true,
                        State = state,
                        Zipcode = zipCode,

                    };
                ctx.Addresses.Add(newAddress);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
