using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AIMS.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMS.Models
{
    public class UserDetailsViewModel
    {
        public int UserId { get; set; }

        [MaxLength(45)]
        public string FirstName { get; set; }

        [MaxLength(45)]
        public string LastName { get; set; }

        public User.UserTypeEnum UserType { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        [System.ComponentModel.DefaultValue("Member")]
        public virtual ICollection<UserGroup> UserGroups { get; set; }
        
        public virtual List<EntityProperty> EntityProperties { get; set; }

        public virtual Entity Entity { get; set; }

        public UserDetailsViewModel (User user)
        {
            this.UserId = user.UserId;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.UserType = user.UserType;
            this.CreatedAt = user.CreatedAt;
            this.UpdatedAt = user.UpdatedAt;
            this.UserGroups = user.UserGroups;
            this.Entity = user.Entity;
            this.EntityProperties = new List<EntityProperty>();

            foreach (EntityProperty property in Entity.EntityProperties)
            {
                EntityProperty newProperty = new EntityProperty();
                newProperty = property;
                this.EntityProperties.Add(newProperty);
            }

        }
    }
}
