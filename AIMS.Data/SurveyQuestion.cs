using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMS.Data
{
    public class SurveyQuestion
    {
        public int Id { get; set; }
        public int? SurveyId { get; set; }
        [MaxLength(256)]
        public string Question { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public virtual Survey Survey { get; set; }
    }
}
