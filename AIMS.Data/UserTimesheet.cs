using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMS.Data
{
    public class UserTimesheet
    {
        public int Id { get; set; }
        public int? userId { get; set; }
        public int EntityLocationId { get; set; }
        public DateTimeOffset TimeIn { get; set; }
        public DateTimeOffset TimeOut { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public virtual User User { get; set; }
        public virtual EntityLocation EntityLocation { get; set; }
    }
}
