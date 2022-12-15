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
        private readonly ITaskRepository _taskRepository;

        public ScheduleManager(IScheduleRepository scheduleRepository, ITaskRepository taskRepository)
        {
            this._scheduleRepository = scheduleRepository;
            this._taskRepository = taskRepository;
        }

        public Schedule GetDayScheduleEmployee(DateOnly date, int employeeId)
        {
            ScheduleDTO dto = _scheduleRepository.GetByDateAndEmployeeId(date, employeeId);
            if(dto != null)
            {
                TaskDTO taskDTO = dto.TaskDTO;
                return new Schedule(dto);
            }
            return null;
        }

        public List<Schedule> GetDay(DateOnly date)
        {
            List<Schedule> schedules = new List<Schedule>();
            foreach(ScheduleDTO dto in _scheduleRepository.GetByDate(date)){
                schedules.Add(new Schedule(dto));
            }
            return schedules;
        }

        public List<Schedule> GetDayScheduleEmployeeAllSchdules(DateOnly date, int employeeId)
        {
            List<Schedule> schedules = new List<Schedule>();

            foreach(ScheduleDTO dto in _scheduleRepository.GetByDateAndEmployeeIdAllSchdules(date, employeeId))
            {
                schedules.Add(new Schedule(dto));
            }
            return schedules;
        }

        public void Insert(ScheduleAddDTO dto)
        {
            _scheduleRepository.Insert(dto);
        }

        public void Update(ScheduleDTO dto)
        {
            _scheduleRepository.Update(dto);
        }

        public void Delete(int id)
        {
            _scheduleRepository.Delete(id);
        }
    }
}
