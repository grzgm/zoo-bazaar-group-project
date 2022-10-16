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


        public int TimeblockID { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }


        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }


        public int TaskID { get; set; }
        public string Name { get; set; }
        public int? AnimalID { get; set; }
        public string? AnimalName { get; set; }
        public int? Age { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? Sex { get; set; }
        public string? Species { get; set; }
        public string? SpeciesType { get; set; }
        public string? Diet { get; set; }
        public int? FeedingTimeID { get; set; }
        public TimeSpan? AnimalStartTime { get; set; }
        public TimeSpan? AnimalEndTime { get; set; }
        public int? FeedingInterval { get; set; }
        public int TaskZoneID { get; set; }
        public string ZoneName { get; set; }
        public int ZoneCapacity { get; set; }
        public int TaskHabitatID { get; set; }
        public string HabitatName { get; set; }
        public int HabitatCapacity { get; set; }
    }
}
