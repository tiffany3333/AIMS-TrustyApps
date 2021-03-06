﻿using AIMS.Data;
using AIMS.WebApi.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AIMS.WebApi.Controllers
{
    public class OrganizationController : ApiController
    {

        private AIMSDbContext _db = new AIMSDbContext();

        //GET api/v1/organizations
        [Route("api/v1/organizations")]
        [Route("api/v2/organizations")]
        [Route("api/v3/organizations")]
        [Route("api/v4/organizations")]
        public IHttpActionResult GetOrganizations()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orgs = _db.Organizations.ToArray();
            if (orgs.Count() > 0)
            {
                List<OrganizationResponseJSON> response = new List<OrganizationResponseJSON>();

                foreach (Organization org in orgs)
                {
                    OrganizationResponseJSON resp = new OrganizationResponseJSON();
                    resp.name = org.Name;
                    resp.organization_id = org.OrganizationId;
                    resp.description = org.Description;
                    response.Add(resp);
                }

                return Ok(response);
            }

            else return BadRequest("Unable to retrieve Organizations.");

        }

        //GET api/v1/organization
        [Route("api/v1/organization")]
        [Route("api/v2/organization")]
        [Route("api/v3/organization")]
        [Route("api/v4/organization")]
        public IHttpActionResult GetOrganization(int organizationId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Organization org = _db.Organizations.Where(o => o.OrganizationId == organizationId).SingleOrDefault();

            if (org != null)
            {
                OrganizationDetailsResponseJSON response = new OrganizationDetailsResponseJSON(org);
                return Ok(response);
            }
            else return BadRequest("Unable to retrieve Organization.");
        }
    }
}
