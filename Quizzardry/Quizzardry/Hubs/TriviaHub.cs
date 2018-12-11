using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizzardry.Models;
using Newtonsoft.Json;
using Quizzardry.Models.Interfaces;
using Quizzardry.Hubs;

namespace Quizzardry.Hubs
{
    public class TriviaHub : Hub
    {
        private readonly static StorageHub<string> _connections =
    new StorageHub<string>();

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendUser(string user)
        {
            await OnConnected(user);
            var userList = _connections.GetConnections();
            await Clients.All.SendAsync("ReceiveUser", userList);
        }

        public Task OnConnected(string user)
        {
            _connections.Add(Context.ConnectionId, user);

            return base.OnConnectedAsync();
        }

    }
}
