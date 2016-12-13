using System;
using System.ComponentModel.DataAnnotations;

namespace AIMS.WebApi.Models
{
    public class SurveysResponseJSON
    {
        public int survey_instance_id { get; set; }
    }

    public class SurveyResponseJSON
    {
        public int survey_id { get; set; }

        public string name { get; set; }

        public int question_id { get; set; }

        public enum response_types
        {
            MultipleChoice = 0,
            Paragraph =1
        }

        public response_types response_type { get; set; }

        [MaxLength(256)]
        public string text { get; set; }

        public string[] choices { get; set; }
    }
}