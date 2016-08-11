using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMS.Data
{
    public class SurveyResponse
    {
        [Key]
        public int SurveyInstanceId { get; set; }
        public int SurveyQuestionId { get; set; }
        public int Rating { get; set; }
        [MaxLength(512)]
        public string TestResponse { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public virtual SurveyQuestion SurveyQuestion { get; set; }
    }
}
