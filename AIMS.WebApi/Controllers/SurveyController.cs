using AIMS.Data;
using AIMS.Services;
using AIMS.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace AIMS.WebApi.Controllers
{
    [RoutePrefix("api/v1")]
    public class SurveyController : ApiController
    {

        private AIMSDbContext _db = new AIMSDbContext();
        private readonly Lazy<UserService> _userService = new Lazy<UserService>();
        private readonly Lazy<SurveyInstanceService> _surveyInstanceService = new Lazy<SurveyInstanceService>();

        // GET api/v1/surveys/{user_id}
        //[Route("surveys/{user_id:int}")]
        [Route("surveys")]
        public IHttpActionResult GetUsersSurveys(int user_id)
        {
            List<int> surveyInstanceIds = null;
            List<SurveysResponseJSON> response = new List<SurveysResponseJSON>();

            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return Ok("Unable to retrieve Surveys.");
            }

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
                else return Ok("Unable to retrieve Surveys, none assigned to user.");
            }
            else return Ok("Unable to retrieve Surveys, user is null.");

            return Ok(response);
        }

        //// GET api/v1/surveys/{survey_id}
        //[Route("survey/{survey_id:int}")]
        //public IHttpActionResult GetSurvey(SurveyModels model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var survey = _db.Surveys.Where(s => s.Id == model.survey_id).SingleOrDefault();
        //    var surveyQuestions = _db.SurveyQuestions.Where(q => q.Id == survey.Id).ToArray();
        //    var surveyResponses = surveyQuestions.Select(e => new SurveyResponse surveryResponse.Re)

        //    if (survey != null)
        //    {
        //        var repsonse = new SurveyResponseJSON { survey_id = survey.Id, name = survey.Name, question_id = surveyQuestions.Id, response_type = };
        //        return Ok(repsonse);
        //    }

        //}

    }
}
