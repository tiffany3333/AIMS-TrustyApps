using AIMS.Data;
using AIMS.WebApi.Models;
using System.Linq;
using System.Web.Http;

namespace AIMS.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/v1")]
    public class OrganizationController : ApiController
    {

        private AIMSDbContext _db = new AIMSDbContext();

        //GET api/v1/organizations
        [Route("organizations")]
        public IHttpActionResult GetOrganizations(OrganizationModels model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var org = _db.Organizations.ToArray();


            if (org != null)
            {
                var response = new OrganizationResponseJSON { organization_id = model.OrganizationId, name = model.Name, description = model.Description };
                return Ok(response);
            }

            else return Ok("Unable to retrieve Organizations.");

        }
    }
}
