using AIMS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
