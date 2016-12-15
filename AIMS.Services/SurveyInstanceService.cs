using AIMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using AIMS.Models;

namespace AIMS.Services
{
    public class SurveyInstanceService
    {
        private readonly Lazy<SurveyService> _surveySvc = new Lazy<SurveyService>();

        public SurveyInstanceService()
        {

        }

        //This function returns only not completed survey instances assigned to a user
        public List<int> GetSurveyInstances(int userId)
        {
            using (var ctx = new AIMSDbContext())
            {
                List<int> surveyInstanceIds = new List<int>();

                List<SurveyInstance> surveyInstances = ctx.SurveyInstances.Where(u => u.UserId == userId).Where(i => i.IsCompleted == false).ToList();

                foreach (SurveyInstance surveyInstance in surveyInstances)
                {
                    surveyInstanceIds.Add(surveyInstance.SurveyInstanceId);
                }

                return surveyInstanceIds;
            }
        }

        public SurveyInstance GetSurveyInstance(int surveyInstanceId)
        {
            using (var ctx = new AIMSDbContext())
            {
                SurveyInstance surveyInstance = ctx.SurveyInstances.Where(i => i.SurveyInstanceId == surveyInstanceId).SingleOrDefault();

                return surveyInstance;
            }
        }
        public string GetSurveyName(int surveyInstanceId)
        {
            using (var ctx = new AIMSDbContext())
            {
                string retVal = null;

                SurveyInstance surveyInstance = ctx.SurveyInstances.Where(i => i.SurveyInstanceId == surveyInstanceId).SingleOrDefault();

                if (surveyInstance != null)
                {
                    SurveyViewModel survey = _surveySvc.Value.GetSurvey(surveyInstance.SurveyId);
                    if (survey != null)
                    {
                        retVal = survey.Name;
                    }
                }

                return retVal;
            }
        }
    }
}
