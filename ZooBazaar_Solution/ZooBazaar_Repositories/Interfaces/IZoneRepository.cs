using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_Repositories.Interfaces
{
    public interface IZoneRepository
    {
        IEnumerable<ZoneDTO> GetAll();
        ZoneDTO GetByZoneId(int ID);
        void Insert(ZoneDTO dto);
        void Update(ZoneDTO dto);
        void Delete(ZoneDTO dto);
        int nextID();
    }
}
