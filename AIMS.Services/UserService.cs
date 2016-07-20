using AIMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMS.Services
{
    public class UserService
    {

        public bool CreateUser(Entity entity, User user)
        {
            using (var ctx = new AIMSDbContext())
            {
                var newUser =
                    new User
                    {
                        UserId = entity.Id,
                        Avatar = user.Avatar,
                        CreatedAt = user.CreatedAt,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        UpdatedAt = user.UpdatedAt,
                        UserType = user.UserType,
                        UserGroups = user.UserGroups
                    };
                ctx.User.Add(newUser);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
