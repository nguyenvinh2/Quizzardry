using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Quizzardry.Models;

namespace Quizzardry.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Users Username { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostUpdate()
        {
            Users profile = new Users();
            profile.username = Username.username;
            HttpContext.Session.SetString("user", JsonConvert.SerializeObject(profile));

            string name = HttpContext.Session.GetString("user");
            return RedirectToAction("Game");
        }
    }
}