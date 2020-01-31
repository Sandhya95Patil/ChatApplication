using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
    public class RegistrationModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [RegularExpression("^([a-zA-Z]{2,})$", ErrorMessage = "FirstName should contain atleast 2 or more characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required)")]
        [RegularExpression("^([a-zA-Z]{2,})$", ErrorMessage = "Last name should contain atleast 2 or more characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is frequired")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public string MobileNumber { get; set; }
    }
}
