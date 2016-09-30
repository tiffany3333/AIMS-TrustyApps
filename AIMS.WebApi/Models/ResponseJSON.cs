using System;
using System.ComponentModel.DataAnnotations;

namespace AIMS.WebApi.Models
{
    public class ResponseJSON
    {
        public string Token { get; set; }

        public DateTimeOffset Expiration { get; set; }
    }

    public class GroupResponseJSON
    {
        public int group_id { get; set; }

        [MaxLength(128)]
        public string name { get; set; }
    }

    public class OrganizationResponseJSON
    {
        public int organization_id { get; set; }

        [MaxLength(256)]
        public string name { get; set; }

        [MaxLength(512)]
        public string description { get; set; }

    }
}