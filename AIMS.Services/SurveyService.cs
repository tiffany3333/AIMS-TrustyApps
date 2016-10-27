using AIMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIMS.Models;

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

        public List<SurveyViewModel> GetSurveys()
        {
            List<SurveyViewModel> mySurveys = new List<SurveyViewModel>();

            using (var ctx = new AIMSDbContext())
            {
                foreach (Survey survey in ctx.Surveys.ToList())
                {
                    SurveyViewModel mySurvey = new SurveyViewModel(survey);
                    mySurveys.Add(mySurvey);
                }

                return mySurveys;
            }
        }

        public SurveyViewModel CreateSurveyVM(int surveyId)
        {
            SurveyViewModel mySurveyVM;

            using (var ctx = new AIMSDbContext())
            {
                //TODO need more error handling here
                mySurveyVM = new SurveyViewModel(ctx.Surveys.Find(surveyId));
            }
            return mySurveyVM;
        }
    }
}
