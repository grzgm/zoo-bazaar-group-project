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
    public class TimeblockRepository : DapperBaseRepository, ITimeBlockRepository
    {
        void ITimeBlockRepository.Delete(int id)
        {
            string Query = "DELETE FROM Timeblock WHERE TimeblockID = @TimeblockID";
            Execute(Query, new { TimeblockID = id });
        }

        IEnumerable<TimeBlockDTO> ITimeBlockRepository.GetAll()
        {
            string selectQuery = "SELECT * FROM Timeblock";
            return Query<TimeBlockDTO>(selectQuery);
        }

        TimeBlockDTO ITimeBlockRepository.GetByTimeBlockId(int ID)
        {
            string selectQuery = "SELECT * FROM Timeblock WHERE TimeblockID = @ID";
            return QuerySingle<TimeBlockDTO>(selectQuery, new {ID = ID});
        }

        void ITimeBlockRepository.Insert(TimeBlockDTO dto)
        {
            string Query = "INSERT INTO Timeblock VALUES (@StartingTime,@EndingTime)";
            Execute(Query, new { StartingTime = dto.StartingTime, EndingTime = dto.EndingTime });
        }

        int ITimeBlockRepository.nextID()
        {
            string Query = "SELECT MAX(TimeblockID) FROM Timeblock";
            return QuerySingle<int>(Query);
        }

        void ITimeBlockRepository.Update(TimeBlockDTO dto)
        {
            string Query = "UPDATE Timeblock SET StartingTime=@StartingTime,EndingTime=@EndingTime WHERE TimeblockID=@TimeblockID";
            Execute(Query, new { TimeblockID = dto.TimeblockID, StartingTime = dto.StartingTime, EndingTime = dto.EndingTime });
        }
    }
}
