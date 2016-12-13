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
        public int survey_instance_id { get; set; }

        public string survey_name { get; set; }

        public SurveyQuestionResponseJSON[] survey_questions;
    }

    public class SurveyQuestionResponseJSON
    {
        public int survey_question_id { get; set; }

        public string survey_question_text { get; set; }

        public response_types response_type { get; set; }

        public enum response_types
        {
            MultipleChoice = 0,
            Paragraph = 1
        }

        public SurveyResponseResponseJSON[] survey_responses;
    }
    public class SurveyResponseResponseJSON
    {
        public int survey_response_id { get; set; }

        public string survey_response_text { get; set; }
    }
}