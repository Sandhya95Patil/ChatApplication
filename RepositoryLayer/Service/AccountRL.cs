//-----------------------------------------------------------------------
// <copyright file="AccountRL.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
// <creater name="Sandhya Patil"/>
//-----------------------------------------------------------------------
namespace RepositoryLayer.Service
{
    using CommonLayer.Model;
    using CommonLayer.Response;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using RepositoryLayer.EncryptPassword;
    using RepositoryLayer.Interface;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// AccountRL class
    /// </summary>
    public class AccountRL : IAccountRL
    {
        /// <summary>
        /// Inject IConfiguration method for connetcing with databse
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes AccountRl class 
        /// </summary>
        /// <param name="configuration">configuration parameter</param>
        public AccountRL (IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        private readonly string ConnectionString = "server=(LocalDb)\\LocalDB;Database=ChatAppDB;Trusted_Connection=true; MultipleActiveResultSets = true";

        /// <summary>
        /// This method is for registration 
        /// </summary>
        /// <param name="registrationModel">registrationModel parameter</param>
        /// <returns>it return register data</returns>
        public async Task<RegistrationModel> ChatAppRegistration(RegistrationModel registrationModel)
        {
            try
            {
                ////Password encrypt
                var password = PasswordEncrypt.Encryptdata(registrationModel.Password);

                ////Connect with database using SqlConnection
                //SqlConnection sqlConnection = new SqlConnection(configuration["ConnectionStrings:connectionDb"]);
                SqlConnection sqlConnection = new SqlConnection(this.ConnectionString);

                SqlCommand sqlCommand = new SqlCommand("ChatAppRegistration", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@FirstName", registrationModel.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", registrationModel.LastName);
                sqlCommand.Parameters.AddWithValue("@Email", registrationModel.Email);
                sqlCommand.Parameters.AddWithValue("@Password", password);
                sqlCommand.Parameters.AddWithValue("@MobileNumber", registrationModel.MobileNumber);
                sqlConnection.Open();

                var response = await sqlCommand.ExecuteNonQueryAsync();
                if (response > 0)
                {
                    var showResponse = new RegistrationModel()
                    {
                        Id = registrationModel.Id,
                        FirstName = registrationModel.FirstName,
                        LastName = registrationModel.LastName,
                        Email = registrationModel.Email,
                        Password = registrationModel.Password,
                        MobileNumber = registrationModel.MobileNumber
                    };
                    return showResponse;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// This method is for login 
        /// </summary>
        /// <param name="loginModel">loginModel parameter</param>
        /// <returns>it returns login data</returns>
        public async Task<LoginResponseModel> ChatAppLogin(LoginModel loginModel)
        {
            try
            {
                var password = PasswordEncrypt.Encryptdata(loginModel.Password);
                //  SqlConnection sqlConnection = new SqlConnection(configuration["ConnectionStrings:connectionDb"]);
                SqlConnection sqlConnection = new SqlConnection(ConnectionString);

                SqlCommand sqlCommand = new SqlCommand("ChatLogin", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Email", loginModel.Email);
                sqlCommand.Parameters.AddWithValue("@Password", password);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                var userData = new RegistrationModel();
                while (sqlDataReader.Read())
                {
                    userData = new RegistrationModel();
                   userData.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    userData.Email = sqlDataReader["Email"].ToString();
                    userData.Password = sqlDataReader["Password"].ToString();
                    userData.FirstName = sqlDataReader["FirstName"].ToString();
                    userData.LastName = sqlDataReader["LastName"].ToString();
                    userData.MobileNumber = sqlDataReader["MobileNumber"].ToString();
                }
                sqlDataReader.Close();
                if (userData != null)
                {
                    if (password.Equals(userData.Password))
                    {
                        var key = "This is sign in key";

                        ////Here generate encrypted key and result store in security key
                        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

                        //// here using securitykey and algorithm(security) the credentials is generate(SigningCredentials present in Token)
                        var creadintials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                        var claims = new[] {
                         new Claim ("Id", userData.Id.ToString()),
                         new Claim("Email", userData.Email.ToString()),
                         new Claim("Password", userData.Password.ToString()),
                        };

                        var token = new JwtSecurityToken("Security token", "https://Test.com",
                            claims,
                            DateTime.UtcNow,
                            expires: DateTime.Now.AddDays(1),
                            signingCredentials: creadintials);
                        var returnToken = new JwtSecurityTokenHandler().WriteToken(token);

                        var responseShow = new LoginResponseModel()
                        {
                            FirstName = userData.FirstName,
                            LastName = userData.LastName,
                            Email = userData.Email,
                            MobileNumber = userData.MobileNumber,
                            Token = returnToken
                        };
                        return responseShow;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// Get All Users method
        /// </summary>
        /// <returns>return all users</returns>
        public async Task<IList<AllUserModel>> GetAllUsers()
        {
            try
            {
                // SqlConnection sqlConnection = new SqlConnection(configuration["ConnectionStrings:connectionDb"]);
                SqlConnection sqlConnection = new SqlConnection(this.ConnectionString);
                SqlCommand sqlCommand = new SqlCommand("GetAllUsers", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                IList<AllUserModel> registrations = new List<AllUserModel>();
                AllUserModel model = new AllUserModel();

                while (sqlDataReader.Read())
                {
                    model = new AllUserModel();
                    model.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    model.FirstName = sqlDataReader["FirstName"].ToString();
                    model.LastName = sqlDataReader["LastName"].ToString();
                    model.Email = sqlDataReader["Email"].ToString();
                    model.MobileNumber = sqlDataReader["MobileNumber"].ToString();
                    registrations.Add(model);
                }
                sqlConnection.Close();
                return registrations;

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
