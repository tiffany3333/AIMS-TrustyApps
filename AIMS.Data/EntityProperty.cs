using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMS.Data
{
    public class EntityProperty
    {
        [Key]
        public int EntityId { get; set; }
        [Key]
        public int PropertyDefId { get; set; }
        [MaxLength(256)]
        public string Value { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public virtual Entity Entity { get; set; }
        public virtual PropertyDef PropertyDef { get; set; }

    }
}
