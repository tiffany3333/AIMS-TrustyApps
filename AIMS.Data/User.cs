using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMS.Data
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(45)]
        public string FirstName { get; set; }
        [MaxLength(45)]
        public string LastName { get; set; }
        public byte[] Avatar { get; set; }
        public enum UserTypeEnum
        {

        }
        public UserTypeEnum UserType { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
    }
}
