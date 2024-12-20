﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_ClassLibrary.Interfaces
{
    public interface IHabitatMenager
    {
        Habitat GetHabitat(int id);
        void NewHabitat(HabitatAddDTO habitatDTO);
        void RemoveHabitat(int id);
        List<Habitat> GetAll();

        HabitatDTO GetHabitatDTO(int id);

        List<HabitatDTO> GetAllDTO();
    }
}
