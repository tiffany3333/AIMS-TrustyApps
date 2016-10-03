using AIMS.Data;
using System;

namespace AIMS.Services
{
    public class SurveyService
    {
        public int CreateSurvey(string name)
        {
            using (var ctx = new AIMSDbContext())
            {
                var survey = new Survey
                {
                    Name = name,
                    CreatedAt = DateTimeOffset.UtcNow,
                    IsDeactivated = false
                };
                ctx.Surveys.Add(survey);
                ctx.SaveChanges();
                return survey.Id;
            }
        }
        public int CreateQuestion(int surveyId, string question)
        {
            using (var ctx = new AIMSDbContext())
            {
                var surveyQuestion = new SurveyQuestion
                {
                    SurveyId = surveyId,
                    Question = question,
                    CreatedAt = DateTimeOffset.UtcNow,                 
                };
                ctx.SurveyQuestions.Add(surveyQuestion);
                ctx.SaveChanges();
                return surveyQuestion.Id;
            }
        }

        public bool CreateResponse(int questionId, string textResponse)
        {
            using (var ctx = new AIMSDbContext())
            {
                var surveyResponse = new SurveyResponse
                {
                    SurveyQuestionId = questionId,
                    TextResponse = textResponse,
                    CreatedAt = DateTimeOffset.UtcNow,
                };
                ctx.SurveyResponses.Add(surveyResponse);
                
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
