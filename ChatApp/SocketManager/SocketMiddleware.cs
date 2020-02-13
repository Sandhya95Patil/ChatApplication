//-----------------------------------------------------------------------
// <copyright file="SocketMiddleware.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
// <creater name="Sandhya Patil"/>
//-----------------------------------------------------------------------
namespace ChatApp.SocketManager
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Net.WebSockets;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Socket Middleware method
    /// </summary>
    public class SocketMiddleware
    {
        /// <summary>
        /// Inject request delegate
        /// </summary>
        private readonly RequestDelegate next;

        /// <summary>
        /// Get and Set Handler
        /// </summary>
        private SocketHandler Handler { get; set; }

        /// <summary>
        /// Initializes the memory for Socket Middleware class
        /// </summary>
        /// <param name="next"></param>
        /// <param name="handler"></param>
        public SocketMiddleware(RequestDelegate next, SocketHandler handler)
        {
            this.next = next;
            Handler = handler;
        }

        /// <summary>
        /// Invoke Async method
        /// </summary>
        /// <param name="context">context parameter</param>
        /// <returns>returns invoke method</returns>
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.WebSockets.IsWebSocketRequest)
                return;
            var socket = await context.WebSockets.AcceptWebSocketAsync();
            await Handler.OnConnected(socket);
            await Receive(socket, async (result, buffer) =>
            {
                if (result.MessageType == WebSocketMessageType.Text)
                {
                    await Handler.Receive(socket, result, buffer);
                }
                else if (result.MessageType == WebSocketMessageType.Close)
                {
                    await Handler.OnDisconnected(socket);

                }
            });
        }

        /// <summary>
        /// Receive method
        /// </summary>
        /// <param name="socket">socket parameter</param>
        /// <param name="messageHandler">messageHandler parameter</param>
        /// <returns>returns receive message</returns>
        private async Task Receive(WebSocket socket, Action<WebSocketReceiveResult, byte[]> messageHandler)
        {
            var buffer = new byte[1024 * 4];
            while (socket.State == WebSocketState.Open)
            {
                var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                messageHandler(result, buffer);
            }
        }   
    }
}
