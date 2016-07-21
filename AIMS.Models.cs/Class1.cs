using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AIMS.Data.Contact;
using static AIMS.Data.User;

namespace AIMS.Models.cs
{
    public class RegisterUserViewModel
    {

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [MaxLength(45)]
        public string FirstName { get; set; }

        [MaxLength(45)]
        public string LastName { get; set; }

        public UserTypeEnum UserType { get; set; }

        [MaxLength(256)]
        public string Address1 { get; set; }

        [MaxLength(256)]
        public string Address2 { get; set; }

        [MaxLength(256)]
        public string Address3 { get; set; }

        [MaxLength(128)]
        public string City { get; set; }

        [MaxLength(128)]
        public string State { get; set; }

        [MaxLength(128)]
        public string Country { get; set; }

        [MaxLength(128)]
        public string Zipcode { get; set; }

        public TypeEnum Type { get; set; }

        [MaxLength(45)]
        public string PhoneLabel { get; set; }

        [MaxLength(45)]
        public string EmailLabel { get; set; }

        [MaxLength(140)]
        public string PhoneContactDetail { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(140)]
        public string EmailContactDetail { get; set; }

    }
}
