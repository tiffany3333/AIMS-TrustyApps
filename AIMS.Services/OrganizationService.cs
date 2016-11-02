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
        private readonly Lazy<GroupService> _groupSvc = new Lazy<GroupService>();

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
            OrganizationViewModel myOrganizationVM = null;

            using (var ctx = new AIMSDbContext())
            {
                Organization org = ctx.Organizations.Find(id);
                if (org != null)
                {
                    myOrganizationVM = new OrganizationViewModel(org);
                    return myOrganizationVM;
                }
                else
                {
                    return null;
                }
            }
        }

        public string GetOrganizationName(int organizationId)
        {
            string retVal = null;
            OrganizationViewModel myOrganizationVM = GetOrganization(organizationId);
            if (myOrganizationVM != null)
            {
                retVal = myOrganizationVM.Name;
            }

            return retVal;
        }

        public bool DeleteOrganization(int? id)
        {
            bool retVal = false;

            using (var ctx = new AIMSDbContext())
            {
                Organization org = ctx.Organizations.Find(id);
                if (org != null)
                {
                    if (org.Groups.Count() > 0)
                    {
                        List<Group> groupsToBeRemoved = new List<Group>();
                        //delete groups first
                        foreach (Group group in org.Groups)
                        {
                            //I wanted to just ct.Groups.Remove here, but the foreach
                            //loop didn't like the dataset being altered dynamically
                            groupsToBeRemoved.Add(group);
                        }                        
                        for (int i = 0; i < groupsToBeRemoved.Count(); i++)
                        {
                            ctx.Groups.Remove(groupsToBeRemoved.ElementAt(i));
                        }
                    }
                    ctx.Organizations.Remove(org);
                    //TODO Do I need to delete org entity too?
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
