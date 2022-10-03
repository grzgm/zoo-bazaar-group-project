using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_DomainModels.Models
{
    public class Task
    {
        private int _id;
        private string _name;
        private Animal? _animal;
        private Habitat _habitat;
        private Zone _zone;

        public Task(int id, string name, Animal animal, Habitat habitat, Zone zone)
        {
            _id = id;
            _name = name;
            _animal = animal;
            _habitat = habitat;
            _zone = zone;
        }
        public Task(TaskDTO TaskDTO, AnimalDTO animalDTO, TimeBlockDTO timeBlockOfAnimalDTO, HabitatDTO habitatDTO ,ZoneDTO zoneDTO)
        {
            this._id = TaskDTO.ID;
            this._name = TaskDTO.Name;
            this._animal = new Animal(animalDTO, timeBlockOfAnimalDTO, zoneDTO, habitatDTO);
            this._habitat = new Habitat(habitatDTO, zoneDTO);
            this._zone = new Zone(zoneDTO);
        }
        public Task(TaskDTO TaskDTO, HabitatDTO habitatDTO, ZoneDTO zoneDTO)
        {
            this._id = TaskDTO.ID;
            this._name = TaskDTO.Name;
            this._animal = null;
            this._habitat = new Habitat(habitatDTO, zoneDTO);
            this._zone = new Zone(zoneDTO);
        }



    }
}
