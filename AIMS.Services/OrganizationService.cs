using AIMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AIMS.Data.Organization;
using AIMS.Models;

namespace AIMS.Services
{
    public class OrganizationService
    {
        //??!!TODO need to deal with Entity linking here.  Currently throws foreign key exception.
        public int CreateOrganization(string name, string description)
        {
            using (var ctx = new AIMSDbContext())
            {
                var newOrganization = new Organization
                {
                    Name = name,
                    Description = description,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow,
                };
                ctx.Organizations.Add(newOrganization);
                ctx.SaveChanges();
                return newOrganization.OrganizationId;
            }
        }

        public List<OrganizationViewModel> GetOrganizations()
        {
            List<OrganizationViewModel> myOrganizations = new List<OrganizationViewModel>();

            using (var ctx = new AIMSDbContext())
            {
                foreach (Organization org in ctx.Organizations.ToList())
                {
                    OrganizationViewModel myOrganization = new OrganizationViewModel(org);
                    myOrganizations.Add(myOrganization);
                }

                return myOrganizations;
            }
        }

        public OrganizationViewModel CreateOrganizationVM(int organizationId)
        {
            OrganizationViewModel myOrganizationVM;

            using (var ctx = new AIMSDbContext())
            {
                //TODO More error handling here
                myOrganizationVM = new OrganizationViewModel(ctx.Organizations.Find(organizationId));
            }
            return myOrganizationVM;
        }
    }
}
