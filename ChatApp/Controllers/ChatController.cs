//-----------------------------------------------------------------------
// <copyright file="ChatController.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
// <creater name="Sandhya Patil"/>
//-----------------------------------------------------------------------
namespace ChatApp.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using BusinessLayer.Interface;
    using CommonLayer.Model;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// ChatController class
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChatController : ControllerBase
    {
        /// <summary>
        /// Inject the Chat interface
        /// </summary>
        private readonly IChatBL chatBL;

        /// <summary>
        /// Initializes the chat controller class 
        /// </summary>
        /// <param name="chatBL"></param>
        public ChatController(IChatBL chatBL)
        {
            this.chatBL = chatBL;
        }

        /// <summary>
        /// AddMessage Method
        /// </summary>
        /// <param name="addMessageModel">addMessageModel parameter</param>
        /// <returns>returns the added message</returns>
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

        /// <summary>
        /// Get All Messages method
        /// </summary>
        /// <param name="receiverId">receiverId parameter</param>
        /// <returns>returns the all messages</returns>
        [HttpGet]
        [Route("AllMessages/{receiverId}")]
        public async Task<IActionResult> GetAllMessages()
        {
            try
            {
                //var claim = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
                var data = await this.chatBL.GetAllMessage();
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