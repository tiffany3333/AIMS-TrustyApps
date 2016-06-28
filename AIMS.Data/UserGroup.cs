using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMS.Data
{
    public class UserGroup
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public virtual User User { get; set; }
        public virtual Group Group { get; set; }
    }
}
