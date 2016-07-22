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
        private readonly RoleService _roleSvc = new RoleService();
        private readonly AddressService _addressSvc = new AddressService();
        private readonly ContactService _contactSvc = new ContactService();
        private readonly EntityRoleService _entityRoleSvc = new EntityRoleService();

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

        //Keep in mind, when a new user is created, a new entity must be created first, and via the wireframes, a new phone contact, email contact, and address must be created too
        public bool CreateUser(RegisterUserViewModel registerVM)
        {
            using (var ctx = new AIMSDbContext())
            {
                //Create a new entity
                int entityId = _entitySvc.CreateEntity(MemberTypeEnum.User);
                int roleId = _roleSvc.CreateRole();
                
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
                _entityRoleSvc.CreateEntityRole(entityId, roleId, registerVM.ReferredEntityId);

                return ctx.SaveChanges() == 1;

            }
        }

    }

}
