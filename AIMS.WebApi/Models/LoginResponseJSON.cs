using System;

namespace AIMS.WebApi.Models
{
    public class LoginResponseJSON
    {
        public string Token { get; set; }

        public DateTimeOffset Expiration { get; set; }
    }
}