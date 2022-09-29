using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_Interfaces.DTOs;

namespace ZooBazaar_Interfaces.Interfaces
{
    internal interface IAnimalRepository
    {
        IEnumerable<AnimalDTO> GetAll();
        AnimalDTO GetByAnimalId(int ID);
        void Insert(AnimalDTO dto);
        void Update(AnimalDTO dto);
        void Delete(AnimalDTO dto);
        void Save();
        int nextID();
    }
}
