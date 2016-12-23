using AIMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using AIMS.Models;
using System.Web;
using System.IO;

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

        public bool CreateResponse(int questionId, string textResponse, int valueResponse, HttpPostedFileBase imageResponse)
        {
            using (var ctx = new AIMSDbContext())
            {
                var surveyResponse = new SurveyResponse
                {
                    SurveyQuestionId = questionId,
                    TextResponse = textResponse,
                    ValueResponse = valueResponse,
                    CreatedAt = DateTimeOffset.UtcNow,
                    ImageFilenameRepsonse = uploadImage(imageResponse),
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

                //now go remove any incompleted instances of this survey from user's queues
                List<SurveyInstance> surveyInstancesNotCompleted = ctx.SurveyInstances.Where(s => s.SurveyId == survey.Id).ToList();
                foreach (SurveyInstance item in surveyInstancesNotCompleted)
                {
                    ctx.SurveyInstances.Remove(item);
                }
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
        public bool AssignSurvey(int surveyId, List<int> userIDListAssign, List<int> userIDListUnAssign)
        {
            //TODO if we toggled assign/unassign, resolve the lists
            
            using (var ctx = new AIMSDbContext())
            {
                if (userIDListAssign != null)
                {
                    foreach (var item in userIDListAssign)
                    {
                        SurveyInstance surveyInstance = new SurveyInstance();
                        surveyInstance.CreatedAt = DateTimeOffset.UtcNow;
                        surveyInstance.IsCompleted = false;
                        surveyInstance.SurveyId = surveyId;
                        surveyInstance.UserId = item;
                        ctx.SurveyInstances.Add(surveyInstance);
                    }
                }
                if (userIDListUnAssign != null)
                {
                    foreach (var item in userIDListUnAssign)
                    { }
                }
                ctx.SaveChanges();
            }
            return true;
        }

        //See if a user is assigned to a survey
        public bool IsAssigned(int userId, int surveyId)
        {
            using (var ctx = new AIMSDbContext())
            {
                SurveyInstance surveyInstance = ctx.SurveyInstances.Where(s => s.SurveyId == surveyId).Where(u => u.UserId == userId).FirstOrDefault();
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

        public string uploadImage(HttpPostedFileBase uploadFile)
        {
            string filePath = null;

            if (uploadFile != null && uploadFile.ContentLength > 0)
            {
                int MaxContentLength = 1024 * 1024 * 3; //3 MB
                string[] AllowedFileExtensions = new string[] { ".jpg", ".gif", ".png", ".pdf" };

                if (!AllowedFileExtensions.Contains(uploadFile.FileName.Substring(uploadFile.FileName.LastIndexOf('.'))))
                {
                    //TODO better error tracking here "Please file of type: " + string.Join(", ", AllowedFileExtensions)
                }

                else if (uploadFile.ContentLength > MaxContentLength)
                {
                    //TODO better error tracking here "Your file is too large, maximum allowed size is: " + MaxContentLength + " MB"
                }
                else
                {
                    var fileName = Path.GetFileName(uploadFile.FileName);
                    filePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/Upload"), fileName);
                    uploadFile.SaveAs(filePath);                    
                }
            }

            return filePath;
        }
    }
}
