using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_DomainModels.Models
{
    public class StaticSchedule
    {
        private int _id;
        private DayOfWeek _dayOfTheWeek;
        private TimeBlock _timeBlock;
        private Task _task;

        public StaticSchedule()
        {

        }

        public StaticSchedule(int id, DayOfWeek dayOfTheWeek, TimeBlock timeBlock, Task task)
        {
            _id = id;
            _dayOfTheWeek = dayOfTheWeek;
            _timeBlock = timeBlock;
            _task = task;
        }
        public StaticSchedule(StaticScheduleDTO scheduleDTO)
        {
            this._id = scheduleDTO.ScheduleID;
            this._timeBlock = new TimeBlock(scheduleDTO.TimeBlockDTO);
            this._task = new Task(scheduleDTO.TaskDTO);
            this._dayOfTheWeek = (DayOfWeek)scheduleDTO.DayOfWeek;
        }

        public int timeBlockId { get { return _timeBlock.ID; } }
        public int Id { get { return _id; } }
        public string taskName { get { return _task.taskName; } }
        public string taskHabitat { get { return _task.habitat; } }
        public int TaskID { get { return _task.ID; } }
        public DayOfWeek dayOfTheWeek { get { return this._dayOfTheWeek; } }
    }
}
