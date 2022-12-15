using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_ClassLibrary.Interfaces
{
    public interface ITaskManager
    {
        void Insert(TaskAddDTO dto);
        void Update(TaskDTO dto);
        void Delete(int id);
    }
}
