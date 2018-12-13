using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http;
using Newtonsoft.Json;
using System.Dynamic;
using Quizzardry.Models;
using Quizzardry.Hubs;
using Quizzardry.Models.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Quizzardry.Data;

namespace Quizzardry.Pages.Game
{
    public class IndexModel : PageModel
    {
        public Player Player { get; set; }

        public IActionResult OnGet()
        {
            var userJSON = HttpContext.Session.GetString("user");
            if (userJSON == null)
            {
                return Redirect("/");
            }
            Player = JsonConvert.DeserializeObject<Player>(userJSON);
            return Page();
        }
    }
}