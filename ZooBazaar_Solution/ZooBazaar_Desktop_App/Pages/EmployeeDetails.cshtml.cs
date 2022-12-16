using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_ClassLibrary.Menagers;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_Desktop_App.Pages
{
    public class EmployeeDetailsModel : PageModel
    {
        [BindProperty]
        public int ID { get; set; }

        [BindProperty]
        public EmployeeDTO employeeDTO { get; set; }

        private readonly IEmployeeMenager _employeeMenager;

        public EmployeeDetailsModel(IEmployeeMenager employeeMenager)
        {
            _employeeMenager = employeeMenager;
        }

        public void OnGet(int postId)
        {
            this.ID = postId;
            
            employeeDTO = _employeeMenager.GetEmployeeDTO(postId);

            employeeDTO.Password = "";



        }

        public IActionResult OnPostUpdate()
        {

            if (ModelState.IsValid)
            {
                _employeeMenager.UpdateEmployee(employeeDTO);
                return new RedirectToPageResult("EmployeeList");

            }
            else
            {
                return Page();

            }
        }
    }
}
