using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;

namespace UnitTests
{
    public class FakeData
    {
       

        private string GetPathJsonsDTO(string jsonName)
        {
            return Path.Combine(Environment.CurrentDirectory, @"FakeData\\", jsonName);
        }

        public List<AnimalDTO> GetAllFakeAnimals()
        {
            List<AnimalDTO> list = new List<AnimalDTO>();
            for (int i = 1; i < 11; i++)
            {
                list.Add(JsonConvert.DeserializeObject<AnimalDTO>(File.ReadAllText(GetPathJsonsDTO("AnimalDTO-ID-"+i+".json"))));
            }

            return list;
        }

        public List<EmployeeDTO> GetAllFakeEmployees()
        {
            List<EmployeeDTO> list = new List<EmployeeDTO>();
            for (int i = 2; i < 13; i++)
            {
                list.Add(JsonConvert.DeserializeObject<EmployeeDTO>(File.ReadAllText(GetPathJsonsDTO("EmployeeDTO-ID-" + i + ".json"))));
            }

            return list;
        }

        public EmployeeDTO GetFakeEmployee()
        {
            return JsonConvert.DeserializeObject<EmployeeDTO>(File.ReadAllText(GetPathJsonsDTO("EmployeeDTO-ID-2.json")));
        }
        public List<HabitatDTO> GetAllFakeHabitats()
        {
            List<HabitatDTO> list = new List<HabitatDTO>();
            for (int i = 1; i < 11; i++)
            {
                list.Add(JsonConvert.DeserializeObject<HabitatDTO>(File.ReadAllText(GetPathJsonsDTO("Habitat-ID-" + i + ".json"))));
            }

            return list;
        }

        public List<ZoneDTO> GetFakeZones()
        {
            List<ZoneDTO> list = new List<ZoneDTO>();
            for (int i = 1; i < 11; i++)
            {
                list.Add(JsonConvert.DeserializeObject<ZoneDTO>(File.ReadAllText(GetPathJsonsDTO("Zone-ID-" + i + ".json"))));
            }

            return list;
        }

    }
}
