//-----------------------------------------------------------------------
// <copyright file="IAccountBL.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
// <creater name="Sandhya Patil"/>
//-----------------------------------------------------------------------
namespace BusinessLayer.Interface
{
    using CommonLayer.Model;
    using CommonLayer.Response;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// IAccountBL interface
    /// </summary>
    public interface IAccountBL
    {
        /// <summary>
        /// Chat App Registration method
        /// </summary>
        /// <param name="registrationModel">registration model parameter</param>
        /// <returns>returns the register data</returns>
        Task<RegistrationModel> ChatAppRegistration(RegistrationModel registrationModel);

        /// <summary>
        /// ChatAppLogin method
        /// </summary>
        /// <param name="loginModel">login model</param>
        /// <returns>returns the login data</returns>
        Task<LoginResponseModel> ChatAppLogin(LoginModel loginModel);
        Task<IList<AllUserModel>> GetAllUsers(); 
    }
}
