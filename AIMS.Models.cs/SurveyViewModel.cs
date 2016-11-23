using AIMS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AIMS.Models
{
    public class SurveyViewModel
    {
        public int Id { get; set; }
        [MaxLength(45)]
        public string Name { get; set; }
        [DefaultValue(false)]
        public bool IsDeactivated { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public IEnumerable<SurveyQuestion> SurveyQuestions { get; set; }
        public IEnumerable<SurveyResponse> SurveyResponses { get; set; }

        public SurveyViewModel(Survey survey)
        {
            this.Id = survey.Id;
            this.Name = survey.Name;
            this.IsDeactivated = survey.IsDeactivated;
            this.CreatedAt = survey.CreatedAt;
            this.UpdatedAt = survey.UpdatedAt;
            this.SurveyQuestions = survey.SurveyQuestions;
            foreach (SurveyQuestion question in this.SurveyQuestions)
            {
                this.SurveyResponses = question.SurveyResponses;
            }
        }

        public SurveyViewModel()
        {

        }
    }
}
