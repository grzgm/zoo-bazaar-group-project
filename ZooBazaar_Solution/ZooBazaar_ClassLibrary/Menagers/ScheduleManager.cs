using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_DTO.DTOs;
using ZooBazaar_Repositories.Interfaces;
using ZooBazaar_DomainModels.Models;

namespace ZooBazaar_ClassLibrary.Menagers
{
    public class ScheduleManager : IScheduleManager
    {
        private readonly IScheduleRepository _scheduleRepository;


        public ScheduleManager(IScheduleRepository scheduleRepository)
        {
            this._scheduleRepository = scheduleRepository;

        }

        public Schedule GetDayScheduleEmployee(DateOnly date, int employeeId)
        {
            ScheduleDTO dto = _scheduleRepository.GetByDateAndEmployeeId(date, employeeId);
            if(dto != null)
            {
                TaskDTO taskDTO = _taskRepository.GetByTaskId(dto.TaskID);
                return new Schedule(dto, _timeBlockRepository.GetByTimeBlockId(dto.TimeblockID), _employeeRepositroty.GetByEmployeeId(employeeId), taskDTO, _habitatRepository.GetByHabitatId(taskDTO.HabitatID), _zoneRepository.GetByZoneId(taskDTO.ZoneID));
            }
            return null;
        }
    }
}
