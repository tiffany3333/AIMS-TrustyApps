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
    public class Group
    {
        [Key]
        [ForeignKey("Entity")]
        [Column(Order = 1)]
        public int GroupId { get; set; }
        [Key]
        [ForeignKey("Entity")]
        [Column(Order = 2)]
        public MemberTypeEnum MemberType { get; set; }
        public int? OrganizationId { get; set; }
        [MaxLength(128)]
        public string Name { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual Entity Entity { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
        public virtual ICollection<SurveyGroup> SurveyGroups { get; set; }
    }
}
