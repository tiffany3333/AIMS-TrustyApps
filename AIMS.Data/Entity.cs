using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
            User,
            Group,
            Organization

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public MemberTypeEnum MemberType { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public virtual ICollection<EntityProperty> EntityProperties { get; set; }
        public virtual User User { get; set; }
        public virtual Group Group { get; set; }
        public virtual Organization Organiztion { get; set; }
    }
}
