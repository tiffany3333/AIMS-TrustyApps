using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMS.Data
{
    public class SurveyInstance
    {
        public int Id { get; set; }
        public int? SurveyId { get; set; }
        public int? UserId { get; set; }
        public bool IsComplete { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public virtual Survey Survey { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<SurveyResponse> SurveyResponses { get; set; }
    }
}
