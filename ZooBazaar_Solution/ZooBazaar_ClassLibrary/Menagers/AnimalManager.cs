﻿using System;
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
        IAnimalRepository _animalRepository;
        IZoneRepository _zoneRepository;
        IHabitatRepository _habitatRepository;
        ITimeBlockRepository _timeBlockRepository;
        public AnimalManager(IAnimalRepository animalRepository, IZoneRepository zoneRepository,IHabitatRepository habitatRepository , ITimeBlockRepository timeBlockRepository)
        {
            _animalRepository = animalRepository;
            _zoneRepository = zoneRepository;
            _habitatRepository = habitatRepository;
            _timeBlockRepository = timeBlockRepository;
        }

        public List<Animal> GetAll()
        {
            List<Animal> animals = new List<Animal>();
           
           foreach(AnimalDTO dto in _animalRepository.GetAll())
            {
                animals.Add(new Animal(dto, _timeBlockRepository.GetByTimeblockId(dto.FeedingTimeID), _zoneRepository.GetByZoneId(dto.ZoneID), _habitatRepository.GetByHabitatId(dto.HabitatID)));
            }
            return animals;
        }

        public Animal GetAnimal(int id)
        {
            AnimalDTO dto = _animalRepository.GetByAnimalId(id);
            return new Animal(dto, _timeBlockRepository.GetByTimeblockId(dto.FeedingTimeID), _zoneRepository.GetByZoneId(dto.ZoneID), _habitatRepository.GetByHabitatId(dto.HabitatID));
        }

        public void NewAnimal(AnimalDTO animalDTO)
        {
            _animalRepository.Insert(animalDTO);
        }

        public void RemoveAnimal(int id)
        {
            _animalRepository.Delete(_animalRepository.GetByAnimalId(id));
        }

        public void UpdateAnimal(AnimalDTO animalDTO)
        {
           _animalRepository.Update(animalDTO);
        }
    }
}
