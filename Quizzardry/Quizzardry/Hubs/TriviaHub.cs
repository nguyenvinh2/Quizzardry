using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Quizzardry.Hubs
{
    public class TriviaHub:Hub
    {

        public async Task<IActionResult> SendMessage(string user)
        {
            await Clients.All.SendAsync("ReceiveMessage", user);
        }

    }
}
