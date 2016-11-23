using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AIMS.Data.User;
using System.ComponentModel.DataAnnotations;
using AIMS.Data;

namespace AIMS.Models
{
    public class AssignUserViewModel
    {
        public int UserId { get; set; }

        [MaxLength(45)]
        public string FirstName { get; set; }

        [MaxLength(45)]
        public string LastName { get; set; }

        public UserTypeEnum UserType { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        public bool IsAssigned { get; set; }

        public virtual ICollection<UserGroup> UserGroups { get; set; }

        public AssignUserViewModel(User user)
        {
            this.UserId = user.UserId;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.UserType = user.UserType;
            this.CreatedAt = user.CreatedAt;
            this.UpdatedAt = user.UpdatedAt;
            this.UserGroups = user.UserGroups;
        }
    }
}
