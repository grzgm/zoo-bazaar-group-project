using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_DomainModels.Models
{
    public class Zone
    {
        private int _id;
        private string _name;
        private int _capacity;

        public Zone(ZoneDTO zoneDTO)
        {
            this._id = zoneDTO.ZoneID;
            this._name = zoneDTO.Name;
            this._capacity = zoneDTO.Capacity;
        }

        public override string ToString()
        {
            return _name;
        }


    }
}
