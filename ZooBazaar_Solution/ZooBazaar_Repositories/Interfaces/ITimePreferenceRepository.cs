using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_Repositories.Interfaces
{
    public interface ITimePreferenceRepository
    {
        IEnumerable<TimePreferenceDTO> GetAll();
        IEnumerable<TimePreferenceDTO> GetByEmployeeId(int ID);
        void Insert(TimePreferenceDTO dto);
        void Delete(int id); // employee id not timepreference id.
    }
}
