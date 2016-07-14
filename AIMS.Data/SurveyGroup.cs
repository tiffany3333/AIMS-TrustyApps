using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMS.Data
{
    public class SurveyGroup
    {
        [Key]
        public int SurveyId { get; set; }
        public DateTimeOffset LastSent { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public virtual Survey Survey{ get; set; }
        public virtual Group Group { get; set; }
    }
}
