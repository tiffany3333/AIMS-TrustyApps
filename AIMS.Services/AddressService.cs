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

        //public IEnumerable<Address> GetAddresses()
        //{
        //    using (var ctx = new AIMSDbContext())
        //    {
                
        //    }
        //}

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
