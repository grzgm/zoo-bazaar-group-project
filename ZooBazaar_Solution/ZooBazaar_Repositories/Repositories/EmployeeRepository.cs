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

        void IEmployeeRepositroty.Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string Query = "DELETE FROM Employee WHERE EmployeeID = @EmployeeID";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", id);

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

        EmployeeDTO IEmployeeRepositroty.GetByEmployeeId(int ID)
        {
            EmployeeDTO employeeDTO = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT * FROM Employee WHERE EmployeeID = @ID";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int employeeid = reader.GetInt32(0);
                        string firstname = reader.GetString(1);
                        string lastName = reader.GetString(2);
                        string email = reader.GetString(3);
                        string phone = reader.GetString(4);
                        string address = reader.GetString(5);
                        string role = reader.GetString(6);

                        employeeDTO = new EmployeeDTO
                        {
                            Id = employeeid,
                            FirstName = firstname,
                            LastName = lastName,
                            Email = email,
                            Phone = phone,
                            Address = address,
                            Role = role
                        };
                    }
                }
            }
            return employeeDTO;
        }

        void IEmployeeRepositroty.Insert(EmployeeDTO dto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string Query = "INSERT INTO Employee VALUES (@FirstName,@LastName,@Email,@Phone,@Address,@Role)";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", dto.FirstName);
                    command.Parameters.AddWithValue("@LastName", dto.LastName);
                    command.Parameters.AddWithValue("@Email", dto.Email);
                    command.Parameters.AddWithValue("@Phone", dto.Phone);
                    command.Parameters.AddWithValue("@Address", dto.Address);
                    command.Parameters.AddWithValue("@Role", dto.Role);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        int IEmployeeRepositroty.nextID()
        {
            int newID = 1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string Query = "SELECT MAX(EmployeeID) FROM Employee";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            int id = reader.GetInt32(0);
                            newID = id + 1;
                        }
                    }
                }
            }
            return newID;
        }

        void IEmployeeRepositroty.Update(EmployeeDTO dto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string Query = "UPDATE Employee SET FirstName=@FirstName,LastName=@LastName,Email=@Email,Phone=@Phone,Address=@Address,Role=@Role WHERE EmployeeID=@EmployeeID";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", dto.Id);
                    command.Parameters.AddWithValue("@FirstName", dto.FirstName);
                    command.Parameters.AddWithValue("@LastName", dto.LastName);
                    command.Parameters.AddWithValue("@Email", dto.Email);
                    command.Parameters.AddWithValue("@Phone", dto.Phone);
                    command.Parameters.AddWithValue("@Address", dto.Address);
                    command.Parameters.AddWithValue("@Role", dto.Role);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
