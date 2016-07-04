using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMS.Data
{
    public class Contact
    {
        public int Id { get; set; }
        public int? EntityId { get; set; }
        public enum TypeEnum
        {
            Phone,
            Email,
            Emergency
        }
        public TypeEnum Type { get; set; }
        public bool IsPrimary { get; set; }
        [MaxLength(45)]
        public string Label { get; set; }
        //Change varible name to ContactDetail to make naming convention consistent
        [MaxLength(140)]
        public string ContactDetail { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public virtual Entity Entity { get; set; }

    }
}
