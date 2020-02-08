using CommonLayer.Model;
using CommonLayer.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IChatRL
    {
        Task<AddMessageResponseModel> AddMessage(AddMessageModel addMessageModel, int senderId);
        Task<IList<GetAllMessageResModel>> GetAllMessages(int senderId, int ReceiverId);
    }
}
