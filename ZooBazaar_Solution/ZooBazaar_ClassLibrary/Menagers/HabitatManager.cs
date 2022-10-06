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
        private readonly IZoneRepository _zoneRepository;

        public HabitatManager(IHabitatRepository habitatRepository, IZoneRepository zoneRepository)
        {
            this._habitatRepository = habitatRepository;
            this._zoneRepository = zoneRepository;
        }

        public Habitat GetHabitat(int id)
        {
            HabitatDTO dto = _habitatRepository.GetByHabitatId(id);
            return new Habitat(dto, _zoneRepository.GetByZoneId(dto.ZoneID));
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
                habitats.Add(new Habitat(habitatDTO, _zoneRepository.GetByZoneId(habitatDTO.ZoneID)));
            }

            return habitats;

        }
    }
}
