using ChatApp.SocketManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Handler
{
    public class WebSocketMessageHandler : SocketHandler
    {
        public WebSocketMessageHandler(ConnectionManager connection): base(connection)
        {

        }
        public override async Task OnConnected(WebSocket socket)
        {
            await base.OnConnected(socket);
            var socketId = connection.GetId(socket);
           // await SendMessageToAll($"{socketId} just joined the ChatApp ****");
            await SendMessageToAll($"");

        }
        public override async Task Receive(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
        {
            var socketId = connection.GetId(socket);
            //var message = $"{socketId} said: {Encoding.UTF8.GetString(buffer, 0, result.Count)}";
            var message = $" {Encoding.UTF8.GetString(buffer, 0, result.Count)}";
            await SendMessageToAll(message);
        }
    }
}
