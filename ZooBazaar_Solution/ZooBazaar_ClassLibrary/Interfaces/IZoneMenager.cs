using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_ClassLibrary.Interfaces
{
    public interface IZoneMenager
    {
        Zone GetZone(int id);
        void NewZone(ZoneDTO zoneDTO);

        void RemoveZone(int id);
    }
}
