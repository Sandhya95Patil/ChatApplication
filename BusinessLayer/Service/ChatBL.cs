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
    public class ChatBL : IChatBL
    {
        private readonly IChatRL chatRL;
        public ChatBL (IChatRL chatRL)
        {
            this.chatRL = chatRL;
        }

        public Task<AddMessageResponseModel> AddMessage(AddMessageModel addMessageModel, int senderId)
        {
            try
            {
                var response = this.chatRL.AddMessage(addMessageModel, senderId);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public Task<IList<GetAllMessageResModel>> GetAllMessage(int senderId, int receiverId)
        {
            try
            {
                var response = this.chatRL.GetAllMessages(senderId, receiverId);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
