using System;
using System.ComponentModel.DataAnnotations;

namespace AIMS.Models
{
    public class EntityPropertyViewModel
    {
        public int UserId { get; set; }
        [MaxLength(45)]
        public string FirstName { get; set; }
        [MaxLength(45)]
        public string LastName { get; set; }
        //when we add a property, we should update this
        public DateTimeOffset? UserUpdatedAt { get; set; }
        //TODO, it would be nice to see username/email too
        //public string Email { get; set; }

        public int EntityId { get; set; }
        public int PropertyDefId { get; set; }
        [MaxLength(256)]
        public string Title { get; set; }
        [MaxLength(256)]
        public string Description { get; set; }
        [MaxLength(256)]
        public string Link { get; set; }
        [MaxLength(256)]
        public string ImageURL { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

        public EntityPropertyViewModel(UserDetailsViewModel user)
        {
            this.UserId = user.UserId;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.EntityId = user.UserId;
        }
        public EntityPropertyViewModel()
        { }
    }
}
