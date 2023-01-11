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

        public List<StaticSchedule> GetScheduleFromDay(int day)
        {
            List<StaticSchedule> schedules = new List<StaticSchedule>();
            foreach(StaticScheduleDTO staticScheduleDTO in staticScheduleRepository.GetScheduleFromDay(day))
            {
                schedules.Add(new StaticSchedule(staticScheduleDTO));
            }
            return schedules;
        }

        public void RemoveSchedule(int scheduleid)
        {
            staticScheduleRepository.RemoveSchedule(scheduleid);
        }
    }
}
