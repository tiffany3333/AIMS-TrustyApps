using AIMS.Data;
using AIMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AIMS.Data.Group;

namespace AIMS.Services
{
    public class GroupService
    {
        /****************************************************************
         * CreateGroup
         *  
         * Creates a group, 
         * ties it to an organization 
         * and that organization's entity
         * 
         * Returns GroupID
         **************************************************************/
        public int? CreateGroup(int? organizationId, string name)
        {
            using (var ctx = new AIMSDbContext())
            {
                var newGroup = new Group
                {
                    OrganizationId = organizationId,
                    Name = name,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow,
                };

                Organization org = ctx.Organizations.Find(organizationId);
                org.Groups.Add(newGroup);
                //TODO org.Entity.Groups.Add

                ctx.Groups.Add(newGroup);
                ctx.SaveChanges();
                return newGroup.GroupId;
            }
        }

        public List<GroupViewModel> GetGroups(int? organizationId)
        {
            List<GroupViewModel> myGroups = new List<GroupViewModel>();

            using (var ctx = new AIMSDbContext())
            {
                if (organizationId == -1)
                {
                    //just get all groups
                    foreach(Group group in ctx.Groups.ToList())
                    {
                        GroupViewModel myGroupVM = new GroupViewModel(group);
                        myGroups.Add(myGroupVM);
                    }
                }
                else
                {
                    //get the groups in a given organization
                    Organization org = ctx.Organizations.Find(organizationId);

                    foreach (Group group in org.Groups)
                    {
                        GroupViewModel myGroup = new GroupViewModel(group);
                        myGroups.Add(myGroup);
                    }
                }

                return myGroups;
            }
        }

        public GroupViewModel GetGroup(int? id)
        {
            GroupViewModel myGroupVM = null;

            using (var ctx = new AIMSDbContext())
            {
                Group group = ctx.Groups.Find(id);

                if (group != null)
                {
                    myGroupVM = new GroupViewModel(group);
                    return myGroupVM;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool DeleteGroup(int? id)
        {
            bool retVal = false;

            using (var ctx = new AIMSDbContext())
            {
                Group group = ctx.Groups.Find(id);
                if (group != null)
                {
                    ctx.Groups.Remove(group);
                    ctx.SaveChanges();
                    retVal = true;
                }
            }
            return retVal;
        }

        public GroupViewModel CreateGroupVM(int? groupId)
        {
            GroupViewModel myGroupVM;

            using (var ctx = new AIMSDbContext())
            {
                //TODO More error handling here
                myGroupVM = new GroupViewModel(ctx.Groups.Find(groupId));
            }
            return myGroupVM;
        }

        public bool EditGroup(GroupViewModel groupViewModel)
        {
            using (var ctx = new AIMSDbContext())
            {
                Group group = ctx.Groups.Find(groupViewModel.GroupId);

                group.Name = groupViewModel.Name;
                group.UpdatedAt = DateTimeOffset.UtcNow;

                ctx.Entry(group).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();

                //TODO need some error handling / logging here
                return true;

            }
        }
    }
}
