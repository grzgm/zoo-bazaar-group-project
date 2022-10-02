using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_DomainModels.Models
{
    public class Schedule
    {
        private int _id;
        private DateOnly _date;
        private TimeBlock _timeBlock;
        private Employee _employee;
        private Task _task;

        public Schedule(int id, DateOnly date, TimeBlock timeBlock, Employee employee, Task task)
        {
            _id = id;
            _date = date;
            _timeBlock = timeBlock;
            _employee = employee;
            _task = task;
        }

    }
}
