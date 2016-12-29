using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AIMS.WebApi.Models
{
    public class UserDetailsResponseJSON
    {
        [MaxLength(45)]
        public string first_name;

        [MaxLength(45)]
        public string last_name;

        [MaxLength(140)]
        public string contact_email;

        [MaxLength(140)]
        public string contact_phone;

        public List<UserDetailsPropertiesResponseJSON> user_properties;
    }
    public class UserDetailsPropertiesResponseJSON
    {
        [MaxLength(256)]
        public string prop_title;

        [MaxLength(256)]
        public string prop_description;

        [MaxLength(256)]
        public string prop_link;

        [MaxLength(256)]
        public string prop_imageurl;
    }
}