using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using ElectronNET.API;
using System.ComponentModel.DataAnnotations;

namespace ZooBazaar_Desktop_App.Pages
{
    public class IndexModel : PageModel
    {

        [BindProperty, Required(ErrorMessage ="Please fullfill")]

        public string Name { get; set; }
        [BindProperty, Required(ErrorMessage = "Please fullfill")]
       
        public string Password { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                return new RedirectToPageResult("Welcome");
               
            }
            else
            { 
                return Page();
               
            }           
        }
    }
}