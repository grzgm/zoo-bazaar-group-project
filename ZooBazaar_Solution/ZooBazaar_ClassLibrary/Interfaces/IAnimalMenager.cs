using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DomainModels.Models;


namespace ZooBazaar_ClassLibrary.Interfaces
{
    public interface IAnimalMenager
    {
        Animal GetAnimal(int id);

        List<Animal> GetAll();

        Animal NewAnimal(int id, string name, int age, DateOnly dateOfBirth, bool sex, string species, string speciesType, string diet, int feedingtimeId, int feedingInterval, int zoneId, int habitatId);

        Animal RemoveAnimal(int id);

        Animal UpdateAnimal(); //WHAT THE FUCK TO I PASS? A FUCKING AnimalDTO OR RA DATA?
    }
}
