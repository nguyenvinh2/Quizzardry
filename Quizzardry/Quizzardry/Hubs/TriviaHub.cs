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
        private readonly static StorageHub<Guid> _connections =
    new StorageHub<Guid>();

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendUser(string user, Guid id)
        {
            await OnConnected(user, id);
            List<Player> userList = _connections.GetList();
            await Clients.All.SendAsync("ReceiveUser", userList);
        }

        public Task OnConnected(string user, Guid id)
        {
            bool exists = false;
            Dictionary<Guid, Player> userList = _connections.GetConnections();
            exists = userList.ContainsKey(id);
            if (!exists)
            {
                Player NewPlayer = new Player();
                NewPlayer.Name = user;
                NewPlayer.Score = 0;
                _connections.Add(NewPlayer.ID, NewPlayer);
            }
            return base.OnConnectedAsync();
        }

    }
}
