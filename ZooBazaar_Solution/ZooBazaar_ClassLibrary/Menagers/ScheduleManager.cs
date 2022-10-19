using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_Repositories.Interfaces;

namespace ZooBazaar_ClassLibrary.Menagers
{
    public class ScheduleManager
    {
        private readonly IScheduleRepository _scheduleRepository;


        public ScheduleManager(IScheduleRepository scheduleRepository)
        {
            this._scheduleRepository = scheduleRepository;

        }



    }
}
