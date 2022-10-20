using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar_DTO.DTOs
{
    public class TaskDTO
    {
        public int TaskID { get; set; } 
        public string Name { get; set; }
        public AnimalDTO AnimalDTO { get; set; }
        public HabitatDTO HabitatDTO { get; set; }
    }
}
