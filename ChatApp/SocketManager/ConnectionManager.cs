//-----------------------------------------------------------------------
// <copyright file="ConnectionManager.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
// <creater name="Sandhya Patil"/>
//-----------------------------------------------------------------------
namespace ChatApp.SocketManager
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Net.WebSockets;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// ConnectionManager
    /// </summary>
    public class ConnectionManager
    {
        /// <summary>
        /// ConcurrentDictionary for message and web socket
        /// </summary>
        private ConcurrentDictionary<string, WebSocket> connections = new ConcurrentDictionary<string, WebSocket>();

        /// <summary>
        /// GetSocketById Method
        /// </summary>
        /// <param name="id">id parameter</param>
        /// <returns></returns>
        public WebSocket GetSocketById(string id)
        {
            return connections.FirstOrDefault(x => x.Key == id).Value;
        }

        /// <summary>
        /// ConcurrentDictionary 
        /// </summary>
        /// <returns></returns>
        public ConcurrentDictionary<string, WebSocket> GetAllConnections()
        {
            return connections;
        }

        /// <summary>
        /// GetId Method
        /// </summary>
        /// <param name="socket">socket parameter</param>
        /// <returns>returns the id of the socket</returns>
        public string GetId(WebSocket socket)
        {
            return connections.FirstOrDefault(x => x.Value == socket).Key;
        }

        /// <summary>
        /// RemoveSocketAsync Method
        /// </summary>
        /// <param name="id">id parameter</param>
        /// <returns>returns the removed socket</returns>
        public async Task RemoveSocketAsync(string id)
        {
            connections.TryRemove(id, out var socket);
            await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Socket Connetcion Closed", CancellationToken.None);
        }

        /// <summary>
        /// AddSocketMethod
        /// </summary>
        /// <param name="socket">socket parameter</param>
        public void AddSocket(WebSocket socket)
        {
            connections.TryAdd(GetConnectionId(), socket);
        }

        /// <summary>
        /// GetConnectionId Method
        /// </summary>
        /// <returns></returns>
        public string GetConnectionId()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
