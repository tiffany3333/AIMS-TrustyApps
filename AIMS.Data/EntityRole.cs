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
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public int? ReferredEntityId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public virtual Entity Entity { get; set; }
        public virtual Role Role { get; set; }
    }
}
