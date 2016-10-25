using AIMS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AIMS.Models
{
    public class OrganizationViewModel
    {
        public int OrganizationId { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        [MaxLength(512)]
        public string Description { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(50)]
        public string State { get; set; }
        [MaxLength(20)]
        public string ZipCode { get; set; }
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

        public OrganizationViewModel()
        {
        }

        public OrganizationViewModel (Organization organization)
        {
            this.OrganizationId = organization.OrganizationId;
            this.Name = organization.Name;
            this.Description = organization.Description;
            this.Address = organization.Address;
            this.City = organization.City;
            this.State = organization.State;
            this.ZipCode = organization.ZipCode;
            this.PhoneNumber = organization.PhoneNumber;
            this.CreatedAt = organization.CreatedAt;
            this.UpdatedAt = organization.UpdatedAt;
        }
    }
}
