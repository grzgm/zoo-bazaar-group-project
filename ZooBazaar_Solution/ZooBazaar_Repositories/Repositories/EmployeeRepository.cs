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
                        string password = reader.GetString(7);
                        int unavailabilitydays = reader.GetInt32(8);

                        employees.Add(new EmployeeDTO
                        {
                            EmployeeID = employeeid,
                            FirstName = firstname,
                            LastName = lastname,
                            Email = employeeemail,
                            Phone = phone,
                            Address = address,
                            Role = role,
                            Password = password,
                            UnavailabilityDays = unavailabilitydays
                        });
                    }
                    connection.Close();
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

            try
            {
                sqlParameters.Add(new SqlParameter("@Email", email));
                sqlParameters.Add(new SqlParameter("@Password", password));
                return GetEmployees(Query, sqlParameters).First();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        void IEmployeeRepositroty.Delete(int id)
        {
            string Query = "DELETE FROM Employee WHERE EmployeeID = @EmployeeID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                sqlParameters.Add(new SqlParameter("@EmployeeID", id));
                Execute(Query, sqlParameters);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        List<EmployeeDTO> IEmployeeRepositroty.GetAllEmployees()
        {
            string Query = "SELECT * FROM Employee";
            try
            {
                return GetEmployees(Query, null).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        List<EmployeeDTO> IEmployeeRepositroty.GetEmployessAssignedToTaskTimeBlockDate(int day, int month, int year, int taskID, int timeBlockId)
        {
            string Query = "SELECT * FROM Employee";
            try
            {
                return GetEmployees(Query, null).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


        EmployeeDTO IEmployeeRepositroty.GetByEmployeeId(int ID)
        {
            string Query = "SELECT * FROM Employee WHERE EmployeeID = @ID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                sqlParameters.Add(new SqlParameter("@ID", ID));
                return GetEmployees(Query, sqlParameters).First();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        void IEmployeeRepositroty.Insert(EmployeeAddDTO dto)
        {
            string Query = "INSERT INTO Employee VALUES (@FirstName,@LastName,@Email,@Phone,@Address,@Role,@Password,@UnavailabilityDays)";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                sqlParameters.Add(new SqlParameter("@FirstName", dto.FirstName));
                sqlParameters.Add(new SqlParameter("@LastName", dto.LastName));
                sqlParameters.Add(new SqlParameter("@Email", dto.Email));
                sqlParameters.Add(new SqlParameter("@Phone", dto.Phone));
                sqlParameters.Add(new SqlParameter("@Address", dto.Address));
                sqlParameters.Add(new SqlParameter("@Role", dto.Role));
                sqlParameters.Add(new SqlParameter("@Password", dto.Password));
                sqlParameters.Add(new SqlParameter("@UnavailabilityDays", dto.UnavailabilityDays));
                Execute(Query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        int IEmployeeRepositroty.nextID()
        {
            string Query = "SELECT MAX(EmployeeID) FROM Employee";
            return ExecuteNextID(Query);
        }

        void IEmployeeRepositroty.Update(EmployeeDTO dto)
        {
            string Query = "UPDATE Employee SET FirstName=@FirstName,LastName=@LastName,Email=@Email,Phone=@Phone,Address=@Address,Role=@Role,Password=@Password,UnavailabilityDays=@UnavailabilityDays WHERE EmployeeID=@EmployeeID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                sqlParameters.Add(new SqlParameter("@EmployeeID", dto.EmployeeID));
                sqlParameters.Add(new SqlParameter("@FirstName", dto.FirstName));
                sqlParameters.Add(new SqlParameter("@LastName", dto.LastName));
                sqlParameters.Add(new SqlParameter("@Email", dto.Email));
                sqlParameters.Add(new SqlParameter("@Phone", dto.Phone));
                sqlParameters.Add(new SqlParameter("@Address", dto.Address));
                sqlParameters.Add(new SqlParameter("@Role", dto.Role));
                sqlParameters.Add(new SqlParameter("@Password", dto.Password));
                sqlParameters.Add(new SqlParameter("@UnavailabilityDays", dto.UnavailabilityDays));
                Execute(Query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
