using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_Repositories.Interfaces
{
    public interface IUnavailabilityScheduleRepository
    {
        IEnumerable<UnavailabilityScheduleDTO> GetByEmployeeIDMonthYear(int employeeid, int month, int year);
        IEnumerable<UnavailabilityScheduleDTO> GetByEmployeeIDDayMonthYear(int employeeid, int day, int month, int year);
        void AddUnSchedule(UnavailabilityScheduleDTO unavailabilityScheduleDTO);
        void DeleteUnSchedule(UnavailabilityScheduleDTO unavailabilityScheduleDTO);
    }
}
