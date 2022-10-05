using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar_DTO.DTOs
{
    public class EmployeeAddDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "All fields are required")]
        //Why is it colon not Equals sign
        [StringLength(maximumLength: 20, MinimumLength = 5, ErrorMessage = "First name must be between 5 and 20 characters")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "All fields are required")]
        //Why is it colon not Equals sign
        [StringLength(maximumLength: 20, MinimumLength = 5, ErrorMessage = "Last name must be between 5 and 20 characters")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "All fields are required")]
        [EmailAddress(ErrorMessage = "Invalid e-mail")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "All fields are required")]
        [StringLength(maximumLength: 9, MinimumLength = 9, ErrorMessage = "Phone number must be between 9 characters")]
        public string Phone { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "All fields are required")]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "All fields are required")]
        public string Role { get; set; }
    }
}
