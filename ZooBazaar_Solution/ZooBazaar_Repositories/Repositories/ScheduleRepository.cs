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
    public class ScheduleRepository : DapperBaseRepository, IScheduleRepository
    {
        void IScheduleRepository.Delete(int id)
        {
            string Query = "DELETE FROM Schedule WHERE ScheduleID = @ScheduleID";
            Execute(Query, new { ScheduleID = id });
        }

        IEnumerable<ScheduleDTO> IScheduleRepository.GetAll()
        {
            string selectQuery = "SELECT *, T.ZoneID AS TaskZoneID, T.HabitatID AS TaskHabitatID FROM Schedule S JOIN Timeblock TB ON S.TimeblockID = TB.TimeblockID JOIN Employee E ON S.EmployeeID = E.EmployeeID JOIN Task T ON S.TaskID = T.TaskID LEFT JOIN Animal A ON T.AnimalID = A.AnimalID JOIN Zone Z ON T.ZoneID = Z.ZoneID JOIN Habitat H ON T.HabitatID = H.HabitatID";
            return Query<ScheduleDTO>(selectQuery);
        }

        ScheduleDTO IScheduleRepository.GetByScheduleId(int ID)
        {
            string selectQuery = "SELECT *, T.ZoneID AS TaskZoneID, T.HabitatID AS TaskHabitatID FROM Schedule S JOIN Timeblock TB ON S.TimeblockID = TB.TimeblockID JOIN Employee E ON S.EmployeeID = E.EmployeeID JOIN Task T ON S.TaskID = T.TaskID LEFT JOIN Animal A ON T.AnimalID = A.AnimalID JOIN Zone Z ON T.ZoneID = Z.ZoneID JOIN Habitat H ON T.HabitatID = H.HabitatID WHERE ScheduleID = @ID";
            return QuerySingle<ScheduleDTO>(selectQuery, new { ID = ID});
        }

        void IScheduleRepository.Insert(ScheduleDTO dto)
        {
            string Query = "INSERT INTO Schedule VALUES (@Day,@Month,@Year,@TimeblockID,@EmployeeID,@TaskID)";
            Execute(Query, new { Day = dto.Day, Month = dto.Month, Year = dto.Year, TimeblockID = dto.TimeblockID, EmployeeID = dto.EmployeeID, TaskID = dto.TaskID });
        }

        int IScheduleRepository.nextID()
        {
            string Query = "SELECT MAX(ScheduleID) FROM Schedule";
            return QuerySingle<int>(Query);
        }

        void IScheduleRepository.Update(ScheduleDTO dto)
        {
            string Query = "UPDATE Schedule SET Day=@Day,Month=@Month,Year=@Year,TimeblockID=@TimeblockID,EmployeeID=@EmployeeID,TaskID=@TaskID WHERE ScheduleID = @ScheduleID";
            Execute(Query, new { ScheduleID = dto.ScheduleID, Day = dto.Day, Month = dto.Month, Year = dto.Year, TimeblockID = dto.TimeblockID, EmployeeID = dto.EmployeeID, TaskID = dto.TaskID });
        }
    }
}
