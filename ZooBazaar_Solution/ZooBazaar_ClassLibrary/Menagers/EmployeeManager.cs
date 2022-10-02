using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_Interfaces.Interfaces;

namespace ZooBazaar_ClassLibrary.Menagers
{
    internal class EmployeeManager 
    {
        IEmployeeRepositroty _employeeRepositroty;
        public EmployeeManager(IEmployeeRepositroty employeeRepositroty)
        {
            this._employeeRepositroty = employeeRepositroty;
        }
    }
}
