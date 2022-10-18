using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar_DTO.DTOs
{
    public class ScheduleDTO
    {
        public int ScheduleID { get; set; } 
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public TimeBlockDTO TimeBlockDTO { get; set; }
        public EmployeeDTO EmployeeDTO { get; set; }
        public TaskDTO TaskDTO { get; set; }
    }
}
