using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_Repositories.Interfaces;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_ClassLibrary.Menagers
{
    public class TaskMenager : ITaskManager
    {
        private readonly ITaskRepository _taskRepository;

        public TaskMenager(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void Delete(int id)
        {
            _taskRepository.Delete(id);
        }

        public void Insert(TaskAddDTO dto)
        {
            _taskRepository.Insert(dto);
        }

        public void Update(TaskDTO dto)
        {
            _taskRepository.Update(dto);
        }
    }
}
