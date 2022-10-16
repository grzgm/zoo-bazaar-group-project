using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;
using ZooBazaar_Repositories.Interfaces;
using System.Data.SqlClient;

namespace ZooBazaar_Repositories.Repositories
{
    public class EmployeeRepository : DapperBaseRepository,IEmployeeRepositroty
    {

        void IEmployeeRepositroty.Delete(int id)
        {
            string Query = "DELETE FROM Employee WHERE EmployeeID = @EmployeeID";
            Execute(Query, new { EmployeeID = id });
        }

        List<EmployeeDTO> IEmployeeRepositroty.GetAllEmployees()
        {
            string selectQuery = "SELECT * FROM Employee";
            return Query<EmployeeDTO>(selectQuery);
        }

        EmployeeDTO IEmployeeRepositroty.GetByEmployeeId(int ID)
        {
            string selectQuery = "SELECT * FROM Employee WHERE EmployeeID = @ID";
            return QuerySingle<EmployeeDTO>(selectQuery, new { ID = ID});
        }

        void IEmployeeRepositroty.Insert(EmployeeAddDTO dto)
        {
            string Query = "INSERT INTO Employee VALUES (@FirstName,@LastName,@Email,@Phone,@Address,@Role)";
            Execute(Query, new {FirstName = dto.FirstName, LastName = dto.LastName, Email = dto.Email, Phone = dto.Phone, Address = dto.Address, Role = dto.Role});
        }

        int IEmployeeRepositroty.nextID()
        {
            string Query = "SELECT MAX(EmployeeID) FROM Employee";
            return QuerySingle<int>(Query);
        }

        void IEmployeeRepositroty.Update(EmployeeDTO dto)
        {
            string Query = "UPDATE Employee SET FirstName=@FirstName,LastName=@LastName,Email=@Email,Phone=@Phone,Address=@Address,Role=@Role WHERE EmployeeID=@EmployeeID";
            Execute(Query, new { EmlpoyeeID = dto.EmployeeID, FirstName = dto.FirstName, LastName = dto.LastName, Email = dto.Email, Phone = dto.Phone, Address = dto.Address, Role = dto.Role });
        }
    }
}
