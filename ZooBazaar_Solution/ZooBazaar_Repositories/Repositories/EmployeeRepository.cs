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

        void IEmployeeRepositroty.AddNewEmployee(EmployeeDTO employeeDTO)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string insertQuery = "INSERT INTO Employee VALUES (@EmployeeID,@FirstName,@LastName,@Email,@Role)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employeeDTO.Id);
                    command.Parameters.AddWithValue("@FirstName", employeeDTO.FirstName);
                    command.Parameters.AddWithValue("@LastName", employeeDTO.LastName);
                    command.Parameters.AddWithValue("@Email", employeeDTO.Email);
                    command.Parameters.AddWithValue("@Role", employeeDTO.Role);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

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
                        string firstname = reader.GetString(1);
                        string lastname = reader.GetString(2);
                        string email = reader.GetString(3);
                        string role = reader.GetString(4);

                        employeeDTOs.Add(new EmployeeDTO
                        {
                            Id = employeeid,
                            FirstName = firstname,
                            LastName = lastname,
                            Email = email,
                            Role = role
                        });
                    }
                }
            }
            return employeeDTOs;
        }
    }
}
