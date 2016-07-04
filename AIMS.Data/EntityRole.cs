using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMS.Data
{
    public class EntityRole
    {
        [Key]
        public int EntityId { get; set; }
        [Key]
        public int RoleId { get; set; }
        //Circular Relationship
        [ForeignKey("ReferredEntity")]
        public int? ForEntity { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public virtual Entity Entity { get; set; }
        public virtual Entity ReferredEntity { get; set; }
        public virtual Role Role { get; set; }
    }
}
