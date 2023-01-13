using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_DTO.DTOs;
using ZooBazaar_Repositories.Interfaces;
using ZooBazaar_DomainModels.Models;
using System.Diagnostics;


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

        public int AmountOfEmployessAssignedToTaskTimeBlockDate(int day, int month, int year, int taskID, int timeBlockId)
		{
			return _scheduleRepository.AmountOfEmployessAssignedToTaskTimeBlockDate(day, month, year, taskID, timeBlockId);
		}

        public bool DoesEmplyeeIsAssignedToTaskTimeBlockDate(int day, int month, int year, int taskID, int timeBlockId, int employeeID)
        {
            return _scheduleRepository.DoesEmplyeeIsAssignedToTaskTimeBlockDate(day, month, year, taskID, timeBlockId, employeeID);
        }

        public void DeleteByTaskTimeBlockEmployeeDate(int day, int month, int year, int taskID, int timeBlockId, int employeeID)
        {
            _scheduleRepository.DeleteByTaskTimeBlockEmployeeDate( day,  month,  year,  taskID,  timeBlockId,  employeeID);
        }

    }
}
