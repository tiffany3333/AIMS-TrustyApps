using System.Web.Http;

namespace AIMS.WebApi.Controllers
{
    public class SurveyController : ApiController
    {

        //private AIMSDbContext _db = new AIMSDbContext();
        //private readonly UserService _userService;

        //// GET api/v1/surveys/{user_id}
        //[Route("surveys/{user_id:int}")]
        //public IHttpActionResult GetUsersSurveys(SurveyModels model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var user = _userService.GetUser(model.user_id);
        //}

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
