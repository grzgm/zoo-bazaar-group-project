using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_DomainModels.Models
{
    public class Animal
    {
        private int _id;
        private string _name;
        private int _age;
        private DateTime _dateOfBirth;
        private bool _sex;
        private string _species;
        private string _speciesType;
        private string _diet;
        private TimeBlock _timeBlock;
        private int _feedingInterval;
        private Zone _zone;
        private Habitat _habitat;

        public Animal(AnimalDTO animalDTO, TimeBlockDTO timeBlockDTO, ZoneDTO zoneDTO, HabitatDTO habitatDTO)
        {
            this._id = animalDTO.Id;
            this._name = animalDTO.Name;
            this._age = animalDTO.Age;
            this._dateOfBirth = animalDTO.DateOfBirth;
            this._sex = animalDTO.Sex;
            this._species = animalDTO.Species;
            this._speciesType = animalDTO.SpeciesType;
            this._diet = animalDTO.Diet;
            this._timeBlock = new TimeBlock(timeBlockDTO);
            this._feedingInterval = animalDTO.FeedingInterval;
            this._zone = new Zone(zoneDTO);
            this._habitat = new Habitat(habitatDTO);
        }
  




    }
}
