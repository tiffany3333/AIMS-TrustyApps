using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMS.Data
{
    public class Group
    {
        [Key]
        [ForeignKey("Entity")]
        public int GroupId { get; set; }
        public int? OrganizationId { get; set; }
        [MaxLength(128)]
        public string Name { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public virtual Organization Organization { get; set; }
        [Required]
        public virtual Entity Entity { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
        public virtual ICollection<SurveyGroup> SurveyGroups { get; set; }
    }
}
