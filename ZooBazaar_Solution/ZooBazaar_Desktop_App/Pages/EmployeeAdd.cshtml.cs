using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_ClassLibrary.Menagers;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_Desktop_App.Pages
{
    public class EmployeeAddModel : PageModel
    {

        [BindProperty]
        public EmployeeAddDTO employeeDTO { get; set; }


        private readonly IEmployeeMenager _employeeMenager;
        public EmployeeAddModel(IEmployeeMenager employeeMenager)
        {
            _employeeMenager = employeeMenager;
        }




        public void OnGet()
        {
           

        }

        public IActionResult OnPostCreate()
        {
            if (ModelState.IsValid)
            {
                _employeeMenager.NewEmployee(employeeDTO);
                return new RedirectToPageResult("EmployeeList");
            }
            else
            {
                return Page();

            }
        }
    }
}
