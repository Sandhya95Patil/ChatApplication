
namespace RepositoryLayer.Interface
{
    using CommonLayer.Model;
    using CommonLayer.Response;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAccountRL
    {
        Task<RegistrationModel> ChatAppRegistration(RegistrationModel registrationModel);
        Task<LoginResponseModel> ChatAppLogin(LoginModel loginModel);
        Task <IList<AllUserModel>> GetAllUsers();
    }
}
