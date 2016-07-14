using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMS.Data
{
    public class UserGroup
    {
        //Uncomment if neccessary
        [Key]
        //[ForeignKey("User")]
        [Column(Order = 1)]
        public int UserId { get; set; }
        [Key]
        //[ForeignKey("Group")]
        [Column(Order = 2)]
        public int GroupId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public virtual User User { get; set; }
        public virtual Group Group { get; set; }
    }
}
