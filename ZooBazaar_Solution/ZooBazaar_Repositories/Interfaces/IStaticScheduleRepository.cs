using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_Repositories.Interfaces
{
    public interface IStaticScheduleRepository
    {
        void AddSchedule(StaticScheduleAddDTO staticScheduleAddDTO);
        void RemoveSchedule(int scheduleid);
        List<StaticScheduleDTO> GetScheduleFromDay(int day);
    }
}
