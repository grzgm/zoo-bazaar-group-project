using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar_DTO.DTOs
{
    public class AnimalAddDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "All fields are required")]
        //Why is it colon not Equals sign
        [StringLength(maximumLength: 20, MinimumLength = 1, ErrorMessage = "First name must be between 5 and 20 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "All fields are required")]
        [Range(0, int.MaxValue, ErrorMessage = "The Age should be more or equal to 0")]
        public int Age { get; set; }

        [Required(ErrorMessage = "All fields are required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "All fields are required")]
        public bool Sex { get; set; }

        [Required(ErrorMessage = "All fields are required")]
        public string Species { get; set; }

        [Required(ErrorMessage = "All fields are required")]
        public string SpeciesType { get; set; }

        [Required(ErrorMessage = "All fields are required")]
        public string Diet { get; set; }

        [Required(ErrorMessage = "All fields are required")]
        public int FeedingTimeID { get; set; }

        [Required(ErrorMessage = "All fields are required")]
        public int FeedingInterval { get; set; }

        [Required(ErrorMessage = "All fields are required")]
        public int ZoneID { get; set; }

        [Required(ErrorMessage = "All fields are required")]
        public int HabitatID { get; set; }
    }
}
