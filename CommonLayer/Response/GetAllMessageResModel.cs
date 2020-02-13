//-----------------------------------------------------------------------
// <copyright file="GetAllMessageResModel.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
// <creater name="Sandhya Patil"/>
//-----------------------------------------------------------------------
namespace CommonLayer.Response
{
    /// <summary>
    /// Get All Message Res Model class
    /// </summary>
    public class GetAllMessageResModel
    {
        /// <summary>
        /// get and set id
        /// </summary>
        public int Id { get; set; }

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
