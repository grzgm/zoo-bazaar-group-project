using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_DTO.DTOs;
using ZooBazaar_Repositories.Interfaces;

namespace ZooBazaar_ClassLibrary.Menagers
{
    public class HabitatManager : IHabitatMenager
    {
        private readonly IHabitatRepository _habitatRepository;

        public HabitatManager(IHabitatRepository habitatRepository)
        {
            this._habitatRepository = habitatRepository;
        }

        public Habitat GetHabitat(int id)
        {
            HabitatDTO dto = _habitatRepository.GetByHabitatId(id);
            ZoneDTO zoneDTO = new ZoneDTO
            {
                ZoneID = dto.ZoneID,
                Name = dto.ZoneName,
                Capacity = dto.ZoneCapacity
            };
            return new Habitat(dto, zoneDTO);
        }

        public void NewHabitat(HabitatAddDTO habitatDTO)
        {
            _habitatRepository.Insert(habitatDTO);
        }

        public void RemoveHabitat(int id)
        {
            _habitatRepository.Delete(id);
        }
        public List<Habitat> GetAll()
        {
            List<Habitat> habitats = new List<Habitat>();

            foreach(HabitatDTO habitatDTO in _habitatRepository.GetAll())
            {
                ZoneDTO zoneDTO = new ZoneDTO
                {
                    ZoneID = habitatDTO.ZoneID,
                    Name = habitatDTO.ZoneName,
                    Capacity = habitatDTO.ZoneCapacity
                };
                habitats.Add(new Habitat(habitatDTO, zoneDTO));
            }

            return habitats;
        }
    }
}
