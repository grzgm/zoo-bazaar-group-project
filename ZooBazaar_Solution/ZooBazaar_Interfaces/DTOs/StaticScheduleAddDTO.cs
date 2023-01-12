using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar_DTO.DTOs
{
    public class StaticScheduleAddDTO
    {
        public int TimeBlockID { get; set; }
        public int DayOfTheWeek { get; set; }
        public int EmployeesNeeded { get; set; }
        public int TaskID { get; set; }
    }
}
