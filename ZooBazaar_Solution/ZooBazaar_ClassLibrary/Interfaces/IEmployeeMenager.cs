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


       
    }
}
