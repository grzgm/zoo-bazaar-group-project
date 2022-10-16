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
    public class TimePreferenceRepository : DapperBaseRepository, ITimePreferenceRepository
    {
        void ITimePreferenceRepository.Delete(int id)
        {
            string Query = "DELETE FROM Timepreference WHERE EmployeeID = @ID";
            Execute(Query, new { EmployeeID = id });
        }

        IEnumerable<TimePreferenceDTO> ITimePreferenceRepository.GetAll()
        {
            string selectQuery = "SELECT E.*, TB.* FROM Timepreference T JOIN Employee E ON T.EmployeeID = E.EmployeeID JOIN Timeblock TB ON T.TimeblockID = TB.TimeblockID";
            return Query<TimePreferenceDTO>(selectQuery);
        }

        IEnumerable<TimePreferenceDTO> ITimePreferenceRepository.GetByEmployeeId(int ID)
        {
            string selectQuery = "SELECT E.*, TB.* FROM Timepreference T JOIN Employee E ON T.EmployeeID = E.EmployeeID JOIN Timeblock TB ON T.TimeblockID = TB.TimeblockID WHERE EmployeeID = @ID";
            return Query<TimePreferenceDTO>(selectQuery, new {ID = ID});
        }

        void ITimePreferenceRepository.Insert(TimePreferenceDTO dto)
        {
            string Query = "INSERT INTO Timepreference VALUES (@EmployeeID,@TimeblockID)";
            Execute(Query, new { EmployeeID = dto.EmployeeID, TimeblockID = dto.TimeblockID });
        }
    }
}
