using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMS.Data
{
    public class Event
    {
        public int Id { get; set; }
        public int? EntityId { get; set; }
        public int? EntityLocationId { get; set; }
        [MaxLength(45)]
        public string Name { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        [MaxLength(256)]
        public string Description { get; set; }
        public DateTimeOffset CreatedId { get; set; }
        public DateTimeOffset? UpdatedId { get; set; }
        public virtual Entity Entity { get; set; }
        public virtual EntityLocation EntityLocation { get; set; }

    }
}
