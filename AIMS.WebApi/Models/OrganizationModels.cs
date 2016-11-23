using AIMS.Data;
using System;
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

    public class OrganizationDetailsResponseJSON
    {
        public int OrganizationId { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(512)]
        public string Description { get; set; }

        [MaxLength(100)]
        public String Address { get; set; }

        [MaxLength(50)]
        public String City { get; set; }

        [MaxLength(50)]
        public String State { get; set; }

        [MaxLength(20)]
        public String ZipCode { get; set; }

        [MaxLength(20)]
        public String PhoneNumber { get; set; }

        public OrganizationDetailsResponseJSON(Organization org)
        {
            OrganizationId = org.OrganizationId;
            Name = org.Name;
            Description = org.Description;
            Address = org.Address;
            City = org.City;
            State = org.State;
            ZipCode = org.ZipCode;
            PhoneNumber = org.PhoneNumber;            
        }
    }
}