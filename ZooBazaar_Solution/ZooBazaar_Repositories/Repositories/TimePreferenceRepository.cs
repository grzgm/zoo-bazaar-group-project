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
    public class TimePreferenceRepository : ITimePreferenceRepository
    {
        private string connectionString = "Server=mssqlstud.fhict.local;Database=dbi463992;User Id=dbi463992;Password=gogotpilon;";

        void ITimePreferenceRepository.Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string Query = "DELETE FROM Timepreference WHERE EmployeeID = @ID";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        IEnumerable<TimePreferenceDTO> ITimePreferenceRepository.GetAll()
        {
            List<TimePreferenceDTO> timepreferenceDTOs = new List<TimePreferenceDTO>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT * FROM Timepreference";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int employeeid = reader.GetInt32(1);
                        int timeblockid = reader.GetInt32(2);

                        timepreferenceDTOs.Add(new TimePreferenceDTO
                        {
                            employeeID = employeeid,
                            TimeblockID = timeblockid
                        });
                    }
                }
            }
            return timepreferenceDTOs;
        }

        IEnumerable<TimePreferenceDTO> ITimePreferenceRepository.GetByEmployeeId(int ID)
        {
            List<TimePreferenceDTO> timepreferenceDTOs = new List<TimePreferenceDTO>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT * FROM Timepreference WHERE EmployeeID = @id";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int employeeid = reader.GetInt32(1);
                        int timeblockid = reader.GetInt32(2);

                        timepreferenceDTOs.Add(new TimePreferenceDTO
                        {
                            employeeID = employeeid,
                            TimeblockID = timeblockid
                        });
                    }
                }
            }
            return timepreferenceDTOs;
        }

        void ITimePreferenceRepository.Insert(TimePreferenceDTO dto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string Query = "INSERT INTO Timepreference VALUES (@EmployeeID,@TimeblockID)";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", dto.employeeID);
                    command.Parameters.AddWithValue("@TimeblockID", dto.TimeblockID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
