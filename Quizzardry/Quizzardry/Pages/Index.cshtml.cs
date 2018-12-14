using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Quizzardry.Models;
using Quizzardry.Hubs;

namespace Quizzardry.Pages
{
    public class IndexModel : PageModel
    {

        [BindProperty]
        public Player Player { get; set; }
        public void OnGet()
        {
        }
        [HttpPost]
        public void OnPostUpdate()
        {
            //Player.ID = Guid.NewGuid();
            HttpContext.Session.SetString("user", JsonConvert.SerializeObject(Player));
            Response.Redirect("Game");
        }
    }
}