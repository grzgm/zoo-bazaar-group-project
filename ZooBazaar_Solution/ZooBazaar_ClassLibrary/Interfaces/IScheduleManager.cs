using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DomainModels.Models;

namespace ZooBazaar_ClassLibrary.Interfaces
{
    public interface IScheduleManager
    {
        Schedule GetDayScheduleEmployee(DateOnly date, int employeeId);

        List<Schedule> GetDayScheduleEmployeeAllSchdules(DateOnly date, int employeeId);
    }
}
