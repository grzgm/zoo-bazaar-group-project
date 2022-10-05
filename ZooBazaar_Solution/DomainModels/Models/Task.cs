using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_DomainModels.Models
{

    public enum TASKNAME
    {
        Cleaning, 
        Feeding, 
        VetCheckup, 
        SpecialCare, 
        None
    }
    public class Task
    {
        private int _id;
        private TASKNAME _name;
        private Animal? _animal;
        private Habitat _habitat;
        private Zone _zone;

        public Task(int id, string name, Animal animal, Habitat habitat, Zone zone)
        {
            _id = id;
            _name = Enum.Parse<TASKNAME>(name, true);
            _animal = animal;
            _habitat = habitat;
            _zone = zone;
        }
        public Task(TaskDTO TaskDTO, AnimalDTO animalDTO, TimeBlockDTO timeBlockOfAnimalDTO, HabitatDTO habitatDTO ,ZoneDTO zoneDTO)
        {
            this._id = TaskDTO.ID;
            this._name = Enum.Parse<TASKNAME>(TaskDTO.Name, true);
            this._animal = new Animal(animalDTO, timeBlockOfAnimalDTO, zoneDTO, habitatDTO);
            this._habitat = new Habitat(habitatDTO, zoneDTO);
            this._zone = new Zone(zoneDTO);
        }
        public Task(TaskDTO TaskDTO, HabitatDTO habitatDTO, ZoneDTO zoneDTO)
        {
            this._id = TaskDTO.ID;
            this._name = Enum.Parse<TASKNAME>(TaskDTO.Name, true);
            this._animal = null;
            this._habitat = new Habitat(habitatDTO, zoneDTO);
            this._zone = new Zone(zoneDTO);
        }

        public string taskName { get { return _name.ToString(); } }

    }
}
