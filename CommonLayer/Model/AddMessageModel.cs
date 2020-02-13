//-----------------------------------------------------------------------
// <copyright file="AddMessageModel.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
// <creater name="Sandhya Patil"/>
//-----------------------------------------------------------------------
namespace CommonLayer.Model
{
    /// <summary>
    /// Add Message Model class
    /// </summary>
    public class AddMessageModel
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
        /// get and set receiver id
        /// </summary>
        public int ReceiverId { get; set; }
    }
}
