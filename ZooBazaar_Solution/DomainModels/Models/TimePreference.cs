using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_DomainModels.Models
{
    public class TimePreference
    {
        private Employee _employee;
        private List<TimeBlock> _timeblocks;

        public TimePreference( Employee employee)
        {
            _employee = employee;
            _timeblocks = new List<TimeBlock>();
        }

        public TimePreference(TimePreferenceDTO timePreferenceDTO)
        {
            this._employee = new Employee(timePreferenceDTO.EmployeeDTO);
            
        }
    }
}
