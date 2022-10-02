using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_Repositories.Interfaces;

namespace ZooBazaar_ClassLibrary.Menagers
{
    public class ScheduleManager
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



    }
}
