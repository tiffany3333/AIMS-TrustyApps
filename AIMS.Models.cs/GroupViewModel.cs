using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMS.Models
{
    public class GroupViewModel
    {
        public int GroupId { get; set; }

        public int? OrganizationId { get; set; }

        [MaxLength(128)]
        [Display(Name = "Group Name")]
        public string Name { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
