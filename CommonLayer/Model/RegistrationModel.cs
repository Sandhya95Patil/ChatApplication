//-----------------------------------------------------------------------
// <copyright file="RegistrationModel.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
// <creater name="Sandhya Patil"/>
//-----------------------------------------------------------------------
namespace CommonLayer.Model
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Registration Model method
    /// </summary>
    public class RegistrationModel
    {
        /// <summary>
        /// Get and set Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Get and set first name
        /// </summary>
        [Required(ErrorMessage = "First name is required")]
        [RegularExpression("^([a-zA-Z]{2,})$", ErrorMessage = "FirstName should contain atleast 2 or more characters")]
        public string FirstName { get; set; }

        /// <summary>
        /// Get and set last name
        /// </summary>
        [Required(ErrorMessage = "Last name is required)")]
        [RegularExpression("^([a-zA-Z]{2,})$", ErrorMessage = "Last name should contain atleast 2 or more characters")]
        public string LastName { get; set; }

        /// <summary>
        /// get and set email
        /// </summary>
        [Required(ErrorMessage = "Email is frequired")]
        public string Email { get; set; }

        /// <summary>
        /// get and set password 
        /// </summary>
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        /// <summary>
        /// get and set mobile number
        /// </summary>
        public string MobileNumber { get; set; }
    }
}
