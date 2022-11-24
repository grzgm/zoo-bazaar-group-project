using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar_DTO.DTOs
{
    public class UnavailabilityScheduleDTO
    {
        public int UnScheduleID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime Date { get; set; }
    }
}
