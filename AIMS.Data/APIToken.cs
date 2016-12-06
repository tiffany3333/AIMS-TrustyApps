using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AIMS.Data
{
    public class APIToken
    {
        [Key]
        public string token { get; set; }
        public DateTime expiration { get; set; }
    }
}
