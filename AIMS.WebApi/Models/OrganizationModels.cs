using System.ComponentModel.DataAnnotations;

namespace AIMS.WebApi.Models
{
    public class OrganizationModels
    {
        public int OrganizationId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
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