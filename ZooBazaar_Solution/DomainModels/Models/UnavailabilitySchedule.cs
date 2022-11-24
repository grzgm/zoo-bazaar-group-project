using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_DomainModels.Models
{
    public class UnavailabilitySchedule
    {
        private int employeeID;
        private DateTime date;

        public UnavailabilitySchedule(UnavailabilityScheduleDTO unavailabilityScheduleDTO)
        {
            employeeID = unavailabilityScheduleDTO.EmployeeID;
            date = unavailabilityScheduleDTO.Date;
        }

        public int EmployeeID { get { return employeeID; } }
        public DateTime Date { get { return date; } }
    }
}
