using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_ClassLibrary.Interfaces
{
    public interface IUnavailabilityScheduleMenager
    {
        IEnumerable<UnavailabilityScheduleDTO> GetByEmployeeIDMonthYear(int employeeid, int month, int year);
        IEnumerable<UnavailabilityScheduleDTO> GetByEmployeeIDDayMonthYear(int employeeid, int day, int month, int year);
        void AddUnSchedule(UnavailabilityScheduleDTO unavailabilityScheduleAddDTO);
        void DeleteUnSchedule(UnavailabilityScheduleDTO unavailabilityScheduleDTO);
    }
}
