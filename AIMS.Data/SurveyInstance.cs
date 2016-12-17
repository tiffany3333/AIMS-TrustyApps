﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMS.Data
{
    public class SurveyInstance
    {
        [Key]
        public int SurveyInstanceId { get; set; }

        public int SurveyId { get; set; }

        public int UserId { get; set; }

        public bool IsCompleted { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        public virtual ICollection<SurveyAnswer> SurveyAnswers { get; set; }
    }
}
