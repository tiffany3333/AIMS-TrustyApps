using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMS.Data
{
    public class EntityRole
    {
        public int EntityId { get; set; }
        public int RoleId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public virtual Entity Entity { get; set; }
        public virtual Role Role { get; set; }
    }
}
