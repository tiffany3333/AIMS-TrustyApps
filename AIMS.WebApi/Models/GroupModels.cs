using System.ComponentModel.DataAnnotations;

namespace AIMS.WebApi.Models
{
    public class GroupModels
    {
        [Required]
        public int organization_id { get; set; }

    }

    public class GroupResponseJSON
    {
        public int group_id { get; set; }

        [MaxLength(128)]
        public string name { get; set; }
    }
}