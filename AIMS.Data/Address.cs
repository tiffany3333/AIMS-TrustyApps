using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMS.Data
{
    public class Address
    {
        public int Id { get; set; }
        //Non-identifying relationship
        public int? EntityId { get; set; }
        public bool IsPrimary { get; set; }
        [MaxLength(256)]
        public string Address1 { get; set; }
        [MaxLength(256)]
        public string Address2 { get; set; }
        [MaxLength(256)]
        public string Address3 { get; set; }
        //Equal to VARCHAR(128) in Database 
        [MaxLength(128)]
        public string City { get; set; }
        [MaxLength(128)]
        public string State { get; set; }
        [MaxLength(128)]
        public string Country { get; set; }
        [MaxLength(128)]
        public string Zipcode { get; set; } 
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public virtual Entity Entity { get; set; }
    }
}
