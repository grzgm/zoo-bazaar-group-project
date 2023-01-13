using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_ClassLibrary.Interfaces
{
    public interface IScheduleManager
    {
        Schedule GetDayScheduleEmployee(DateOnly date, int employeeId);
        List<Schedule> GetDayScheduleEmployeeAllSchdules(DateOnly date, int employeeId);
        void Insert(ScheduleAddDTO dto);
        void Update(ScheduleDTO dto);
        void Delete(int id);

        int AmountOfEmployessAssignedToTaskTimeBlockDate(int day, int month, int year, int taskID, int timeBlockId);

        bool DoesEmplyeeIsAssignedToTaskTimeBlockDate(int day, int month, int year, int taskID, int timeBlockId, int employeeID);



    }
}
