using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_Repositories.Interfaces
{
    public interface IEmployeeRepositroty
    {
        public List<EmployeeDTO> GetAllEmployees();
        public void AddNewEmployee(EmployeeDTO employeeDTO);
        EmployeeDTO GetByEmployeeId(int ID);
        void Insert(EmployeeDTO dto);
        void Update(EmployeeDTO dto);
        void Delete(EmployeeDTO dto);
        int nextID();
    }
}
