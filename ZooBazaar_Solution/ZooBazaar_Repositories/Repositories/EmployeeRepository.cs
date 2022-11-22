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
        private IEnumerable<EmployeeDTO> GetEmployees(string Query, List<SqlParameter>? sqlParameters)
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            try
            {
                SqlConnection connection = GetConnection();
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    connection.Open();
                    if (sqlParameters != null)
                    {
                        command.Parameters.AddRange(sqlParameters.ToArray());
                    }
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

                        employees.Add(new EmployeeDTO
                        {
                            EmployeeID = employeeid,
                            FirstName = firstname,
                            LastName = lastname,
                            Email = employeeemail,
                            Phone = phone,
                            Address = address,
                            Role = role
                        });
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return employees;
        }


        public EmployeeDTO GetEmployeeByLogin(string email, string password)
        {
            string Query = "SELECT * FROM Employee WHERE (Email = @Email AND Password = @Password)";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@Email", email));
            sqlParameters.Add(new SqlParameter("@Password", password));
            return GetEmployees(Query, sqlParameters).First();
        }

        void IEmployeeRepositroty.Delete(int id)
        {
            string Query = "DELETE FROM Employee WHERE EmployeeID = @EmployeeID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@EmployeeID", id));
            Execute(Query, sqlParameters);
        }

        List<EmployeeDTO> IEmployeeRepositroty.GetAllEmployees()
        {
            string Query = "SELECT * FROM Employee";
            return GetEmployees(Query, null).ToList();
        }
        EmployeeDTO IEmployeeRepositroty.GetByEmployeeId(int ID)
        {
            string Query = "SELECT * FROM Employee WHERE EmployeeID = @ID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@ID", ID));
            return GetEmployees(Query, sqlParameters).First();
        }

        void IEmployeeRepositroty.Insert(EmployeeAddDTO dto)
        {
            string Query = "INSERT INTO Employee VALUES (@FirstName,@LastName,@Email,@Phone,@Address,@Role)";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@FirstName", dto.FirstName));
            sqlParameters.Add(new SqlParameter("@LastName", dto.LastName));
            sqlParameters.Add(new SqlParameter("@Email", dto.Email));
            sqlParameters.Add(new SqlParameter("@Phone", dto.Phone));
            sqlParameters.Add(new SqlParameter("@Address", dto.Address));
            sqlParameters.Add(new SqlParameter("@Role", dto.Role));
            Execute(Query, sqlParameters);
        }

        int IEmployeeRepositroty.nextID()
        {
            string Query = "SELECT MAX(EmployeeID) FROM Employee";
            return ExecuteNextID(Query);
        }

        void IEmployeeRepositroty.Update(EmployeeDTO dto)
        {
            string Query = "UPDATE Employee SET FirstName=@FirstName,LastName=@LastName,Email=@Email,Phone=@Phone,Address=@Address,Role=@Role WHERE EmployeeID=@EmployeeID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@EmployeeID", dto.EmployeeID));
            sqlParameters.Add(new SqlParameter("@FirstName", dto.FirstName));
            sqlParameters.Add(new SqlParameter("@LastName", dto.LastName));
            sqlParameters.Add(new SqlParameter("@Email", dto.Email));
            sqlParameters.Add(new SqlParameter("@Phone", dto.Phone));
            sqlParameters.Add(new SqlParameter("@Address", dto.Address));
            sqlParameters.Add(new SqlParameter("@Role", dto.Role));
            Execute(Query, sqlParameters);
        }
    }
}
