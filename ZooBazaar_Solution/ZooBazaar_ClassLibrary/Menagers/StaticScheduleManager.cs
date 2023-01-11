using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_DTO.DTOs;
using ZooBazaar_Repositories.Interfaces;

namespace ZooBazaar_ClassLibrary.Menagers
{
    public class StaticScheduleManager : IStaticScheduleManager
    {
        private readonly IStaticScheduleRepository staticScheduleRepository;

        public StaticScheduleManager(IStaticScheduleRepository staticScheduleRepository)
        {
            this.staticScheduleRepository = staticScheduleRepository;
        }

        public void AddSchedule(StaticScheduleAddDTO staticScheduleAddDTO)
        {
            staticScheduleRepository.AddSchedule(staticScheduleAddDTO);
        }

        public StaticSchedule GetScheduleFromDayAndTimeblockID(int day, int timeblockID)
        {
            return new StaticSchedule(staticScheduleRepository.GetScheduleFromDayAndTimeblockID(day, timeblockID));
        }

        public void RemoveSchedule(int scheduleid)
        {
            staticScheduleRepository.RemoveSchedule(scheduleid);
        }
    }
}
