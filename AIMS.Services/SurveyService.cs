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
                    UpdatedAt = DateTimeOffset.UtcNow,
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

        public SurveyViewModel GetSurvey(int surveyId)
        {
            SurveyViewModel mySurveyVM = null;

            using (var ctx = new AIMSDbContext())
            {
                Survey survey = ctx.Surveys.Find(surveyId);
                if (survey != null)
                {
                    mySurveyVM = new SurveyViewModel(survey);
                    return mySurveyVM;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool EditSurvey(SurveyViewModel surveyVM)
        {
            using (var ctx = new AIMSDbContext())
            {
                Survey survey = ctx.Surveys.Find(surveyVM.Id);

                survey.Name = surveyVM.Name;
                survey.IsDeactivated = surveyVM.IsDeactivated;
                survey.UpdatedAt = DateTimeOffset.UtcNow;

                ctx.Entry(survey).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();

                //TODO need some error handling / logging here
                return true;

            }
        }

        //Get all users
        public List<AssignUserViewModel> GetUsersAssignments(int surveyId)
        {
            List<AssignUserViewModel> myUsers = new List<AssignUserViewModel>();

            using (var ctx = new AIMSDbContext())
            {
                foreach (User myUser in ctx.User.ToList())
                {
                    AssignUserViewModel assignUserVM = new AssignUserViewModel(myUser);
                    //now find out if this user is assigned to this survey
                    assignUserVM.IsAssigned = IsAssigned(myUser.UserId, surveyId);

                    myUsers.Add(assignUserVM);
                }

                return myUsers;
            }
        }

        //Assign / deassign survey(s) to user(s)
        public bool AssignSurvey(List<AssignUserViewModel> assignUserVMs)
        {
            List<AssignUserViewModel> changedAssignUserVMs = assignUserVMs.Where(a => a.assignmentChanged == true).ToList();
            if (changedAssignUserVMs != null)
            {
                //holy cow stop and test
                int i = 0;
            }

            return true;
        }

        //See if a user is assigned to a survey
        public bool IsAssigned(int userId, int surveyId)
        {
            using (var ctx = new AIMSDbContext())
            {
                SurveyInstance surveyInstance = ctx.SurveyInstances.Where(s => s.SurveyId == surveyId).Where(u => u.UserId == userId).SingleOrDefault();
                if (surveyInstance == null)
                    return false;
                else
                    return true;
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
