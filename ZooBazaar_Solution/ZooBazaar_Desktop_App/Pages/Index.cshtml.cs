using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using ElectronNET.API;

namespace ZooBazaar_Desktop_App.Pages
{
    public class IndexModel : PageModel
    {

        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {



            return RedirectToPage("Welcome");

           
        }
    }
}