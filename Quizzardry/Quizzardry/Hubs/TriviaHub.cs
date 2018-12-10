using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Http;

namespace Quizzardry.Hubs
{
    public class TriviaHub:Hub
    {

        public async Task SendMessage(string user, IFormCollection option)
        {
            await Clients.All.SendAsync("ReceiveMessage", option["user"], option["option"]);
        }

    }
}
