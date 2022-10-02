using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar_DTO.DTOs
{
    public class ScheduleDTO
    {
        public int ID { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int TimeblockID { get; set; }
        public int EmployeeID { get; set; }
        public int TaskID { get; set; }
    }
}
