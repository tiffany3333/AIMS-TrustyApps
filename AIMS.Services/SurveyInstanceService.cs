using AIMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using AIMS.Models;

namespace AIMS.Services
{
    public class SurveyInstanceService
    {
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
    }
}
