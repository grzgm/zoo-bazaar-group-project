using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_Repositories.Interfaces;

namespace ZooBazaar_ClassLibrary.Menagers
{
    public class TaskMenager
    {
        private readonly ITaskRepository _taskRepository;


        public TaskMenager(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;

        }
    }
}
