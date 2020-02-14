//-----------------------------------------------------------------------
// <copyright file="IEmployeeBusiness.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
// <creater name="Sandhya Patil"/>
//-----------------------------------------------------------------------
namespace BusinessLayer.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CommonLayer.Model;
    using CommonLayer.Response;

    /// <summary>
    /// IChatBL interface
    /// </summary>
    public interface IChatBL
    {
        Task<AddMessageResponseModel> AddMessage(AddMessageModel addMessageModel, int senderId);
        Task<IList<GetAllMessageResModel>> GetAllMessage();
    }
}
