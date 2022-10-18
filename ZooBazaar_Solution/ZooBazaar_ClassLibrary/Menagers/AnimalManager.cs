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
                animals.Add(new Animal(dto, dto.TimeBlockDTO, dto.HabitatDTO.ZoneDTO, dto.HabitatDTO));
            }
            return animals;
        }

        public Animal GetAnimal(int id)
        {
            AnimalDTO dto = _animalRepository.GetByAnimalId(id);
            return new Animal(dto, dto.TimeBlockDTO, dto.HabitatDTO.ZoneDTO, dto.HabitatDTO);
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
