using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_ClassLibrary.Menagers;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_Repositories.Interfaces;
using ZooBazaar_Repositories.Repositories;

namespace ZooBazaar_ASP_NET.Pages
{
    public class IndexModel : PageModel
    {
        private IEmployeeRepositroty employeeRepositroty;
        private IEmployeeMenager employeeMenager;

        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public string mess { get; set; }

        public void OnGet()
        {
            //AutomaticScheduleManager automaticScheduleManager = new AutomaticScheduleManager();
            //automaticScheduleManager.MakeSchedule(new DateOnly(2023, 1, 9));
        }

        public IActionResult OnPost()
        {
            employeeRepositroty = new EmployeeRepository();
            employeeMenager = new EmployeeManager(employeeRepositroty);
            // here check in database if cerdentials are ok
            if (Email != null && Password != null)
            {
                Employee employee = null;
                try
                {
                    employee = employeeMenager.LoginEmployee(Email, Password);
                }
                catch (Exception ex)
                {
                    mess = "Wrong credentials.";
                    return Page();
                }
                if (employee != null)
                {
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, employee.FirstName));
                    claims.Add(new Claim("Id", employee.ID.ToString()));

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                    return RedirectToPage("/Welcome");
                }
                else
                {
                    mess = "Wrong credentials.";
                    return Page(); }
            }
            else
            {
                mess = "Wrong credentials.";
                return Page(); 
            }
        }
    }
}