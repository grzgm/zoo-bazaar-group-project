using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;
using ZooBazaar_Repositories.Interfaces;

namespace ZooBazaar_Repositories.Repositories
{
    public class AnimalRepository : DapperBaseRepository, IAnimalRepository
    {
        void IAnimalRepository.Delete(int id)
        {
            string Query = "DELETE FROM Animal WHERE AnimalID = @AnimalID";
            Execute(Query, new { AnimalID = id });
        }

        IEnumerable<AnimalDTO> IAnimalRepository.GetAll()
        {
            string selectQuery = "SELECT A.*, T.StartingTime,T.EndingTime, Z.Name AS ZoneName, Z.Capacity AS ZoneCapacity, H.Name AS HabitatName, H.Capacity AS HabitatCapacity FROM Animal A JOIN Timeblock T ON A.FeedingTimeID = T.TimeblockID JOIN Zone Z ON A.ZoneID = Z.ZoneID JOIN Habitat H ON A.HabitatID = H.HabitatID";
            return Query<AnimalDTO>(selectQuery);
        }

        AnimalDTO IAnimalRepository.GetByAnimalId(int ID)
        {
            string selectQuery = "SELECT A.*, T.StartingTime,T.EndingTime, Z.Name AS ZoneName, Z.Capacity AS ZoneCapacity, H.Name AS HabitatName, H.Capacity AS HabitatCapacity FROM Animal A JOIN Timeblock T ON A.FeedingTimeID = T.TimeblockID JOIN Zone Z ON A.ZoneID = Z.ZoneID JOIN Habitat H ON A.HabitatID = H.HabitatID WHERE AnimalID = @ID";
            return QuerySingle<AnimalDTO>(selectQuery, new {ID = ID});
        }

        void IAnimalRepository.Insert(AnimalAddDTO dto)
        {
            string Query = "INSERT INTO Animal VALUES (@Name,@Age,@DateOfBirth,@Sex,@Species,@SpeciesType,@Diet,@FeedingTimeID,@FeedingInterval,@ZoneID,@HabitatID)";
            Execute(Query, new { Name = dto.Name, Age = dto.Age, DateOfBirth = dto.DateOfBirth, Sex = dto.Sex, Species = dto.Species, SpeciesType = dto.SpeciesType, Diet = dto.Diet, FeedingTimeID = dto.FeedingTimeID, FeedingInterval = dto.FeedingInterval, ZoneID = dto.ZoneID, HabitatID = dto.HabitatID });
        }

        int IAnimalRepository.nextID()
        {
            string Query = "SELECT MAX(AnimalID) FROM Animal";
            return QuerySingle<int>(Query);
        }

        void IAnimalRepository.Update(AnimalDTO dto)
        {
            string Query = "UPDATE Animal SET Name=@Name,Age=@Age,DateOfBirth=@DateOfBirth,Sex=@Sex,Species=@Species,SpeciesType=@SpeciesType,Diet=@Diet,FeedingTimeID=@FeedingTimeID,FeedingInterval=@FeedingInterval,ZoneID=@ZoneID,HabitatID=@HabitatID WHERE AnimalID=@AnimalID";
            Execute(Query, new { AnimalID = dto.AnimalId, Name = dto.Name, Age = dto.Age, DateOfBirth = dto.DateOfBirth, Sex = dto.Sex, Species = dto.Species, SpeciesType = dto.SpeciesType, Diet = dto.Diet, FeedingTimeID = dto.FeedingTimeID, FeedingInterval = dto.FeedingInterval ,ZoneID = dto.ZoneID, HabitatID = dto.HabitatID });
        }
    }
}
