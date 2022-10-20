using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar_DTO.DTOs
{
    public class HabitatDTO
    {
        public int HabitatID { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public ZoneDTO ZoneDTO { get; set; }
    }
}
