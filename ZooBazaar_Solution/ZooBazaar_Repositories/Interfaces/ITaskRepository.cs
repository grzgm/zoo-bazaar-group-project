using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_Repositories.Interfaces
{
    public interface ITaskRepository
    {
        IEnumerable<TaskDTO> GetAll();
        TaskDTO GetByTaskId(int ID);
        void Insert(TaskDTO dto);
        void Update(TaskDTO dto);
        void Delete(int id);
        int nextID();
    }
}
