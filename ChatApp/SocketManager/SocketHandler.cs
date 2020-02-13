//-----------------------------------------------------------------------
// <copyright file="SocketHandler.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
// <creater name="Sandhya Patil"/>
//-----------------------------------------------------------------------
namespace ChatApp.SocketManager
{
    using System;
    using System.Net.WebSockets;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// SocketHandler class
    /// </summary>
    public abstract class SocketHandler
    {
        /// <summary>
        /// set and get ConnectionManager 
        /// </summary>
        public ConnectionManager connection { get; set; }

        /// <summary>
        /// Initializes ConnectionManager class
        /// </summary>
        /// <param name="connection">connection</param>
        public SocketHandler(ConnectionManager connection)
        {
            this.connection = connection;
        }

        /// <summary>
        /// On Connected method
        /// </summary>
        /// <param name="socket">socket parameter</param>
        /// <returns>connect to the socket</returns>
        public virtual async Task OnConnected(WebSocket socket)
        {
            await Task.Run(() => { connection.AddSocket(socket); });
        }

        /// <summary>
        /// On Disconnected method
        /// </summary>
        /// <param name="socket">socket parameter</param>
        /// <returns>disconnected the socketg</returns>
        public virtual async Task OnDisconnected(WebSocket socket)
        {
            await connection.RemoveSocketAsync(connection.GetId(socket));
        }

        /// <summary>
        /// Send Message method
        /// </summary>
        /// <param name="socket">socket parameter</param>
        /// <param name="message">message parameter</param>
        /// <returns></returns>
        public async Task SendMessage(WebSocket socket, string message)
        {
            if (socket.State != WebSocketState.Open)
                return;
            await socket.SendAsync(new ArraySegment<byte>(Encoding.ASCII.GetBytes(message), 0, message.Length), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        /// <summary>
        /// Send Message method
        /// </summary>
        /// <param name="id">id parameter</param>
        /// <param name="message">message parameter</param>
        /// <returns>send the message</returns>
        public async Task SendMessage(string id, string message)
        {
            await SendMessage(connection.GetSocketById(id), message);
        }

        /// <summary>
        /// Send Message To All method
        /// </summary>
        /// <param name="message">message parameter</param>
        /// <returns>send to all user</returns>
        public async Task SendMessageToAll(string message)
        {
            foreach (var con in connection.GetAllConnections())
                await SendMessage(con.Value, message);
        }

        /// <summary>
        /// Receive method
        /// </summary>
        /// <param name="socket">socket parameter</param>
        /// <param name="result">result parameter</param>
        /// <param name="buffer">buffer parameter</param>
        /// <returns></returns>
        public abstract Task Receive(WebSocket socket, WebSocketReceiveResult result, byte[] buffer);
    }
}

