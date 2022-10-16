using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_DTO.DTOs;
using ZooBazaar_Repositories.Interfaces;

namespace ZooBazaar_ClassLibrary.Menagers
{
    public class AnimalManager : IAnimalMenager
    {
        private readonly IAnimalRepository _animalRepository;
        public AnimalManager(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public List<Animal> GetAll()
        {
            List<Animal> animals = new List<Animal>();
           
           foreach(AnimalDTO dto in _animalRepository.GetAll())
            {
                TimeBlockDTO timeBlockDTO = new TimeBlockDTO
                {
                    TimeblockID = dto.FeedingTimeID,
                    StartingTime = dto.StartTime,
                    EndingTime = dto.EndTime
                };

                ZoneDTO zoneDTO = new ZoneDTO
                {
                    ZoneID = dto.ZoneID,
                    Name = dto.ZoneName,
                    Capacity = dto.ZoneCapacity
                };

                HabitatDTO habitatDTO = new HabitatDTO
                {
                    HabitatID = dto.HabitatID,
                    Name = dto.Name,
                    Capacity = dto.HabitatCapacity,
                    ZoneID = dto.ZoneID
                };
                animals.Add(new Animal(dto, timeBlockDTO, zoneDTO, habitatDTO));
            }
            return animals;
        }

        public Animal GetAnimal(int id)
        {
            AnimalDTO dto = _animalRepository.GetByAnimalId(id);
            TimeBlockDTO timeBlockDTO = new TimeBlockDTO
            {
                TimeblockID = dto.FeedingTimeID,
                StartingTime = dto.StartTime,
                EndingTime = dto.EndTime
            };

            ZoneDTO zoneDTO = new ZoneDTO
            {
                ZoneID = dto.ZoneID,
                Name = dto.ZoneName,
                Capacity = dto.ZoneCapacity
            };

            HabitatDTO habitatDTO = new HabitatDTO
            {
                HabitatID = dto.HabitatID,
                Name = dto.Name,
                Capacity = dto.HabitatCapacity,
                ZoneID = dto.ZoneID
            };
            return new Animal(dto, timeBlockDTO, zoneDTO, habitatDTO);
        }

        public void NewAnimal(AnimalAddDTO animalAddDTO)
        {
            _animalRepository.Insert(animalAddDTO);
        }

        public void RemoveAnimal(int id)
        {
            _animalRepository.Delete(id);
        }

        public void UpdateAnimal(AnimalDTO animalDTO)
        {
           _animalRepository.Update(animalDTO);
        }
    }
}
