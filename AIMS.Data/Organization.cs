using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AIMS.Data.Entity;

namespace AIMS.Data
{
    public class Organization
    {
        [Key]
        [ForeignKey("Entity")]
        [Column(Order = 1)]
        public int OrganizationId { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(512)]
        public string Description { get; set; }

        [MaxLength(100, ErrorMessage = "There is a maximum length of {1} characters.")]
        public String Address { get; set; }

        [MaxLength(50, ErrorMessage = "There is a maximum length of {1} characters.")]
        public String City { get; set; }

        [MaxLength(50, ErrorMessage = "There is a maximum length of {1} characters.")]
        public String State { get; set; }

        [MaxLength(20, ErrorMessage = "There is a maximum length of {1} characters.")]
        public String ZipCode { get; set; }

        [MaxLength(20, ErrorMessage = "There is a maximum length of {1} characters.")]
        [Display(Name = "Phone Number")]
        public String PhoneNumber { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual Entity Entity { get; set; }
    }
}
