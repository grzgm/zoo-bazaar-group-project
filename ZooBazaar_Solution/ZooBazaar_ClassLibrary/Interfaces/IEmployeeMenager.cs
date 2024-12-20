﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_DTO.DTOs;
using ZooBazaar_Repositories.Interfaces;

namespace ZooBazaar_ClassLibrary.Interfaces
{
    public interface IEmployeeMenager
    {
        Employee GetEmployee(int id);
        List<Employee> GetAll();
        void NewEmployee(EmployeeAddDTO employeeDTO);
        void RemoveEmployee(int id);
        void UpdateEmployee(EmployeeDTO employeeDTO);
        Employee LoginEmployee(string email, string password);
        EmployeeDTO GetEmployeeDTO(int id);
        List<Employee> GetEmployessByScheduleID(int sheduleID);
        List<Employee> GetEmployessAssignedToTaskTimeBlockDate(int day, int month, int year, int taskID, int timeBlockId);
    }
}
