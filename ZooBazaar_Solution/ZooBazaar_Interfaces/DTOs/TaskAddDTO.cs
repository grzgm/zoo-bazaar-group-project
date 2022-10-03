using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar_DTO.DTOs
{
    public class TaskAddDTO
    {
        public string Name { get; set; }
        public int? AnimalID { get; set; }
        public int HabitatID { get; set; }
        public int ZoneID { get; set; }
    }
}
