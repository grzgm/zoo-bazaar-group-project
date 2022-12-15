﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_Repositories.Interfaces
{
    public interface IScheduleRepository
    {
        IEnumerable<ScheduleDTO> GetAll();
        ScheduleDTO GetByScheduleId(int ID);
        ScheduleDTO GetByDateAndEmployeeId(DateOnly date, int employeeId);
        IEnumerable<ScheduleDTO> GetByDate(DateOnly date);
        IEnumerable<ScheduleDTO> GetByDateAndEmployeeIdAllSchdules(DateOnly date, int employeeId);
        IEnumerable<ScheduleDTO> GetByEmployeeId(int employeeId);
        IEnumerable<ScheduleDTO> GetByAnimalId(int animalId);
        void Insert(ScheduleAddDTO dto);
        void Update(ScheduleDTO dto);
        void Delete(int id);
        int nextID();
    }
}
