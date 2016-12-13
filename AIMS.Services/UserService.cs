using AIMS.Data;
using AIMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using static AIMS.Data.Entity;

namespace AIMS.Services
{
    public class UserService
    {
        private readonly Lazy<EntityService> _entitySvc = new Lazy<EntityService>();
        private readonly Lazy<AddressService> _addressSvc = new Lazy<AddressService>();
        private readonly Lazy<ContactService> _contactSvc = new Lazy<ContactService>();
        private readonly Lazy<EntityRoleService> _entityRoleSvc = new Lazy<EntityRoleService>();

        /*
            Using these lines of code when you want to create UserService for using

            private readonly Lazy<UserService> _userSvc;
            public WHATEVERController()
            {
                _userSvc =
                    new Lazy<UserService>(
                        () =>
                        {
                            var userName = User.Identity.GetUserName();
                            return new UserService(userName);
                        });
            }

        */

        private readonly string _userName;

        public UserService(string userName)
        {
            _userName = userName;
        }

        public UserService()
        {

        }

        //Because the e-mail - username in this case is unique so it will return only one unique userId
        public int? getCurrentUserId()
        {
            using (var ctx = new AIMSDbContext())
            {
                return ctx.Contacts.SingleOrDefault(c => c.ContactDetail == _userName).EntityId;
            }
        }

        public User GetUser(int id)
        {
            using (var ctx = new AIMSDbContext())
            {
                return ctx.User.SingleOrDefault(c => c.UserId == id);
            }
        }

        public int GetUserId(string userName)
        {
            using (var ctx = new AIMSDbContext())
            {
                //username is email address
                Contact contact = ctx.Contacts.SingleOrDefault(c => c.ContactDetail == userName);
                if (contact != null)
                {
                    User myUser = ctx.User.SingleOrDefault(e => e.Entity.Id == contact.EntityId);
                    return myUser.UserId;
                }
                else
                {
                    return -1;
                }
            }
        }

        //Get all users
        public List<User> GetUsers()
        {
            List<User> myUsers = new List<User>();

            using (var ctx = new AIMSDbContext())
            {
                foreach (User myUser in ctx.User.ToList())
                {
                    myUsers.Add(myUser);
                }

                return myUsers;
            }
        }

        //Keep in mind, when a new user is created, a new entity must be created first, and via the wireframes, a new phone contact, email contact, and address must be created too
        public bool CreateUser(RegisterUserViewModel registerVM)
        {
            using (var ctx = new AIMSDbContext())
            {
                //Create a new entity
                bool retVal = false;
                int entityId = _entitySvc.Value.CreateEntity(MemberTypeEnum.User);

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
                _contactSvc.Value.CreateContact(entityId, registerVM.EmailContactDetail, registerVM.EmailLabel, registerVM.Type);

                //Create Phone Contact
                _contactSvc.Value.CreateContact(entityId, registerVM.PhoneContactDetail, registerVM.PhoneLabel, registerVM.Type);

                //Create Address
                _addressSvc.Value.CreateAddress(entityId, registerVM.Address1, registerVM.Address2, registerVM.Address3, registerVM.City, registerVM.Country, registerVM.State, registerVM.Zipcode);

                //Create Default Entity Roles with RoleId = 1, and GroupId = 2 if not specified by user input
                _entityRoleSvc.Value.CreateEntityRole(entityId, registerVM.RoleId ?? 1, registerVM.ReferredEntityId ?? 2);

                return ctx.SaveChanges() == 1; 

            }
        }   
    }
}
