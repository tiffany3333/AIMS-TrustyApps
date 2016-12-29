using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIMS.Data
{
    public class EntityProperty
    {
        //[Key]
        //[Column(Order = 1)]
        public int EntityId { get; set; }
        //[Key]
        //[Column(Order = 2)]
        //public int PropertyDefId { get; set; }

        [Key]
        public int EntityPropertyId { get; set; }

        [MaxLength(256)]
        public string Title { get; set; }
        [MaxLength(256)]
        public string Description { get; set; }
        [MaxLength(256)]
        public string Link { get; set; }
        [MaxLength(256)]
        public string ImageURL { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public virtual Entity Entity { get; set; }
        //public virtual PropertyDef PropertyDef { get; set; }

    }
}
