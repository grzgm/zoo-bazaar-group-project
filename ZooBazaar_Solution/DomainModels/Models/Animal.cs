using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_DomainModels.Models
{
    public enum SPECIESTYPE
    {
        Mammals, 
        Fish, 
        Birds, 
        Reptiles, 
        Amphibians
    }
    public class Animal
    {
        private int _id;
        private string _name;
        private int _age;
        private DateOnly _dateOfBirth;
        private bool _sex;
        private string _species;
        private SPECIESTYPE _speciesType;
        private string _diet;
        private TimeBlock _timeBlock;
        private int _feedingInterval;
        private Zone _zone;
        private Habitat _habitat;

        public Animal(AnimalDTO animalDTO, TimeBlockDTO timeBlockDTO, ZoneDTO zoneDTO, HabitatDTO habitatDTO)
        {
            this._id = animalDTO.AnimalId;
            this._name = animalDTO.Name;
            this._age = animalDTO.Age;
            this._dateOfBirth = DateOnly.FromDateTime(animalDTO.DateOfBirth);
            this._sex = animalDTO.Sex;
            this._species = animalDTO.Species;
            this._speciesType = Enum.Parse<SPECIESTYPE>(animalDTO.SpeciesType, true);
            this._diet = animalDTO.Diet;
            this._timeBlock = new TimeBlock(timeBlockDTO);
            this._feedingInterval = animalDTO.FeedingInterval;
            this._zone = new Zone(zoneDTO);
            this._habitat = new Habitat(habitatDTO,zoneDTO);
        }
  
        public int ID { get { return _id; } }
        public string Name { get { return _name; } }

        public int Age { get { return _age; } }

        public DateOnly DateOnly { get { return _dateOfBirth; } }

        public bool Sex { get { return _sex; } }

        public string Species { get { return _species; } }  

        public SPECIESTYPE SpeciesType { get { return _speciesType; } }

        public string Diet { get { return _diet; } }

        public TimeBlock TimeBlock { get { return _timeBlock; } }

        public int FeedingInterval { get { return _feedingInterval; } } 

        public Zone Zone { get { return _zone; } }

        public Habitat Habitat { get { return _habitat; } }



    }
}
