using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_DTO.DTOs;



namespace ZooBazaar_ClassLibrary.Interfaces
{
    public interface IAnimalMenager
    {
        Animal GetAnimal(int id);
        List<Animal> GetAll();
        void NewAnimal(AnimalDTO animalDTO);
        void RemoveAnimal(int id);
        void UpdateAnimal(AnimalDTO animalDTO);
    }
}
