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
    public class AnimalRepository : BaseRepository, IAnimalRepository
    {
        void IAnimalRepository.Delete(int id)
        {
            string Query = "DELETE FROM Animal WHERE AnimalID = @AnimalID";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@AnimalID", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        IEnumerable<AnimalDTO> IAnimalRepository.GetAll()
        {
            List<AnimalDTO> animalDTOs = new List<AnimalDTO>();
            string Query = "SELECT A.AnimalID, A.Name, A.Age, A.DateOfBirth, A.Sex, A.Species, A.SpeciesType, A.Diet, A.FeedingTimeID, T.StartingTime,T.EndingTime, A.FeedingInterval, A.ZoneID, Z.Name, Z.Capacity, A.HabitatID, H.Name, H.Capacity FROM Animal A JOIN Timeblock T ON A.FeedingTimeID = T.TimeblockID JOIN Zone Z ON A.ZoneID = Z.ZoneID JOIN Habitat H ON A.HabitatID = H.HabitatID";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int animalid = reader.GetInt32(0);
                    string animalName = reader.GetString(1);
                    int age = reader.GetInt32(2);
                    DateTime dateofbirth = reader.GetDateTime(3);
                    bool sex = reader.GetBoolean(4);
                    string species = reader.GetString(5);
                    string speciestype = reader.GetString(6);
                    string diet = reader.GetString(7);
                    int feedinginterval = reader.GetInt32(11);
                    
                    int feedingtimeid = reader.GetInt32(8);
                    TimeSpan staringtime = reader.GetTimeSpan(9);
                    TimeSpan endingtime = reader.GetTimeSpan(10);

                    int zoneid = reader.GetInt32(12);
                    string zonename = reader.GetString(13);
                    int zonecapacity = reader.GetInt32(14);

                    int habitatid = reader.GetInt32(15);
                    string habitatname = reader.GetString(16);
                    int habitatcapacity = reader.GetInt32(17);

                    animalDTOs.Add(new AnimalDTO
                    {
                        AnimalId = animalid,
                        Name = animalName,
                        Age = age,
                        DateOfBirth = dateofbirth,
                        Sex = sex,
                        Species = species,
                        SpeciesType = speciestype,
                        Diet = diet,
                        FeedingInterval = feedinginterval,

                        TimeBlockDTO = new TimeBlockDTO
                        {
                            TimeblockID = feedingtimeid,
                            StartingTime = staringtime,
                            EndingTime = endingtime
                        },

                        HabitatDTO = new HabitatDTO
                        {
                            HabitatID = habitatid,
                            Name = habitatname,
                            Capacity = habitatcapacity,
                            ZoneDTO = new ZoneDTO
                            {
                                ZoneID = zoneid,
                                Name = zonename,
                                Capacity = zonecapacity
                            }
                        }
                    });
                }
            }
            return animalDTOs;
        }

        AnimalDTO IAnimalRepository.GetByAnimalId(int ID)
        {
            AnimalDTO animalDTO = new AnimalDTO();
            string Query = "SELECT A.AnimalID, A.Name, A.Age, A.DateOfBirth, A.Sex, A.Species, A.SpeciesType, A.Diet, A.FeedingTimeID, T.StartingTime,T.EndingTime, A.FeedingInterval, A.ZoneID, Z.Name, Z.Capacity, A.HabitatID, H.Name, H.Capacity FROM Animal A JOIN Timeblock T ON A.FeedingTimeID = T.TimeblockID JOIN Zone Z ON A.ZoneID = Z.ZoneID JOIN Habitat H ON A.HabitatID = H.HabitatID WHERE AnimalID = @ID";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@AnimalID", ID);

                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int animalid = reader.GetInt32(0);
                    string animalName = reader.GetString(1);
                    int age = reader.GetInt32(2);
                    DateTime dateofbirth = reader.GetDateTime(3);
                    bool sex = reader.GetBoolean(4);
                    string species = reader.GetString(5);
                    string speciestype = reader.GetString(6);
                    string diet = reader.GetString(7);
                    int feedinginterval = reader.GetInt32(11);

                    int feedingtimeid = reader.GetInt32(8);
                    TimeSpan staringtime = reader.GetTimeSpan(9);
                    TimeSpan endingtime = reader.GetTimeSpan(10);

                    int zoneid = reader.GetInt32(12);
                    string zonename = reader.GetString(13);
                    int zonecapacity = reader.GetInt32(14);

                    int habitatid = reader.GetInt32(15);
                    string habitatname = reader.GetString(16);
                    int habitatcapacity = reader.GetInt32(17);

                    animalDTO = (new AnimalDTO
                    {
                        AnimalId = animalid,
                        Name = animalName,
                        Age = age,
                        DateOfBirth = dateofbirth,
                        Sex = sex,
                        Species = species,
                        SpeciesType = speciestype,
                        Diet = diet,
                        FeedingInterval = feedinginterval,

                        TimeBlockDTO = new TimeBlockDTO
                        {
                            TimeblockID = feedingtimeid,
                            StartingTime = staringtime,
                            EndingTime = endingtime
                        },

                        HabitatDTO = new HabitatDTO
                        {
                            HabitatID = habitatid,
                            Name = habitatname,
                            Capacity = habitatcapacity,
                            ZoneDTO = new ZoneDTO
                            {
                                ZoneID = zoneid,
                                Name = zonename,
                                Capacity = zonecapacity
                            }
                        }
                    });
                }
            }
            return animalDTO;
        }

        void IAnimalRepository.Insert(AnimalAddDTO dto)
        {
            string Query = "INSERT INTO Animal VALUES (@Name,@Age,@DateOfBirth,@Sex,@Species,@SpeciesType,@Diet,@FeedingTimeID,@FeedingInterval,@ZoneID,@HabitatID)";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@Name", dto.Name);
                command.Parameters.AddWithValue("@Age", dto.Age);
                command.Parameters.AddWithValue("@DateOfBirth", dto.DateOfBirth);
                command.Parameters.AddWithValue("@Sex", dto.Sex);
                command.Parameters.AddWithValue("@Species", dto.Species);
                command.Parameters.AddWithValue("@SpeciesType", dto.SpeciesType);
                command.Parameters.AddWithValue("@Diet", dto.Diet);
                command.Parameters.AddWithValue("@FeedingTimeID", dto.FeedingTimeID);
                command.Parameters.AddWithValue("@FeedingInterval", dto.FeedingInterval);
                command.Parameters.AddWithValue("@ZoneID", dto.ZoneID);
                command.Parameters.AddWithValue("@HabitatID", dto.HabitatID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        int IAnimalRepository.nextID()
        {
            int newID = 1;
            string Query = "SELECT MAX(AnimalID) FROM Animal";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        int id = reader.GetInt32(0);
                        newID = id + 1;
                    }
                }
            }
            return newID;
        }

        void IAnimalRepository.Update(AnimalDTO dto)
        {
            string Query = "UPDATE Animal SET Name=@Name,Age=@Age,DateOfBirth=@DateOfBirth,Sex=@Sex,Species=@Species,SpeciesType=@SpeciesType,Diet=@Diet,FeedingTimeID=@FeedingTimeID,FeedingInterval=@FeedingInterval,ZoneID=@ZoneID,HabitatID=@HabitatID WHERE AnimalID=@AnimalID";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@AnimalID", dto.AnimalId);
                command.Parameters.AddWithValue("@Name", dto.Name);
                command.Parameters.AddWithValue("@Age", dto.Age);
                command.Parameters.AddWithValue("@DateOfBirth", dto.DateOfBirth);
                command.Parameters.AddWithValue("@Sex", dto.Sex);
                command.Parameters.AddWithValue("@Species", dto.Species);
                command.Parameters.AddWithValue("@SpeciesType", dto.SpeciesType);
                command.Parameters.AddWithValue("@Diet", dto.Diet);
                command.Parameters.AddWithValue("@FeedingTimeID", dto.TimeBlockDTO.TimeblockID);
                command.Parameters.AddWithValue("@FeedingInterval", dto.FeedingInterval);
                command.Parameters.AddWithValue("@ZoneID", dto.HabitatDTO.ZoneDTO.ZoneID);
                command.Parameters.AddWithValue("@HabitatID", dto.HabitatDTO.HabitatID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
