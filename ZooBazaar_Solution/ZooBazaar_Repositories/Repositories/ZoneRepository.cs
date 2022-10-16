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
    public class ZoneRepository : DapperBaseRepository, IZoneRepository
    {
        void IZoneRepository.Delete(int id)
        {
            string Query = "DELETE FROM Zone WHERE ZoneID = @ZoneID";
            Execute(Query, new { ZoneID = id });
        }

        IEnumerable<ZoneDTO> IZoneRepository.GetAll()
        {
            string selectQuery = "SELECT * FROM Zone";
            return Query<ZoneDTO>(selectQuery);
        }

        ZoneDTO IZoneRepository.GetByZoneId(int ID)
        {
            string selectQuery = "SELECT * FROM Zone WHERE ZoneID = @ID";
            return QuerySingle<ZoneDTO>(selectQuery, new {ID = ID});
        }

        void IZoneRepository.Insert(ZoneAddDTO dto)
        {
            string Query = "INSERT INTO Zone VALUES (@Name,@Capacity)";
            Execute(Query, new { Name = dto.Name, Capacity = dto.Capacity });
        }

        int IZoneRepository.nextID()
        {
            string Query = "SELECT MAX(ZoneID) FROM Zone";
            return QuerySingle<int>(Query);
        }

        void IZoneRepository.Update(ZoneDTO dto)
        {
            string Query = "UPDATE Zone SET Name=@Name,Capacity=@Capacity WHERE ZoneID=@ZoneID";
            Execute(Query, new { ZoneID = dto.ZoneID, Name = dto.Name, Capacity = dto.Capacity });
        }
    }
}
