using System.ComponentModel.DataAnnotations;

namespace AIMS.WebApi.Models
{
    public class GroupModels
    {
        [Required]
        public int organization_id { get; set; }

    }
}