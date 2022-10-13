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
        private readonly IEmployeeRepositroty _employeeRepositroty;
        private readonly ITimeBlockRepository _timeBlockRepository;
        private readonly IZoneRepository _zoneRepository;
        private readonly IHabitatRepository _habitatRepository;
        private readonly ITaskRepository _taskRepository;

        public ScheduleManager(IScheduleRepository scheduleRepository, IEmployeeRepositroty employeeRepositroty, ITimeBlockRepository timeBlockRepository, IZoneRepository zoneRepository, IHabitatRepository habitatRepository, ITaskRepository taskRepository)
        {
            this._scheduleRepository = scheduleRepository;
            this._employeeRepositroty = employeeRepositroty;
            this._timeBlockRepository = timeBlockRepository;
            this._zoneRepository = zoneRepository;
            this._habitatRepository = habitatRepository;
            this._taskRepository = taskRepository;
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
