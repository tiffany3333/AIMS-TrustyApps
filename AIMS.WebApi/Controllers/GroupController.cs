using AIMS.Data;
using AIMS.WebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AIMS.WebApi.Controllers
{
    public class GroupController : ApiController
    {

        private AIMSDbContext _db = new AIMSDbContext();

        // GET api/v1/groups
        [Route("api/v1/groups")]
        [Route("api/v2/groups")]
        public IHttpActionResult GetGroups(int organizationId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var group = _db.Groups.Where(g => g.OrganizationId == model.organization_id).SingleOrDefault();
            var groups = _db.Groups.Where(g => g.OrganizationId == organizationId).ToArray();

            if (groups.Count() > 0)
            {
                List<GroupResponseJSON> response = new List<GroupResponseJSON>();

                foreach (Group group in groups)
                {
                    GroupResponseJSON resp = new GroupResponseJSON();
                    resp.name = group.Name;
                    resp.group_id = group.GroupId;

                    response.Add(resp);
                }
                return Ok(response);
            }
            else
            {
                return BadRequest("Make sure you have a valid Organization Id.");
            }
        }
    }
}
