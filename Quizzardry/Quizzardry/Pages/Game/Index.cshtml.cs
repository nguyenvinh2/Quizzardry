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

namespace Quizzardry.Pages.Game
{
    public class IndexModel : PageModel
    {
        public string user { get; set; }
        public void OnGet()
        {
            var userJSON = HttpContext.Session.GetString("user");
            var username = JsonConvert.DeserializeObject<Users>(userJSON);
            user = username.username;
        }
    }
}