//-----------------------------------------------------------------------
// <copyright file="IAccountRL.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
// <creater name="Sandhya Patil"/>
//-----------------------------------------------------------------------
namespace RepositoryLayer.Interface
{
    using CommonLayer.Model;
    using CommonLayer.Response;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAccountRL
    {
        /// <summary>
        ///Chat App Registration method
        /// </summary>
        /// <param name="registrationModel">registrationModel parameter</param>
        /// <returns>returns register user</returns>
        Task<RegistrationModel> ChatAppRegistration(RegistrationModel registrationModel);

        /// <summary>
        /// Chat App Login method
        /// </summary>
        /// <param name="loginModel">loginModel parameter</param>
        /// <returns>return login user</returns>
        Task<LoginResponseModel> ChatAppLogin(LoginModel loginModel);

        /// <summary>
        /// Get All Users method
        /// </summary>
        /// <returns>return all users</returns>
        Task<IList<AllUserModel>> GetAllUsers();
    }
}
