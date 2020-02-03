//-----------------------------------------------------------------------
// <copyright file="AccountController.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
// <creater name="Sandhya Patil"/>
//-----------------------------------------------------------------------
namespace ChatApp.Controllers
{
    using System;
    using System.Threading.Tasks;
    using BusinessLayer.Interface;
    using CommonLayer.Model;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// AccountController class
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        /// <summary>
        /// Inject Account interface of business layer
        /// </summary>
        private readonly IAccountBL accountBL;

        /// <summary>
        /// Initializes the Account Controller
        /// </summary>
        /// <param name="accountBL"></param>
        public AccountController (IAccountBL accountBL)
        {
            this.accountBL = accountBL;
        }

        /// <summary>
        /// ChatAppSignUp Method
        /// </summary>
        /// <param name="registrationModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> ChatAppSignUp(RegistrationModel registrationModel)
        {
            try
            {
                var data = await this.accountBL.ChatAppRegistration(registrationModel);
                if (data != null)
                {
                    return this.Ok(new { status = "true", message = "Register Successfully", data });
                }
                else
                {
                    return this.BadRequest(new { status = "False", message = "Failed To Register" });
                }
            }
            catch (Exception exception)
            {
                return this.BadRequest(new { message = exception.Message });
            }
        }

        /// <summary>
        /// ChatAppLogin method
        /// </summary>
        /// <param name="loginModel">loginModel parameter</param>
        /// <returns>returns the login data</returns>
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> ChatAppLogin(LoginModel loginModel)
        {
            try
            {
                var data = await this.accountBL.ChatAppLogin(loginModel);
                if (data != null)
                {
                    return this.Ok(new { status = "true", message = "Login Successfully", data });
                }
                else
                {
                    return this.BadRequest(new { status = "False", message = "Failed To Login" });
                }
            }
            catch (Exception exception)
            {
                return this.BadRequest(new { message = exception.Message });
            }
        }

        [HttpGet]
        [Route ("AllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var data = await this.accountBL.GetAllUsers();
                if (data != null)
                {
                    return this.Ok(new { status = "true", message = "All Users", data });
                }
                else
                {
                    return this.BadRequest(new { status = "false", message = "Failed To Get All Users" });
                }
            }
            catch (Exception exception)
            {
                return this.BadRequest(new { message = exception.Message });
            }
        }
    }
}