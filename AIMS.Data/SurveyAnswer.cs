using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AIMS.Data
{
    public class SurveyAnswer
    {
        public int Id { get; set; }
        public int SurveyQuestionId { get; set; }

        [MaxLength(512)]
        public string TextResponse { get; set; }

        public int ValueResponse { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
