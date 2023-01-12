using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DomainModels.Models;

namespace ZooBazaar_ClassLibrary.Interfaces
{
    public interface IAutomaticScheduleManager
    {
        List<List<Schedule>> MakeSchedule(DateOnly firstDayOfWeek);
    }
}
