using AIMS.Data;
using AIMS.WebApi.Models;
using System.Linq;
using System.Web.Http;

namespace AIMS.WebApi.Controllers
{
    [RoutePrefix("api/v1")]
    public class GroupController : ApiController
    {

        private AIMSDbContext _db = new AIMSDbContext();

        // GET api/v1/groups
        [Route("groups/{organization_id:int}")]
        public IHttpActionResult GetGroups(GroupModels model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var group = _db.Groups.Where(g => g.OrganizationId == model.organization_id).SingleOrDefault();

            if (group != null)
            {
                var repsonse = new GroupResponseJSON { group_id = group.GroupId, name = group.Name };
                return Ok(repsonse);
            }
            else
            return Ok("Make sure you have a valid Organization Id.");
        }

    }
}
