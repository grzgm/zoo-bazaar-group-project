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
        public int? AnimalID { get; set; }
        public string? AnimalName { get; set; }
        public int? Age { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? Sex { get; set; }
        public string? Species { get; set; }
        public string? SpeciesType { get; set; }
        public string? Diet { get; set; }
        public int? FeedingTimeID { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public int? FeedingInterval { get; set; }
        public int TaskZoneID { get; set; }
        public string ZoneName { get; set; }
        public int ZoneCapacity { get; set; }
        public int TaskHabitatID { get; set; }
        public string HabitatName { get; set; }
        public int HabitatCapacity { get; set; }
    }
}
