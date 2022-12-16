using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_Desktop_App.Pages
{
    public class EmployeeAddModel : PageModel
    {


        public EmployeeAddDTO employeeDTO { get; set; }


        private readonly IEmployeeMenager _employeeMenager;
        public EmployeeAddModel(IEmployeeMenager employeeMenager)
        {
            _employeeMenager = employeeMenager;
        }



        public void OnGet()
        {
        }
    }
}
