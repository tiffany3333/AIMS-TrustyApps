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
        public int CreateOrganization(string name, string description, string address, string city, string state, string zip, string phone)
        {
            using (var ctx = new AIMSDbContext())
            {
                var newOrganization = new Organization
                {
                    Name = name,
                    Description = description,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow,
                    Address = address,
                    City = city,
                    State = state,
                    ZipCode = zip,
                    PhoneNumber = phone
                };

                var newEntity = new Entity
                {
                    MemberType = Entity.MemberTypeEnum.Organization,
                    CreatedAt = DateTimeOffset.UtcNow
                };
                newEntity.Organiztion = newOrganization;

                ctx.Entities.Add(newEntity);
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

        public OrganizationViewModel GetOrganization(int? id)
        {
            OrganizationViewModel myOrganization = new OrganizationViewModel();

            using (var ctx = new AIMSDbContext())
            {
                Organization org = ctx.Organizations.Find(id);
                if (org != null)
                {
                    myOrganization = new OrganizationViewModel(org);
                    return myOrganization;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool DeleteOrganization(int? id)
        {
            bool retVal = false;

            using (var ctx = new AIMSDbContext())
            {
                Organization org = ctx.Organizations.Find(id);
                if (org != null)
                {
                    ctx.Organizations.Remove(org);
                    ctx.SaveChanges();
                    retVal = true;
                }
            }
            
            return retVal;
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

        public bool EditOrganization(OrganizationViewModel organizationViewModel)
        {
            using (var ctx = new AIMSDbContext())
            {
                Organization organization = ctx.Organizations.Find(organizationViewModel.OrganizationId);

                organization.Name = organizationViewModel.Name;
                organization.Description = organizationViewModel.Description;
                organization.Address = organizationViewModel.Address;
                organization.City = organizationViewModel.City;
                organization.State = organizationViewModel.State;
                organization.ZipCode = organizationViewModel.ZipCode;
                organization.PhoneNumber = organizationViewModel.PhoneNumber;
                organization.UpdatedAt =  DateTimeOffset.UtcNow;

                ctx.Entry(organization).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();

                //TODO need some error handling / logging here
                return true;

            }
        }
    }
}
