using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMS.Data
{
    public class EntityProperty
    {
        [Key]
        [Column(Order = 1)]
        public int EntityId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int PropertyDefId { get; set; }
        [MaxLength(256)]
        public string Value { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public virtual Entity Entity { get; set; }
        public virtual PropertyDef PropertyDef { get; set; }

    }
}
