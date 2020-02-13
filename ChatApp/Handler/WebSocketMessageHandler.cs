//-----------------------------------------------------------------------
// <copyright file="WebSocketMessageHandler.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
// <creater name="Sandhya Patil"/>
//-----------------------------------------------------------------------
namespace ChatApp.Handler
{
    using ChatApp.SocketManager;
    using System.Net.WebSockets;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// WebSocketMessageHandler class
    /// </summary>
    public class WebSocketMessageHandler : SocketHandler
    {
        public WebSocketMessageHandler(ConnectionManager connection): base(connection)
        {

        }

        /// <summary>
        /// OnConnected Method
        /// </summary>
        /// <param name="socket">socket parameter</param>
        /// <returns></returns>
        public override async Task OnConnected(WebSocket socket)
        {
            await base.OnConnected(socket);
            var socketId = connection.GetId(socket);
           // await SendMessageToAll($"{socketId} just joined the ChatApp ****");
            await SendMessageToAll($"");

        }

        /// <summary>
        /// Receive method
        /// </summary>
        /// <param name="socket">socket parameter</param>
        /// <param name="result">result parameter</param>
        /// <param name="buffer">buffer parameter</param>
        /// <returns>returns the receive message</returns>
        public override async Task Receive(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
        {
            var socketId = connection.GetId(socket);
            //var message = $"{socketId} said: {Encoding.UTF8.GetString(buffer, 0, result.Count)}";
            var message = $" {Encoding.UTF8.GetString(buffer, 0, result.Count)}";
            await SendMessageToAll(message);
        }
    }
}
