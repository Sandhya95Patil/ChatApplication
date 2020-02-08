using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ChatController : ControllerBase
    {
        private readonly IChatBL chatBL;
        public ChatController(IChatBL chatBL)
        {
            this.chatBL = chatBL;
        }

        [HttpPost]
        [Route("SendMessage")]
        public async Task<IActionResult> AddMessage(AddMessageModel addMessageModel)
        {
            try
            {
                var claim = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
                var data = await this.chatBL.AddMessage(addMessageModel, claim) ;
                if (data != null)
                {
                    return this.Ok(new { status = "True", Message = "Send Message Successfully", data});
                }
                else
                {
                    return this.BadRequest(new { status = "false", message = "Failed To Send Message" });
                }
            }
            catch (Exception exception)
            {
                return this.BadRequest(new { Message = exception.Message });
            }
        }

        [HttpGet]
        [Route("AllMessages/{receiverId}")]
        public async Task<IActionResult> GetAllMessages(int receiverId)
        {
            try
            {
                var claim = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
                var data = await this.chatBL.GetAllMessage(claim, receiverId);
                if (data != null)
                {
                    return this.Ok(new { status = "true", message = "All Messages", data});
                }
                else
                {
                    return this.BadRequest(new { status = "false", message = "Failed To Get Messages" });
                }
            }
            catch (Exception exception)
            {
                return this.BadRequest(new { message = exception.Message });
            }
        }
    }
}