using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_DomainModels.Models
{
    public class TimePreference
    {
        private int _id;
        private Employee _employee;
        private List<TimeBlock> _timeblocks;

        public TimePreference(int id, Employee employee)
        {
            _id = id;
            _employee = employee;
            _timeblocks = new List<TimeBlock>();
        }

        public TimePreference(TimePreferenceDTO timePreferenceDTO)
        {

        }
    }
}
