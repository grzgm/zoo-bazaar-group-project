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
    public class HabitatRepository : DapperBaseRepository, IHabitatRepository
    {

        void IHabitatRepository.Delete(int id)
        {
            string Query = "DELETE FROM Habitat WHERE HabitatID = @HabitatID";
            Execute(Query, new { HabitatID = id });
        }

        IEnumerable<HabitatDTO> IHabitatRepository.GetAll()
        {
            string selectQuery = "SELECT H.*, Z.Name AS ZoneName, Z.Capacity AS ZoneCapacity FROM Habitat H JOIN Zone Z ON H.ZoneID = Z.ZoneID";
            return Query<HabitatDTO>(selectQuery);
        }

        HabitatDTO IHabitatRepository.GetByHabitatId(int ID)
        {
            string selectQuery = "SELECT H.*, Z.Name AS ZoneName, Z.Capacity AS ZoneCapacity FROM Habitat H JOIN Zone Z ON H.ZoneID = Z.ZoneID WHERE HabitatID = @ID";
            return QuerySingle<HabitatDTO>(selectQuery, new { ID = ID });
        }

        void IHabitatRepository.Insert(HabitatAddDTO dto)
        {
            string Query = "INSERT INTO Habitat VALUES (@Name,@Capacity,@ZoneID)";
            Execute(Query, new { Name = dto.Name, Capacity = dto.Capacity, ZoneID = dto.ZoneID });
        }

        int IHabitatRepository.nextID()
        {
            string Query = "SELECT MAX(HabitatID) FROM Habitat";
            return QuerySingle<int>(Query);
        }

        void IHabitatRepository.Update(HabitatDTO dto)
        {
            string Query = "UPDATE Habitat SET Name=@Name,Capacity=@Capacity,ZoneID=@ZoneID WHERE HabitatID=@HabitatID";
            Execute(Query, new {HabitatID = dto.HabitatID, Name = dto.Name, Capacity = dto.Capacity, ZoneID = dto.ZoneID });
        }
    }
}
