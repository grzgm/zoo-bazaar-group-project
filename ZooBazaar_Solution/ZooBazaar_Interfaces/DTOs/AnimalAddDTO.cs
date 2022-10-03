using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar_DTO.DTOs
{
    public class AnimalAddDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Sex { get; set; }
        public string Species { get; set; }
        public string SpeciesType { get; set; }
        public string Diet { get; set; }
        public int FeedingTimeID { get; set; }
        public int FeedingInterval { get; set; }
        public int ZoneID { get; set; }
        public int HabitatID { get; set; }
    }
}
