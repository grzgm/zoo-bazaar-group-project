using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_DomainModels.Models
{


    public class Habitat
    {
        private int _id;
        private string _name;
        private int _capacity;
        private Zone _zone;

        public Habitat(HabitatDTO habitatDTO)
        {
            this._id = habitatDTO.HabitatID;
            this._name = habitatDTO.Name;
            this._capacity = habitatDTO.Capacity;
            this._zone = new Zone(habitatDTO.ZoneDTO);

        }
        public override string ToString()
        {
            return _name;
        }

        public int ID { get { return _id; } }
        public string Name { get { return _name; } }
        public int Capacity { get { return _capacity; } }   

        public Zone Zone { get { return _zone; } }


    }
}
