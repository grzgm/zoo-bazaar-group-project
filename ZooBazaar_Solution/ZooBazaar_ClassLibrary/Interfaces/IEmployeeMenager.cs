using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DomainModels.Models;

namespace ZooBazaar_ClassLibrary.Interfaces
{
    public interface IEmployeeMenager
    {
        Employee GetEmployee(int id);
        List<Employee> GetAll();
        Employee NewEmployee(int id, string firstNane, string lastName, string email, string phone, string adress, ROLE role);
        Employee RemoveEmployee(int id);
        Employee UpdateEmployee(); //WHAT THE FUCK TO I PASS? A FUCKING AnimalDTO OR RA DATA?


    }
}
