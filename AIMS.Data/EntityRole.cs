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
    public class EntityRole
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Entity")]
        public int EntityId { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("Entity")]
        public MemberTypeEnum MemberType { get; set; }
        [Key]
        [Column(Order = 3)]
        public int RoleId { get; set; }
        //Circular Relationship
        [ForeignKey("ReferredEntity")]
        [Column(Order = 4)]
        public int? ForEntity { get; set; }
        [ForeignKey("ReferredEntity")]
        [Column(Order = 5)]
        public MemberTypeEnum? ForEntityMemberType { get; set; }
        public virtual Entity ReferredEntity { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public virtual Entity Entity { get; set; }
        public virtual Role Role { get; set; }
    }
}
