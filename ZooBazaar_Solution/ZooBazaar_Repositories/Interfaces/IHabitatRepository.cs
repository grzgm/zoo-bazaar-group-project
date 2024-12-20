﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_Repositories.Interfaces
{
    public interface IHabitatRepository
    {
        IEnumerable<HabitatDTO> GetAll();
        HabitatDTO GetByHabitatId(int ID);
        void Insert(HabitatAddDTO dto);
        void Update(HabitatDTO dto);
        void Delete(int id);
        int nextID();
    }
}
