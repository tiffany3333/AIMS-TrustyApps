using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMS.Data
{
    public class Entity
    {
        public int Id { get; set; }
        public enum MemberTypeEnum
        {

        }
        public MemberTypeEnum MemberType { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public virtual ICollection<EntityProperty> EntityProperties { get; set; }
    }
}
