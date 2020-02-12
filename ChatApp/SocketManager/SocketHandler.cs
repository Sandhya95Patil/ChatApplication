using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatApp.SocketManager
{
    public abstract class SocketHandler
    {
        public ConnectionManager connection { get; set; }
        public SocketHandler(ConnectionManager connection)
        {
            this.connection = connection;
        }
        public virtual async Task OnConnected(WebSocket socket)
        {
            await Task.Run(() => { connection.AddSocket(socket); });
        }
        public virtual async Task OnDisconnected(WebSocket socket)
        {
            await connection.RemoveSocketAsync(connection.GetId(socket));
        }
        public async Task SendMessage(WebSocket socket, string message)
        {
            if (socket.State != WebSocketState.Open)
                return;
            await socket.SendAsync(new ArraySegment<byte>(Encoding.ASCII.GetBytes(message), 0, message.Length), WebSocketMessageType.Text, true, CancellationToken.None);
        }
        public async Task SendMessage(string id, string message)
        {
            await SendMessage(connection.GetSocketById(id), message);
        }
        public async Task SendMessageToAll(string message)
        {
            foreach (var con in connection.GetAllConnections())
                await SendMessage(con.Value, message);
        }
        public abstract Task Receive(WebSocket socket, WebSocketReceiveResult result, byte[] buffer);
    }
}

