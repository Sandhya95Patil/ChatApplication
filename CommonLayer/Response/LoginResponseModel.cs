//-----------------------------------------------------------------------
// <copyright file="LoginResponseModel.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
// <creater name="Sandhya Patil"/>
//-----------------------------------------------------------------------
namespace CommonLayer.Response
{
    /// <summary>
    /// Login Response Model class
    /// </summary>
    public class LoginResponseModel
    {
        /// <summary>
        /// get and set first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// get and set last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// get and set email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// get and set mobile number
        /// </summary>
        public string MobileNumber { get; set; }

        /// <summary>
        /// get and set token
        /// </summary>
        public string Token { get; set; }
    }
}
