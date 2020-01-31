using BusinessLayer.Interface;
using CommonLayer.Model;
using CommonLayer.Response;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class AccountBL:IAccountBL
    {
        private readonly IAccountRL accountRL;
        public AccountBL (IAccountRL accountRL)
        {
            this.accountRL = accountRL;
        }

    
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

    }
}
