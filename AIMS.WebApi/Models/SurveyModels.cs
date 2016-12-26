using System;
using System.Collections.Generic;
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

        public List<SurveyQuestionResponseJSON> survey_questions;
    }

    public class SurveyQuestionResponseJSON
    {
        public int survey_question_id { get; set; }

        public string survey_question_text { get; set; }

        public response_types survey_response_type { get; set; }

        public enum response_types
        {
            MultipleChoice = 0,
            Paragraph = 1
        }

        public List<SurveyResponseResponseJSON> survey_responses;
    }
    public class SurveyResponseResponseJSON
    {
        public int survey_response_id { get; set; }

        [MaxLength(512)]
        public string survey_response_text { get; set; }

        public int survey_response_value { get; set; }

    }

    //// 
    // Start v3/survey changes
    // v3/survey endpoint added image urls, so we have a V3 version of the models involved in that endpoint
    /// 
    public class SurveyResponseJSONV3
    {
        public int survey_instance_id { get; set; }

        public string survey_name { get; set; }

        public List<SurveyQuestionResponseJSONV3> survey_questions;
    }

    public class SurveyQuestionResponseJSONV3
    {
        public int survey_question_id { get; set; }

        public string survey_question_text { get; set; }

        public response_types survey_response_type { get; set; }

        public enum response_types
        {
            MultipleChoice = 0,
            Paragraph = 1
        }

        public List<SurveyResponseResponseJSONV3> survey_responses;
    }
    public class SurveyResponseResponseJSONV3
    {
        public int survey_response_id { get; set; }

        [MaxLength(512)]
        public string survey_response_text { get; set; }

        public int survey_response_value { get; set; }

        public string survey_response_image_url { get; set; }
    }

    //// 
    // End v3/survey changes
    /// 
    public class SurveySubmitResponseJSON
    {
        public int survey_instance_id { get; set; }

        public string survey_name { get; set; }

        public List<SurveyAnswersResponseJSON> survey_answers;
    }

    public class SurveyAnswersResponseJSON
    {
        public int survey_question_id;

        public int survey_response_id;

        [MaxLength(512)]
        public string survey_response_text;

        public int survey_response_value;
    }
}