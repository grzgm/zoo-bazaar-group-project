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
    public class EmployeeRepository : IEmployeeRepositroty
    {
        private string connectionString = "Server=mssqlstud.fhict.local;Database=dbi463992;User Id=dbi463992;Password=gogotpilon;";

        List<EmployeeDTO> IEmployeeRepositroty.GetAllEmployees()
        {
            List<EmployeeDTO> employeeDTOs = new List<EmployeeDTO>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT * FROM Employee";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int employeeid = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string role = reader.GetString(2);
                        int timepreferenceID = reader.GetInt32(3);

                        employeeDTOs.Add(new EmployeeDTO
                        {
                            Id = employeeid,
                            Name = name,
                            Role = role,
                            TimePreferenceID = timepreferenceID
                        });
                    }
                }
            }
            return employeeDTOs;
        }
    }
}
