//-----------------------------------------------------------------------
// <copyright file="AccountBL.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
// <creater name="Sandhya Patil"/>
//-----------------------------------------------------------------------
namespace BusinessLayer.Service
{
    using BusinessLayer.Interface;
    using CommonLayer.Model;
    using CommonLayer.Response;
    using RepositoryLayer.Interface;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// AccountBL class
    /// </summary>
    public class AccountBL:IAccountBL
    {
        /// <summary>
        /// IAccountRL inject
        /// </summary>
        private readonly IAccountRL accountRL;

        /// <summary>
        /// AccountBL initializes
        /// </summary>
        /// <param name="accountRL">accountRL parameter</param>
        public AccountBL (IAccountRL accountRL)
        {
            this.accountRL = accountRL;
        }

        /// <summary>
        /// Chat App Registration method
        /// </summary>
        /// <param name="registrationModel">registrationModel parameter</param>
        /// <returns>returns the register data</returns>
        public Task<RegistrationModel> ChatAppRegistration(RegistrationModel registrationModel)
        {
            try
            {
                var response = this.accountRL.ChatAppRegistration(registrationModel);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// Chat App Login method
        /// </summary>
        /// <param name="loginModel">loginModel parameter</param>
        /// <returns>returns the login data</returns>
        public Task<LoginResponseModel> ChatAppLogin(LoginModel loginModel)
        {
            try
            {
                var response = this.accountRL.ChatAppLogin(loginModel);
                return response;
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task<IList<AllUserModel>> GetAllUsers()
        {
            try
            {
                var response = await this.accountRL.GetAllUsers();
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
