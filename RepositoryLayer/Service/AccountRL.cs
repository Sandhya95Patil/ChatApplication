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

namespace RepositoryLayer.Service
{
    public class AccountRL : IAccountRL
    {
        private readonly IConfiguration configuration;
        public AccountRL (IConfiguration configuration)
        {
            this.configuration = configuration;
        }
       
        public async Task<RegistrationModel> ChatAppRegistration(RegistrationModel registrationModel)
        {
            try
            {
                var password = PasswordEncrypt.Encryptdata(registrationModel.Password);
                SqlConnection sqlConnection = new SqlConnection(configuration["ConnectionStrings:connectionDb"]);
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
        public async Task<LoginResponseModel> ChatAppLogin(LoginModel loginModel)
        {
            try
            {
                var password = PasswordEncrypt.Encryptdata(loginModel.Password);
                SqlConnection sqlConnection = new SqlConnection(configuration["ConnectionStrings:connectionDb"]);

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
    }
}
