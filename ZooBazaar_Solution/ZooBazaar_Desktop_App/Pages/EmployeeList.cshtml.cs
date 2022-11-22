using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_DomainModels.Models;

namespace ZooBazaar_Desktop_App.Pages
{
    public class EmployeeListModel : PageModel
    {
        private IEmployeeMenager _employeeMenager;


        public List<Employee> _employees;

        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        [BindProperty(SupportsGet = true)]
        public string LastName { get; set; }


        public EmployeeListModel(IEmployeeMenager employeeMenager)
        {
           this._employeeMenager = employeeMenager;

            _employees = this._employeeMenager.GetAll();  
            
        }
        public void OnGet()
        {
        }

        public void OnPostName()
        {
            if (Name == null)
                return;
            _employees = _employees.FindAll(employee => employee.FirstName == this.Name);
        }
        public void OnPostLastName()
        {
            if (LastName == null)
                return;
            _employees = _employees.FindAll(employee => employee.LastName == this.LastName);
        }

    }
}
