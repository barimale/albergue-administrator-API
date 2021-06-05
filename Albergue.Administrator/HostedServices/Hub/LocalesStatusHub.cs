using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;

namespace Albergue.Administrator.HostedServices.Hub
{
    [Authorize]
    public class LocalesStatusHub : Microsoft.AspNetCore.SignalR.Hub
    {
        public override Task OnConnectedAsync()
        {
            Console.WriteLine(base.Context.ConnectionId + " is connected");

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            Console.WriteLine(base.Context.ConnectionId + " is disconnected");

            return base.OnDisconnectedAsync(exception);
        }

        public Task SendMessageAsync(string message)
        {
            return Clients?.All?.SendCoreAsync("ReceiveMessage", new object[] { message });
        }

        public Task SendMessageToCallerAsync(string message)
        {
            return Clients?.Caller?.SendCoreAsync("ReceiveMessage", new object[] { message });
        }

        public Task SendMessageToGroupAsync(string groupName, string message)
        {
            return Clients?.Group(groupName)?.SendCoreAsync("ReceiveMessage", new object[] { message });
        }
    }
}
