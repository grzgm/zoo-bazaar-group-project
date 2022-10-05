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

        public Habitat(HabitatDTO habitatDTO, ZoneDTO zoneDTO)
        {
            this._id = habitatDTO.ID;
            this._name = habitatDTO.Name;
            this._capacity = habitatDTO.Capacity;
            this._zone = new Zone(zoneDTO);

        }
        public override string ToString()
        {
            return _name;
        }

    }
}
