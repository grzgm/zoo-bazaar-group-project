using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_DomainModels.Models
{
    public class Schedule
    {
        private int _id;
        private DateOnly _date;
        private TimeBlock _timeBlock;
        private Employee _employee;
        private Task _task;

        public Schedule()
        {

        }

        public Schedule(int id, DateOnly date, TimeBlock timeBlock, Employee employee, Task task)
        {
            _id = id;
            _date = date;
            _timeBlock = timeBlock;
            _employee = employee;
            _task = task;
        }
        public Schedule(ScheduleDTO scheduleDTO, TimeBlockDTO timeBlockDTO, EmployeeDTO employeeDTO, TaskDTO taskDTO, HabitatDTO habitatDTO, ZoneDTO zoneDTO)
        {
            this._id = scheduleDTO.Id;
            this._date = new DateOnly(scheduleDTO.Year, scheduleDTO.Day, scheduleDTO.Day);
            this._timeBlock = new TimeBlock(timeBlockDTO);
            this._employee = new Employee(employeeDTO);
            this._task = new Task(taskDTO, habitatDTO, zoneDTO);
        }

        public int timeBlockId { get { return _timeBlock.ID; } }
        public string taskName { get { return _task.taskName; } }

    }
}
