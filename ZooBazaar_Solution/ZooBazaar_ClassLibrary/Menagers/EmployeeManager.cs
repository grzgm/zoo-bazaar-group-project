using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_DTO.DTOs;
using ZooBazaar_Repositories.Interfaces;

namespace ZooBazaar_ClassLibrary.Menagers
{
    public class EmployeeManager : IEmployeeMenager
    {
        private readonly IEmployeeRepositroty _employeeRepositroty;
        public EmployeeManager(IEmployeeRepositroty employeeRepositroty)
        {
            this._employeeRepositroty = employeeRepositroty;
        }

        public List<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();    
            foreach(EmployeeDTO dto in _employeeRepositroty.GetAllEmployees())
            {
                employees.Add(new Employee(dto));
            }
            return employees;
        }

        public Employee GetEmployee(int id)
        {
            return new Employee(_employeeRepositroty.GetByEmployeeId(id));
        }

        public void NewEmployee(EmployeeDTO employeeDTO)
        {
            _employeeRepositroty.AddNewEmployee(employeeDTO);
        }

        public void RemoveEmployee(int id)
        {
            _employeeRepositroty.Delete(id);
        }

        public void UpdateEmployee(EmployeeDTO employeeDTO)
        {
            _employeeRepositroty.Update(employeeDTO);
        }
    }
}
