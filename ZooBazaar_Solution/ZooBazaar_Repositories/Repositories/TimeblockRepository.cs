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
    public class TimeblockRepository : ITimeBlockRepository
    {
        private string connectionString = "Server=mssqlstud.fhict.local;Database=dbi463992;User Id=dbi463992;Password=gogotpilon;";

        void ITimeBlockRepository.Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string Query = "DELETE FROM Timeblock WHERE TimeblockID = @TimeblockID";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@TimeblockID", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        IEnumerable<TimeBlockDTO> ITimeBlockRepository.GetAll()
        {
            List<TimeBlockDTO> timeblockDTOs = new List<TimeBlockDTO>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT * FROM Timeblock";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int timeblockid = reader.GetInt32(0);
                        TimeSpan startingtime = reader.GetTimeSpan(1);
                        TimeSpan endingtime = reader.GetTimeSpan(2);

                        timeblockDTOs.Add(new TimeBlockDTO
                        {
                            ID = timeblockid,
                            StartTime = startingtime,
                            EndTime = endingtime
                        });
                    }
                }
            }
            return timeblockDTOs;
        }

        TimeBlockDTO ITimeBlockRepository.GetByTimeBlockId(int ID)
        {
            TimeBlockDTO timeblockDTO = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT * FROM Timeblock WHERE TimeblockID = @ID";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int timeblockid = reader.GetInt32(0);
                        TimeSpan startingtime = reader.GetTimeSpan(1);
                        TimeSpan endingtime = reader.GetTimeSpan(2);

                        timeblockDTO = new TimeBlockDTO
                        {
                            ID = timeblockid,
                            StartTime = startingtime,
                            EndTime = endingtime
                        };
                    }
                }
            }
            return timeblockDTO;
        }

        void ITimeBlockRepository.Insert(TimeBlockDTO dto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string Query = "INSERT INTO Timeblock VALUES (@StartingTime,@EndingTime)";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@StartingTime", dto.StartTime);
                    command.Parameters.AddWithValue("@EndingTime", dto.EndTime);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        int ITimeBlockRepository.nextID()
        {
            int newID = 1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string Query = "SELECT MAX(TimeblockID) FROM Timeblock";

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

        void ITimeBlockRepository.Update(TimeBlockDTO dto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string Query = "UPDATE Timeblock SET StartingTime=@StartingTime,EndingTime=@EndingTime WHERE TimeblockID=@TimeblockID";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@TimeblockID", dto.ID);
                    command.Parameters.AddWithValue("@StartingTime", dto.StartTime);
                    command.Parameters.AddWithValue("@EndingTime", dto.EndTime);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
