﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_Repositories.Interfaces
{
    public interface IAnimalRepository
    {
        IEnumerable<AnimalDTO> GetAll();
        AnimalDTO GetByAnimalId(int ID);
        void Insert(AnimalAddDTO dto);
        void Update(AnimalDTO dto);
        void Delete(int id);
        int nextID();
        void AddSpecialCare(int id, string specialCare);
    }
}
