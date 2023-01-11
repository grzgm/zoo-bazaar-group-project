using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;
using ZooBazaar_Repositories.Interfaces;

namespace ZooBazaar_Repositories.Repositories
{
    public class TimePreferenceRepository : BaseRepository, ITimePreferenceRepository
    {
        private IEnumerable<TimePreferenceDTO> GetTimepreferences(string Query, List<SqlParameter>? sqlParameters)
        {
            List<TimePreferenceDTO> timepreferences = new List<TimePreferenceDTO>();
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
                        string email = reader.GetString(3);
                        string phone = reader.GetString(4);
                        string address = reader.GetString(5);
                        string role = reader.GetString(6);

                        int timeblockid = reader.GetInt32(8);
                        TimeSpan startingtime = reader.GetTimeSpan(9);
                        TimeSpan endingtime = reader.GetTimeSpan(10);

                        timepreferences.Add(new TimePreferenceDTO
                        {
                            EmployeeDTO = new EmployeeDTO
                            {
                                EmployeeID = employeeid,
                                FirstName = firstname,
                                LastName = lastname,
                                Email = email,
                                Phone = phone,
                                Address = address,
                                Role = role
                            },
                            TimeBlockDTO = new TimeBlockDTO
                            {
                                TimeblockID = timeblockid,
                                StartingTime = startingtime,
                                EndingTime = endingtime
                            }
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

            return timepreferences;
        }
        void ITimePreferenceRepository.Delete(int id)
        {
            string Query = "DELETE FROM Timepreference WHERE EmployeeID = @ID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                sqlParameters.Add(new SqlParameter("@ID", id));
                Execute(Query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        IEnumerable<TimePreferenceDTO> ITimePreferenceRepository.GetAll()
        {
            string Query = "SELECT E.*, TB.* FROM Timepreference T JOIN Employee E ON T.EmployeeID = E.EmployeeID JOIN Timeblock TB ON T.TimeblockID = TB.TimeblockID";
            return GetTimepreferences(Query, null);
        }

        IEnumerable<TimePreferenceDTO> ITimePreferenceRepository.GetByEmployeeId(int ID)
        {
            string Query = "SELECT E.*, TB.* FROM Timepreference T JOIN Employee E ON T.EmployeeID = E.EmployeeID JOIN Timeblock TB ON T.TimeblockID = TB.TimeblockID WHERE EmployeeID = @ID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                sqlParameters.Add(new SqlParameter("@ID", ID));
                return GetTimepreferences(Query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        void ITimePreferenceRepository.Insert(TimePreferenceDTO dto)
        {
            string Query = "INSERT INTO Timepreference VALUES (@EmployeeID,@TimeblockID)";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                sqlParameters.Add(new SqlParameter("@EmployeeID", dto.EmployeeDTO.EmployeeID));
                sqlParameters.Add(new SqlParameter("@TimeblockID", dto.TimeBlockDTO.TimeblockID));
                Execute(Query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
