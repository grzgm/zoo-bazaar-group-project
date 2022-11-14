using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZooBazaar_ASP_NET.Pages
{
    public class WelcomeModel : PageModel
    {
        public void OnGet()
        {
            if (Request.Cookies.ContainsKey("weekNumber"))
            {
                Response.Cookies.Delete("weekNumber");
                Response.Cookies.Delete("firstDayOfWeek");
            }
        }
    }
}
