using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_Repositories.Interfaces;

namespace ZooBazaar_ClassLibrary.Menagers
{
    public class TaskMenager
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IAnimalRepository _animalRepository;
        private readonly ITimeBlockRepository _timeBlockRepository;
        private readonly IHabitatRepository _habitatRepository;
        private readonly IZoneRepository _zoneRepository;

        public TaskMenager(ITaskRepository taskRepository, IAnimalRepository animalRepository, ITimeBlockRepository timeBlockRepository, IHabitatRepository habitatRepository, IZoneRepository zoneRepository)
        {
            _taskRepository = taskRepository;
            _animalRepository = animalRepository;
            _timeBlockRepository = timeBlockRepository;
            _habitatRepository = habitatRepository;
            _zoneRepository = zoneRepository;
        }
    }
}
