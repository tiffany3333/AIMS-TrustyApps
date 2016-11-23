using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMS.Data
{
    public class APIToken
    {
        public string token { get; set; }
        public DateTime expiration { get; set; }
    }
}
