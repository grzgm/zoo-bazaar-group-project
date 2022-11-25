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
                animals.Add(new Animal(dto));
            }
            return animals;
        }

        public Animal GetAnimal(int id)
        {
            AnimalDTO dto = _animalRepository.GetByAnimalId(id);
            return new Animal(dto);
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
        public void AddSpecialCare(int id, string specialCare)
        {
            _animalRepository.AddSpecialCare(id, specialCare);
        }

        public AnimalDTO FromAnimalToAnimalDTO(Animal animal)
        {
            AnimalDTO animalDTO = new AnimalDTO
            {
                AnimalId = animal.ID,
                Name = animal.Name,
                Age = animal.Age,
                DateOfBirth = animal.DateOnly.ToDateTime(TimeOnly.MinValue),
                Sex = animal.Sex,
                Diet = animal.Diet,
                FeedingInterval = animal.FeedingInterval,
                Species = animal.Species,
                SpeciesType = animal.SpeciesType,
                TimeBlockDTO = new TimeBlockDTO
                {
                    TimeblockID = animal.TimeBlock.ID,
                    EndingTime = animal.TimeBlock.EndTime.ToTimeSpan(),
                    StartingTime = animal.TimeBlock.StartTime.ToTimeSpan()

                },
                HabitatDTO = new HabitatDTO
                {
                    HabitatID = animal.Habitat.ID,
                    Name = animal.Habitat.Name,
                    Capacity = animal.Habitat.Capacity,
                    ZoneDTO = new ZoneDTO
                    {
                        ZoneID = animal.Zone.ID,
                        Capacity = animal.Zone.Capacity,
                        Name = animal.Zone.Name
                    }
                    
                },
            };
            return animalDTO;
        }

        public AnimalDTO GetAnimalDTO(int id)
        {
            return _animalRepository.GetByAnimalId(id);
          
        }
    }
}
