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
        private IEnumerable<TimeBlockDTO> GetTimeblocks(string Query, List<SqlParameter>? sqlParameters)
        {
            List<TimeBlockDTO> timeblocks = new List<TimeBlockDTO>();
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
                        int timeblockid = reader.GetInt32(0);
                        TimeSpan startingtime = reader.GetTimeSpan(1);
                        TimeSpan endingtime = reader.GetTimeSpan(2);

                        timeblocks.Add(new TimeBlockDTO
                        {
                            TimeblockID = timeblockid,
                            StartingTime = startingtime,
                            EndingTime = endingtime
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

            return timeblocks;
        }

        void ITimeBlockRepository.Delete(int id)
        {
            string Query = "DELETE FROM Timeblock WHERE TimeblockID = @TimeblockID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@TimeblockID", id));
            Execute(Query, sqlParameters);
        }

        IEnumerable<TimeBlockDTO> ITimeBlockRepository.GetAll()
        {
            string Query = "SELECT * FROM Timeblock";
            return GetTimeblocks(Query, null);
        }

        TimeBlockDTO ITimeBlockRepository.GetByTimeBlockId(int ID)
        {
            string Query = "SELECT * FROM Timeblock WHERE TimeblockID = @ID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@ID", ID));
            return GetTimeblocks(Query, sqlParameters).First();
        }

        void ITimeBlockRepository.Insert(TimeBlockDTO dto)
        {
            string Query = "INSERT INTO Timeblock VALUES (@StartingTime,@EndingTime)";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@StartingTime", dto.StartingTime));
            sqlParameters.Add(new SqlParameter("@EndingTime", dto.EndingTime));
            Execute(Query, sqlParameters);
        }

        int ITimeBlockRepository.nextID()
        {
            string Query = "SELECT MAX(TimeblockID) FROM Timeblock";
            return ExecuteNextID(Query);
        }

        void ITimeBlockRepository.Update(TimeBlockDTO dto)
        {
            string Query = "UPDATE Timeblock SET StartingTime=@StartingTime,EndingTime=@EndingTime WHERE TimeblockID=@TimeblockID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@TimeblockID", dto.TimeblockID));
            sqlParameters.Add(new SqlParameter("@StartingTime", dto.StartingTime));
            sqlParameters.Add(new SqlParameter("@EndingTime", dto.EndingTime));
            Execute(Query, sqlParameters);
        }
    }
}
