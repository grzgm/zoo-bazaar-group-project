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
    public class TimeblockRepository : BaseRepository, ITimeBlockRepository
    {
        void ITimeBlockRepository.Delete(int id)
        {
            string Query = "DELETE FROM Timeblock WHERE TimeblockID = @TimeblockID";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@TimeblockID", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        IEnumerable<TimeBlockDTO> ITimeBlockRepository.GetAll()
        {
            List<TimeBlockDTO> timeblockDTOs = new List<TimeBlockDTO>();
            string selectQuery = "SELECT * FROM Timeblock";
            SqlConnection connection = GetConnection();
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
                        TimeblockID = timeblockid,
                        StartingTime = startingtime,
                        EndingTime = endingtime
                    });
                }
            }
            return timeblockDTOs;
        }

        TimeBlockDTO ITimeBlockRepository.GetByTimeBlockId(int ID)
        {
            TimeBlockDTO timeblockDTO = new TimeBlockDTO();
            string selectQuery = "SELECT * FROM Timeblock WHERE TimeblockID = @ID";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(selectQuery, connection))
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int timeblockid = reader.GetInt32(0);
                    TimeSpan startingtime = reader.GetTimeSpan(1);
                    TimeSpan endingtime = reader.GetTimeSpan(2);

                    timeblockDTO = (new TimeBlockDTO
                    {
                        TimeblockID = timeblockid,
                        StartingTime = startingtime,
                        EndingTime = endingtime
                    });
                }
            }
            return timeblockDTO;
        }

        void ITimeBlockRepository.Insert(TimeBlockDTO dto)
        {
            string Query = "INSERT INTO Timeblock VALUES (@StartingTime,@EndingTime)";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@StartingTime", dto.StartingTime);
                command.Parameters.AddWithValue("@EndingTime", dto.EndingTime);
                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        int ITimeBlockRepository.nextID()
        {
            int newID = 1;
            string Query = "SELECT MAX(TimeblockID) FROM Timeblock";
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

        void ITimeBlockRepository.Update(TimeBlockDTO dto)
        {
            string Query = "UPDATE Timeblock SET StartingTime=@StartingTime,EndingTime=@EndingTime WHERE TimeblockID=@TimeblockID";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@TimeblockID", dto.TimeblockID);
                command.Parameters.AddWithValue("@StartingTime", dto.StartingTime);
                command.Parameters.AddWithValue("@EndingTime", dto.EndingTime);

                connection.Open();
                command.ExecuteNonQuery();
            }

        }
    }
}
