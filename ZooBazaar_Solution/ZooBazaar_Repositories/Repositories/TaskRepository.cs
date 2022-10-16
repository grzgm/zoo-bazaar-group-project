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
    public class TaskRepository : DapperBaseRepository, ITaskRepository
    {
        void ITaskRepository.Delete(int id)
        {
            string Query = "DELETE FROM Task WHERE TaskID = @TaskID";
            Execute(Query, new { TaskID = id });
        }

        IEnumerable<TaskDTO> ITaskRepository.GetAll()
        {
            string selectQuery = "SELECT *, T.ZoneID AS TaskZoneID, T.HabitatID AS TaskHabitatID FROM Task T LEFT JOIN Animal A ON T.AnimalID = A.AnimalID JOIN Zone Z ON T.ZoneID = Z.ZoneID JOIN Habitat H ON T.HabitatID = H.HabitatID";
            return Query<TaskDTO>(selectQuery);
        }

        TaskDTO ITaskRepository.GetByTaskId(int ID)
        {
            string selectQuery = "SELECT *, T.ZoneID AS TaskZoneID, T.HabitatID AS TaskHabitatID FROM Task T LEFT JOIN Animal A ON T.AnimalID = A.AnimalID JOIN Zone Z ON T.ZoneID = Z.ZoneID JOIN Habitat H ON T.HabitatID = H.HabitatID WHERE TaskID = @ID";
            return QuerySingle<TaskDTO>(selectQuery, new {ID = ID});
        }

        void ITaskRepository.Insert(TaskDTO dto)
        {
            string Query = "INSERT INTO Task VALUES (@Name,@AnimalID,@HabitatID,@ZoneID)";
            Execute(Query, new { Name = dto.Name, AnimalID = dto.AnimalID, HabitatID = dto.TaskHabitatID, ZoneID = dto.TaskZoneID });
        }

        int ITaskRepository.nextID()
        {
            string Query = "SELECT MAX(TaskID) FROM Task";
            return QuerySingle<int>(Query);
        }

        void ITaskRepository.Update(TaskDTO dto)
        {
            string Query = "UPDATE Task SET Name=@Name,AnimalID=@AnimalID,HabitatID=@HabitatID,ZoneID=@ZoneID WHERE TaskID=@TaskID";
            Execute(Query, new { TaskID = dto.TaskID, Name = dto.Name, AnimalID = dto.AnimalID, HabitatID = dto.TaskHabitatID, ZoneID = dto.TaskZoneID });
        }
    }
}
