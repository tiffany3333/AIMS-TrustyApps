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
    public class SurveyController : ApiController
    {
        public static string TAG = "AIMS.API-SurveyController ";
        private AIMSDbContext _db = new AIMSDbContext();
        private readonly Lazy<CommonServices> _svcs = new Lazy<CommonServices>();
        private readonly Lazy<UserService> _userService = new Lazy<UserService>();
        private readonly Lazy<SurveyInstanceService> _surveyInstanceService = new Lazy<SurveyInstanceService>();
        private readonly Lazy<SurveyService> _surveyService = new Lazy<SurveyService>();

        // GET api/v1/surveys/{user_id}
        //[Route("surveys/{user_id:int}")]
        [Route("api/v1/surveys")]
        [Route("api/v2/surveys")]
        [HttpGet]
        public IHttpActionResult GetUsersSurveys(int user_id)
        {
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

        [Route("api/v3/surveys")]
        [HttpGet]
        public IHttpActionResult GetUsersSurveysV3(int user_id)
        {
            // API v3 added validation on the header auth
            if (!_svcs.Value.ValidateToken(this.Request.Headers))
            {
                return StatusCode(HttpStatusCode.Forbidden);
            }
            List<int> surveyInstanceIds = null;
            List<SurveysResponseJSON> response = new List<SurveysResponseJSON>();

            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return BadRequest("Unable to retrieve Surveys.");
            }

            AIMS.Data.User user = _userService.Value.GetUser(user_id);
            if (user != null)
            {
                surveyInstanceIds = _surveyInstanceService.Value.GetSurveyInstances(user_id);

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

        // GET api/v1/survey/{survey_id}
        [Route("api/v1/survey")]
        [Route("api/v2/survey")]
        [HttpGet]
        public IHttpActionResult GetSurveyInstanceDetails(int survey_instance_id)
        {
            //if (!_svcs.Value.ValidateToken(this.Request.Headers))
            //{
            //    return StatusCode(HttpStatusCode.Forbidden);
            //}

            SurveyResponseJSON response = new SurveyResponseJSON();
            List<SurveyQuestionResponseJSON> resp_questions = new List<SurveyQuestionResponseJSON>();
            
            SurveyInstance surveyInstance = _surveyInstanceService.Value.GetSurveyInstance(survey_instance_id);
            if (surveyInstance == null)
            {
                return BadRequest("Survey Instance is null, something went wrong");
            }
            AIMS.Models.SurveyViewModel survey = _surveyService.Value.GetSurvey(surveyInstance.SurveyId);

            if (survey == null)
            {
                return BadRequest("Survey is null, something went wrong");
            }

            response.survey_instance_id = survey_instance_id;
            response.survey_name = survey.Name;

            foreach (SurveyQuestion question in survey.SurveyQuestions)
            {
                SurveyQuestionResponseJSON resp_question = new SurveyQuestionResponseJSON();
                resp_question.survey_question_id = question.Id;
                resp_question.survey_question_text = question.Question;
                resp_question.survey_response_type = SurveyQuestionResponseJSON.response_types.MultipleChoice;

                //assume multiple choice for now, we might change it once we look at the first response.
                List<SurveyResponseResponseJSON> resp_responses = new List<SurveyResponseResponseJSON>();

                foreach (SurveyResponse surveyResponse in question.SurveyResponses)
                {
                    if (surveyResponse.TextResponse.Equals("paragraph", StringComparison.CurrentCultureIgnoreCase))
                    {
                        resp_question.survey_response_type = SurveyQuestionResponseJSON.response_types.Paragraph;
                        break;
                    }
                    SurveyResponseResponseJSON resp_response = new SurveyResponseResponseJSON();
                    resp_response.survey_response_id = surveyResponse.Id;
                    resp_response.survey_response_text = surveyResponse.TextResponse;
                    resp_response.survey_response_value = surveyResponse.ValueResponse;
                    resp_responses.Add(resp_response);
                }
                resp_question.survey_responses = resp_responses;
                resp_questions.Add(resp_question);
            }
            response.survey_questions = resp_questions;

            return Ok(response);
        }

        [Route("api/v3/survey")]
        [HttpGet]
        public IHttpActionResult GetSurveyInstanceDetailsV3(int survey_instance_id)
        {
            // API v3 added validation on the header auth
            if (!_svcs.Value.ValidateToken(this.Request.Headers))
            {
                return StatusCode(HttpStatusCode.Forbidden);
            }

            SurveyResponseJSONV3 response = new SurveyResponseJSONV3();
            List<SurveyQuestionResponseJSONV3> resp_questions = new List<SurveyQuestionResponseJSONV3>();

            SurveyInstance surveyInstance = _surveyInstanceService.Value.GetSurveyInstance(survey_instance_id);
            if (surveyInstance == null)
            {
                return BadRequest("Survey Instance is null, something went wrong");
            }
            AIMS.Models.SurveyViewModel survey = _surveyService.Value.GetSurvey(surveyInstance.SurveyId);

            if (survey == null)
            {
                return BadRequest("Survey is null, something went wrong");
            }

            response.survey_instance_id = survey_instance_id;
            response.survey_name = survey.Name;

            foreach (SurveyQuestion question in survey.SurveyQuestions)
            {
                SurveyQuestionResponseJSONV3 resp_question = new SurveyQuestionResponseJSONV3();
                resp_question.survey_question_id = question.Id;
                resp_question.survey_question_text = question.Question;
                resp_question.survey_response_type = SurveyQuestionResponseJSONV3.response_types.MultipleChoice;

                //assume multiple choice for now, we might change it once we look at the first response.
                List<SurveyResponseResponseJSONV3> resp_responses = new List<SurveyResponseResponseJSONV3>();

                foreach (SurveyResponse surveyResponse in question.SurveyResponses)
                {
                    if (surveyResponse.TextResponse.Equals("paragraph", StringComparison.CurrentCultureIgnoreCase))
                    {
                        resp_question.survey_response_type = SurveyQuestionResponseJSONV3.response_types.Paragraph;
                        break;
                    }
                    SurveyResponseResponseJSONV3 resp_response = new SurveyResponseResponseJSONV3();
                    resp_response.survey_response_id = surveyResponse.Id;
                    resp_response.survey_response_text = surveyResponse.TextResponse;
                    resp_response.survey_response_value = surveyResponse.ValueResponse;
                    resp_response.survey_response_image_url = surveyResponse.ImageFilenameRepsonse;
                    resp_responses.Add(resp_response);
                }
                resp_question.survey_responses = resp_responses;
                resp_questions.Add(resp_question);
            }
            response.survey_questions = resp_questions;

            return Ok(response);
        }

        // POST api/v1/survey
        [Route("api/v1/survey")]
        [Route("api/v2/survey")]
        [HttpPost]
        public IHttpActionResult SurveyPost(SurveySubmitResponseJSON submittedSurvey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("The submitted JSON structure or values are invalid");
            }
            if (submittedSurvey.survey_instance_id == null)
            {
                return BadRequest("Null survey_instance_id");
            }

            //capture the answers
            List<SurveyAnswer> surveyAnswers = new List<SurveyAnswer>();

            foreach (SurveyAnswersResponseJSON answer in submittedSurvey.survey_answers)
            {
                SurveyAnswer surveyAnswer = new SurveyAnswer();
                surveyAnswer.CreatedAt = DateTimeOffset.UtcNow;
                //all answers should have a question id
                if (answer.survey_question_id == null)
                {
                    return BadRequest("All survey_answers require a survey_question_id field");
                }
                
                surveyAnswer.SurveyQuestionId = answer.survey_question_id;

                if (answer.survey_response_text != null)
                {
                    surveyAnswer.TextResponse = answer.survey_response_text;
                }
                if (answer.survey_response_value != 0)
                {
                    surveyAnswer.ValueResponse = answer.survey_response_value;
                }
                surveyAnswers.Add(surveyAnswer);
            }
            
            if (!(_surveyInstanceService.Value.CaptureAnswers(submittedSurvey.survey_instance_id, surveyAnswers)))
            {
                return BadRequest("Something went wrong, maybe survey_instance_id is invalid.");
            }
            return Ok("Sucessfully submitted survey");
        }

        [Route("api/v3/survey")]
        [HttpPost]
        public IHttpActionResult SurveyPostV3(SurveySubmitResponseJSON submittedSurvey)
        {
            // API v3 added validation on the header auth
            if (!_svcs.Value.ValidateToken(this.Request.Headers))
            {
                return StatusCode(HttpStatusCode.Forbidden);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("The submitted JSON structure or values are invalid");
            }
            if (submittedSurvey.survey_instance_id == null)
            {
                return BadRequest("Null survey_instance_id");
            }

            //capture the answers
            List<SurveyAnswer> surveyAnswers = new List<SurveyAnswer>();

            foreach (SurveyAnswersResponseJSON answer in submittedSurvey.survey_answers)
            {
                SurveyAnswer surveyAnswer = new SurveyAnswer();
                surveyAnswer.CreatedAt = DateTimeOffset.UtcNow;
                //all answers should have a question id
                if (answer.survey_question_id == null)
                {
                    return BadRequest("All survey_answers require a survey_question_id field");
                }

                surveyAnswer.SurveyQuestionId = answer.survey_question_id;

                if (answer.survey_response_text != null)
                {
                    surveyAnswer.TextResponse = answer.survey_response_text;
                }
                if (answer.survey_response_value != 0)
                {
                    surveyAnswer.ValueResponse = answer.survey_response_value;
                }
                surveyAnswers.Add(surveyAnswer);
            }

            if (!(_surveyInstanceService.Value.CaptureAnswers(submittedSurvey.survey_instance_id, surveyAnswers)))
            {
                return BadRequest("Something went wrong, maybe survey_instance_id is invalid.");
            }
            return Ok("Sucessfully submitted survey");
        }
    }
}
