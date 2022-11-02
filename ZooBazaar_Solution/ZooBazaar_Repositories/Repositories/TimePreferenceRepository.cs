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
        void ITimePreferenceRepository.Delete(int id)
        {
            string Query = "DELETE FROM Timepreference WHERE EmployeeID = @ID";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@ID", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        IEnumerable<TimePreferenceDTO> ITimePreferenceRepository.GetAll()
        {
            List<TimePreferenceDTO> timepreferenceDTOs = new List<TimePreferenceDTO>();
            string selectQuery = "SELECT E.*, TB.* FROM Timepreference T JOIN Employee E ON T.EmployeeID = E.EmployeeID JOIN Timeblock TB ON T.TimeblockID = TB.TimeblockID";
            SqlConnection connection = GetConnection();
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
                    string phone = reader.GetString(4);
                    string address = reader.GetString(5);
                    string role = reader.GetString(6);

                    int timeblockid = reader.GetInt32(8);
                    TimeSpan startingtime = reader.GetTimeSpan(9);
                    TimeSpan endingtime = reader.GetTimeSpan(10);

                    timepreferenceDTOs.Add(new TimePreferenceDTO
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
            }
            return timepreferenceDTOs;
        }

        IEnumerable<TimePreferenceDTO> ITimePreferenceRepository.GetByEmployeeId(int ID)
        {
            List<TimePreferenceDTO> timepreferenceDTOs = new List<TimePreferenceDTO>();
            string selectQuery = "SELECT E.*, TB.* FROM Timepreference T JOIN Employee E ON T.EmployeeID = E.EmployeeID JOIN Timeblock TB ON T.TimeblockID = TB.TimeblockID WHERE EmployeeID = @ID";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(selectQuery, connection))
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

                    int timeblockid = reader.GetInt32(8);
                    TimeSpan startingtime = reader.GetTimeSpan(9);
                    TimeSpan endingtime = reader.GetTimeSpan(10);

                    timepreferenceDTOs.Add(new TimePreferenceDTO
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
            }
            return timepreferenceDTOs;
        }

        void ITimePreferenceRepository.Insert(TimePreferenceDTO dto)
        {
            string Query = "INSERT INTO Timepreference VALUES (@EmployeeID,@TimeblockID)";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@EmployeeID", dto.EmployeeDTO.EmployeeID);
                command.Parameters.AddWithValue("@TimeblockID", dto.TimeBlockDTO.TimeblockID);
                connection.Open();
                command.ExecuteNonQuery();
            }

        }
    }
}
