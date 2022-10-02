using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_ClassLibrary.Interfaces
{
    public interface IEmployeeMenager
    {
        Employee GetEmployee(int id);
        List<Employee> GetAll();
        Employee NewEmployee(EmployeeDTO employeeDTO);
        Employee RemoveEmployee(int id);
        Employee UpdateEmployee(EmployeeDTO employeeDTO);


    }
}
