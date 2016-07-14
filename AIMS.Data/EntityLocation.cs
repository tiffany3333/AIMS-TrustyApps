using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMS.Data
{
    public class EntityLocation
    {
        public int Id { get; set; }
        public int? EntityId { get; set; }
        [MaxLength(45)]
        public string Label { get; set; }
        public float Latitude { get; set; }
        public float Longtitude { get; set; }
        public int Radius { get; set; }
        [MaxLength(4)]
        public string Unit { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public virtual Entity Entity { get; set; }
        public virtual ICollection<UserTimesheet> UserTimesheets { get; set; }
    }
}
