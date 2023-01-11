using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar_DTO.DTOs
{
    public class StaticScheduleDTO
    {
        public int ScheduleID { get; set; }
        public int DayOfWeek { get; set; }
        public TimeBlockDTO TimeBlockDTO { get; set; }
        public TaskDTO TaskDTO { get; set; }
    }
}
