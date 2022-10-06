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
    public class ZoneManager : IZoneMenager
    {
        private readonly IZoneRepository _zoneRepository;

        public ZoneManager(IZoneRepository zoneRepository)
        {
            _zoneRepository = zoneRepository;
        }

        public Zone GetZone(int id)
        {
            return new Zone(_zoneRepository.GetByZoneId(id));
        }

        public void NewZone(ZoneAddDTO zoneDTO)
        {
            _zoneRepository.Insert(zoneDTO);

        }

        public void RemoveZone(int id)
        {
            _zoneRepository.Delete(id);
        }

        public List<Zone> GetAll()
        {
            List<Zone> zones = new List<Zone>();

            foreach(ZoneDTO zone in _zoneRepository.GetAll())
            {
                zones.Add(new Zone(zone));
            }
            return zones;
        }
    }
}
