using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;
using ZooBazaar_DomainModels.Models;

namespace ZooBazaar_ClassLibrary.Interfaces
{
    public interface IStaticScheduleManager
    {
        void AddSchedule(StaticScheduleAddDTO staticScheduleAddDTO);
        void RemoveSchedule(int scheduleid);
        List<StaticSchedule> GetScheduleFromDay(int day);
        void UpdateEmployeesNeeded(int scheduleid, int employeesNeeded);
        void DeleteExistingSchedules(int taskid);
    }
}
