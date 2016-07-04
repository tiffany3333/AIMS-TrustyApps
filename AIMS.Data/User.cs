using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMS.Data
{
    public class User
    {
        [Key]
        [ForeignKey("Entity")]
        public int UserId { get; set; }
        [MaxLength(45)]
        public string FirstName { get; set; }
        [MaxLength(45)]
        public string LastName { get; set; }
        public byte[] Avatar { get; set; }
        public enum UserTypeEnum
        {
            Student,
            Provider,
            Employer,
            Admin,
            Teacher
        }
        public UserTypeEnum UserType { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
        [Required]
        public virtual Entity Entity { get; set; }
    }
}
