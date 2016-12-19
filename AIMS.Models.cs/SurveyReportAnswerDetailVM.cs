using AIMS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AIMS.Models
{
    public class SurveyReportAnswerDetailVM
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public int UserId { get; set; }
        public bool IsCompleted { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public List<SurveyQuestion> SurveyQuestions { get; set; }
        public List<SurveyAnswer> SurveyAnswers { get; set; }

        public SurveyReportAnswerDetailVM(SurveyInstance surveyInstance)
        {
            this.Id = surveyInstance.SurveyInstanceId;
            this.SurveyId = surveyInstance.SurveyId;
            this.UserId = surveyInstance.UserId;
            this.IsCompleted = surveyInstance.IsCompleted;
            this.CreatedAt = surveyInstance.CreatedAt;
            this.UpdatedAt = surveyInstance.UpdatedAt;
            this.SurveyQuestions = new List<SurveyQuestion>();
            this.SurveyAnswers = new List<SurveyAnswer>();

            foreach(SurveyAnswer answer in surveyInstance.SurveyAnswers)
            {
                this.SurveyAnswers.Add(answer);
                //now find the quesiton 
                using (var ctx = new AIMSDbContext())
                {
                    SurveyQuestion question = ctx.SurveyQuestions.Find(answer.SurveyQuestionId);
                    this.SurveyQuestions.Add(question);
                }
            }
        }
    }
}
