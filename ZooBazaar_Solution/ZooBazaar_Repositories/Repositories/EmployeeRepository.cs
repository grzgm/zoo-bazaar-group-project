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
    public class EmployeeRepository : BaseRepository,IEmployeeRepositroty
    {
        public EmployeeDTO GetEmployeeByLogin(string email, string password)
        {
            EmployeeDTO employeeDTO = new EmployeeDTO();
            string Query = "SELECT * FROM Employee WHERE (Email = @Email AND Password = @Password)";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int employeeid = reader.GetInt32(0);
                    string firstname = reader.GetString(1);
                    string lastname = reader.GetString(2);
                    string employeeemail = reader.GetString(3);
                    string phone = reader.GetString(4);
                    string address = reader.GetString(5);
                    string role = reader.GetString(6);

                    employeeDTO = (new EmployeeDTO
                    {
                        EmployeeID = employeeid,
                        FirstName = firstname,
                        LastName = lastname,
                        Email = email,
                        Phone = phone,
                        Address = address,
                        Role = role
                    });
                }
                return employeeDTO;
            }
        }

        void IEmployeeRepositroty.Delete(int id)
        {
            string Query = "DELETE FROM Employee WHERE EmployeeID = @EmployeeID";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@EmployeeID", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        List<EmployeeDTO> IEmployeeRepositroty.GetAllEmployees()
        {
            List<EmployeeDTO> employeeDTOs = new List<EmployeeDTO>();
            string Query = "SELECT * FROM Employee";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int employeeid = reader.GetInt32(0);
                    string firstname = reader.GetString(1);
                    string lastname = reader.GetString(2);
                    string email = reader.GetString(3);
                    string phone = reader.GetString(4);
                    string address = reader.GetString(5);
                    string role = reader.GetString(6);

                    employeeDTOs.Add(new EmployeeDTO
                    {
                        EmployeeID = employeeid,
                        FirstName = firstname,
                        LastName = lastname,
                        Email = email,
                        Phone = phone,
                        Address = address,
                        Role = role
                    });
                }
                return employeeDTOs;
            }
        }
        EmployeeDTO IEmployeeRepositroty.GetByEmployeeId(int ID)
        {
            EmployeeDTO employeeDTO = new EmployeeDTO();
            string Query = "SELECT * FROM Employee WHERE EmployeeID = @ID";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);

                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int employeeid = reader.GetInt32(0);
                    string firstname = reader.GetString(1);
                    string lastname = reader.GetString(2);
                    string email = reader.GetString(3);
                    string phone = reader.GetString(4);
                    string address = reader.GetString(5);
                    string role = reader.GetString(6);

                    employeeDTO = (new EmployeeDTO
                    {
                        EmployeeID = employeeid,
                        FirstName = firstname,
                        LastName = lastname,
                        Email = email,
                        Phone = phone,
                        Address = address,
                        Role = role
                    });
                }
                return employeeDTO;
            }
        }

        void IEmployeeRepositroty.Insert(EmployeeAddDTO dto)
        {
            string Query = "INSERT INTO Employee VALUES (@FirstName,@LastName,@Email,@Phone,@Address,@Role)";
            SqlConnection connection = GetConnection();
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

        int IEmployeeRepositroty.nextID()
        {
            int newID = 1;
            string Query = "SELECT MAX(EmployeeID) FROM Employee";
            SqlConnection connection = GetConnection();
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
            return newID;
        }

        void IEmployeeRepositroty.Update(EmployeeDTO dto)
        {
            string Query = "UPDATE Employee SET FirstName=@FirstName,LastName=@LastName,Email=@Email,Phone=@Phone,Address=@Address,Role=@Role WHERE EmployeeID=@EmployeeID";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@EmployeeID", dto.EmployeeID);
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
