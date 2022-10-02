using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_Repositories.Interfaces
{
    public interface IScheduleRepository
    {
        IEnumerable<ScheduleDTO> GetAll();
        HabitatDTO GetByHabitatId(int ID);
        void Insert(HabitatDTO dto);
        void Update(HabitatDTO dto);
        void Delete(HabitatDTO dto);
        int nextID();
    }
}
