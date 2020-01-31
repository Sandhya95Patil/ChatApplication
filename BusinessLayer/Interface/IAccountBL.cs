using CommonLayer.Model;
using CommonLayer.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IAccountBL
    {
        Task<RegistrationModel> ChatAppRegistration(RegistrationModel registrationModel);
        Task<LoginResponseModel> ChatAppLogin(LoginModel loginModel);
    }
}
