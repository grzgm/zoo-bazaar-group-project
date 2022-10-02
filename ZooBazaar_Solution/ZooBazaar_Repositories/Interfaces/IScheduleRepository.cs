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
        ScheduleDTO GetByScheduleId(int ID);
        void Insert(ScheduleDTO dto);
        void Update(ScheduleDTO dto);
        void Delete(int id);
        int nextID();
    }
}
