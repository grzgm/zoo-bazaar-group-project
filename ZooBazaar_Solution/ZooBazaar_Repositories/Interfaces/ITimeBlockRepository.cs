using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_Repositories.Interfaces
{
    public interface ITimeBlockRepository
    {
        IEnumerable<TimeBlockDTO> GetAll();
        TimeBlockDTO GetByTimeblockId(int ID);
        void Insert(TimeBlockDTO dto);
        void Update(TimeBlockDTO dto);
        void Delete(TimeBlockDTO dto);
        int nextID();
    }
}
