using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_DTO.DTOs;
using ZooBazaar_Repositories.Interfaces;

namespace ZooBazaar_ClassLibrary.Menagers
{
    public class UnavailabilityScheduleMenager : IUnavailabilityScheduleMenager
    {
        private readonly IUnavailabilityScheduleRepository _unavailabilityScheduleRepository;

        public UnavailabilityScheduleMenager(IUnavailabilityScheduleRepository unavailabilityScheduleRepository)
        {
            this._unavailabilityScheduleRepository = unavailabilityScheduleRepository;
        }

        public void AddUnSchedule(UnavailabilityScheduleDTO unavailabilityScheduleDTO)
        {
            _unavailabilityScheduleRepository.AddUnSchedule(unavailabilityScheduleDTO);
        }

        public void DeleteUnSchedule(UnavailabilityScheduleDTO unavailabilityScheduleDTO)
        {
            _unavailabilityScheduleRepository.DeleteUnSchedule(unavailabilityScheduleDTO);
        }

        public IEnumerable<UnavailabilityScheduleDTO> GetByEmployeeIDMonthYear(int employeeid, int month, int year)
        {
            return _unavailabilityScheduleRepository.GetByEmployeeIDMonthYear(employeeid, month, year);
        }
    }
}
