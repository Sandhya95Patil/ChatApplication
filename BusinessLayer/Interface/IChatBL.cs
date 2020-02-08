using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CommonLayer.Model;
using CommonLayer.Response;

namespace BusinessLayer.Interface
{
    public interface IChatBL
    {
        Task<AddMessageResponseModel> AddMessage(AddMessageModel addMessageModel, int senderId);
        Task<IList<GetAllMessageResModel>> GetAllMessage(int senderId, int receiverId);
    }
}
