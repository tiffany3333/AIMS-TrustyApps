using AIMS.Data;
using AIMS.Services;
using AIMS.WebApi.Models;
using AIMS.WebApi.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace AIMS.WebApi.Controllers
{
    [RoutePrefix("api/v1")]
    public class SurveyController : ApiController
    {

        private AIMSDbContext _db = new AIMSDbContext();
        private readonly Lazy<CommonServices> _svcs = new Lazy<CommonServices>();
        private readonly Lazy<UserService> _userService = new Lazy<UserService>();
        private readonly Lazy<SurveyInstanceService> _surveyInstanceService = new Lazy<SurveyInstanceService>();

        // GET api/v1/surveys/{user_id}
        //[Route("surveys/{user_id:int}")]
        [Route("surveys")]
        public IHttpActionResult GetUsersSurveys(int user_id)
        {
            if (!_svcs.Value.ValidateToken(this.Request.Headers))
            {
                return StatusCode(HttpStatusCode.Forbidden);
            }
            List<int> surveyInstanceIds = null;
            List<SurveysResponseJSON> response = new List<SurveysResponseJSON>();

            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return BadRequest("Unable to retrieve Surveys.");            }

            AIMS.Data.User user = _userService.Value.GetUser(user_id);
            if (user != null)
            {
                surveyInstanceIds =_surveyInstanceService.Value.GetSurveyInstances(user_id);

                if (surveyInstanceIds != null)
                {
                    foreach (int surveyInstanceId in surveyInstanceIds)
                    {
                        SurveysResponseJSON resp = new SurveysResponseJSON();
                        resp.survey_instance_id = surveyInstanceId;
                        response.Add(resp);
                    }
                }
                else return BadRequest("Unable to retrieve Surveys, none assigned to user.");
            }
            else return BadRequest("Unable to retrieve Surveys, user is null.");

            return Ok(response);
        }

        // GET api/v1/surveys/{survey_id}
        [Route("survey")]
        public IHttpActionResult GetSurveyInstanceDetails(int survey_instance_id)
        {
            if (!_svcs.Value.ValidateToken(this.Request.Headers))
            {
                return StatusCode(HttpStatusCode.Forbidden);
            }

            SurveyResponseJSON response = new SurveyResponseJSON();
            List<SurveyQuestionResponseJSON> resp_question;
            List<SurveyResponseResponseJSON> resp_response;

            response.survey_instance_id = survey_instance_id;
            string survey_name = _surveyInstanceService.Value.GetSurveyName(survey_instance_id);
            if (survey_name == null)
            {
                return BadRequest("Survey Name is null for this survey, something went wrong");
            }
            response.survey_name = survey_name;

            //var survey = _db.Surveys.Where(s => s.Id == model.survey_id).SingleOrDefault();
            //var surveyQuestions = _db.SurveyQuestions.Where(q => q.Id == survey.Id).ToArray();
            //var surveyResponses = surveyQuestions.Select(e => new SurveyResponse surveryResponse.Re)

            //if (survey != null)
            //{
            //    var repsonse = new SurveyResponseJSON { survey_id = survey.Id, name = survey.Name, question_id = surveyQuestions.Id, response_type = };
            //    return Ok(repsonse);
            //}
            return Ok(response);
        }

    }
}
