using AIMS.Data;
using AIMS.Models;
using AIMS.Models.cs;
using AIMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AIMS.Data.Contact;
using static AIMS.Data.Entity;

namespace AIMS.Services
{
    public class UserService
    {
        private readonly EntityService _entitySvc = new EntityService();
        private readonly AddressService _addressSvc = new AddressService();
        private readonly ContactService _contactSvc = new ContactService();

        public IEnumerable<User> GetUsers(int Id)
        {
            using (var ctx = new AIMSDbContext())
            {
                return
                    ctx
                    .User
                    .Where(e => e.UserId == Id)
                    .Select(e => new User
                    {
                        UserId = e.UserId,
                        CreatedAt = e.CreatedAt,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        UpdatedAt = e.UpdatedAt,
                        UserGroups = e.UserGroups,
                        UserType = e.UserType
                    })
                    .ToArray();
            }
        }

        public bool CreateUser(RegisterUserViewModel registerVM)
        {
            using (var ctx = new AIMSDbContext())
            {
                int entityId = _entitySvc.CreateEntity(MemberTypeEnum.User);
                
                var newUser =
                    new User
                    {
                        UserId = entityId,
                        CreatedAt = DateTimeOffset.UtcNow,
                        FirstName = registerVM.FirstName,
                        LastName = registerVM.LastName,
                        UserType = registerVM.UserType,
                    };
                ctx.User.Add(newUser);

                //Create Email Contact
                _contactSvc.CreateContact(entityId, registerVM.EmailContactDetail, registerVM.EmailLabel, registerVM.Type);
                //Create Phone Contact
                _contactSvc.CreateContact(entityId, registerVM.PhoneContactDetail, registerVM.PhoneLabel, registerVM.Type);
                //Create Address
                _addressSvc.CreateAddress(entityId, registerVM.Address1, registerVM.Address2, registerVM.Address3, registerVM.City, registerVM.Country, registerVM.State, registerVM.Zipcode);
                //Create Entity Roles

                return ctx.SaveChanges() == 1;

            }
        }

    }

}
