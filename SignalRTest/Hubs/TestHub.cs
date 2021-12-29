using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRTest.Hubs
{
    public class TestHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Clients.All.SendAsync("ReceiveMessage", "User has connected");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Clients.All.SendAsync("ReceiveMessage", "User has disconnected");
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendPing()
        {
            await Clients.Clients(Context.ConnectionId).SendAsync("ReceivePing", "Received");
        }
    }
}
