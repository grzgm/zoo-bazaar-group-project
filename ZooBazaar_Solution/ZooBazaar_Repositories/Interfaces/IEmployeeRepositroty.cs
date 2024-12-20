﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_Repositories.Interfaces
{
    public interface IEmployeeRepositroty
    {
        public List<EmployeeDTO> GetAllEmployees();
        EmployeeDTO GetByEmployeeId(int ID);
        void Insert(EmployeeAddDTO dto);
        void Update(EmployeeDTO dto);
        void Delete(int id);
        int nextID();
        EmployeeDTO GetEmployeeByLogin(string email, string password);

        List<EmployeeDTO> GetEmployeesBySchduleID(int schduleID);

        List<EmployeeDTO> GetEmployessAssignedToTaskTimeBlockDate(int day, int month, int year, int taskID, int timeBlockId);
    }
}
