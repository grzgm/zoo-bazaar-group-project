using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace ZooBazaar_ASP_NET.Pages
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
            // here check in database if cerdentials are ok

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, Name));
            claims.Add(new Claim("Password", Password));

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

            return RedirectToPage("/Welcome");
        }
    }
}