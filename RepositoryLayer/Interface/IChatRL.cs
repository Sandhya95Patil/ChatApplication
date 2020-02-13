//-----------------------------------------------------------------------
// <copyright file="IChatRL.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
// <creater name="Sandhya Patil"/>
//-----------------------------------------------------------------------
namespace RepositoryLayer.Interface
{
    using CommonLayer.Model;
    using CommonLayer.Response;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// IChatRL interface
    /// </summary>
    public interface IChatRL
    {
        /// <summary>
        /// Add Message method
        /// </summary>
        /// <param name="addMessageModel">addMessageModel parameter</param>
        /// <param name="senderId">senderId parameter</param>
        /// <returns>returns added message</returns>
        Task<AddMessageResponseModel> AddMessage(AddMessageModel addMessageModel, int senderId);

        /// <summary>
        /// Get All Messages method
        /// </summary>
        /// <param name="senderId">senderId parameter</param>
        /// <param name="ReceiverId">ReceiverId parameter</param>
        /// <returns>returns all messages</returns>
        Task<IList<GetAllMessageResModel>> GetAllMessages(int senderId, int ReceiverId);
    }
}
