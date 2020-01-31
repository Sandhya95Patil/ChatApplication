using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountBL accountBL;
        public AccountController (IAccountBL accountBL)
        {
            this.accountBL = accountBL;
        }

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
    }
}