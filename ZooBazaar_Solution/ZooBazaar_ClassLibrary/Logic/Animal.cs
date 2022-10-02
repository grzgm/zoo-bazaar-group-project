using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_Interfaces.DTOs;

namespace ZooBazaar_ClassLibrary
{
    internal class Animal
    {
        private int _id;
        private string _name;
        private int _age;
        private DateOnly _dateOfBirth;
        private string _sex;
        private string _species;
        private string _diet;
        private TimeSpan _feedingTime;
        private int _feedingInterval;      
        private Zone _zone;
        private Habitat _habitat;

        public Animal(AnimalDTO animalDTO)
        {

        }




    }
}
