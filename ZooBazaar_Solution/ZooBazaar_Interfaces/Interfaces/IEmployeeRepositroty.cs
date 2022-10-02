using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_Interfaces.DTOs;

namespace ZooBazaar_Interfaces.Interfaces
{
    public interface IEmployeeRepositroty
    {
        public List<EmployeeDTO> GetAllEmployees();
    }
}
