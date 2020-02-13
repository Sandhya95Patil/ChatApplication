//-----------------------------------------------------------------------
// <copyright file="AddMessageResponseModel.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
// <creater name="Sandhya Patil"/>
//-----------------------------------------------------------------------
namespace CommonLayer.Response
{
    /// <summary>
    /// Add Message Response Model class
    /// </summary>
    public class AddMessageResponseModel
    {
        /// <summary>
        /// get and set message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// get and set sender id
        /// </summary>
        public int SenderId { get; set; }

        /// <summary>
        /// get and set receiver id
        /// </summary>
        public int ReceiverId { get; set; }
    }
}
