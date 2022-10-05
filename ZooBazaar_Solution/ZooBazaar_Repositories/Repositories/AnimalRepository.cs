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
    public class AnimalRepository : IAnimalRepository
    {
        private string connectionString = "Server=mssqlstud.fhict.local;Database=dbi463992;User Id=dbi463992;Password=gogotpilon;";

        void IAnimalRepository.Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string Query = "DELETE FROM Animal WHERE AnimalID = @AnimalID";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@AnimalID", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        IEnumerable<AnimalDTO> IAnimalRepository.GetAll()
        {
            List<AnimalDTO> animalDTOs = new List<AnimalDTO>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT * FROM Animal";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int animalid = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        int age = reader.GetInt32(2);
                        DateTime dateofbirth = reader.GetDateTime(3);
                        bool sex = reader.GetBoolean(4);
                        string species = reader.GetString(5);
                        string speciesType = reader.GetString(6);
                        string diet = reader.GetString(7);
                        int feedingtimeID = reader.GetInt32(8);
                        int feedinginterval = reader.GetInt32(9);
                        int zoneid = reader.GetInt32(10);
                        int habitatid = reader.GetInt32(11);

                        animalDTOs.Add(new AnimalDTO
                        {
                            Id = animalid,
                            Name = name,
                            Age = age,
                            DateOfBirth = dateofbirth,
                            Sex = sex,
                            Species = species,
                            SpeciesType = speciesType,
                            Diet = diet,
                            FeedingTimeID = feedingtimeID,
                            FeedingInterval = feedinginterval,
                            ZoneID = zoneid,
                            HabitatID = habitatid,
                        });
                    }
                }
            }
            return animalDTOs;
        }

        AnimalDTO IAnimalRepository.GetByAnimalId(int ID)
        {
            AnimalDTO animalDTO = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT * FROM Animal WHERE AnimalID = @ID";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int animalid = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        int age = reader.GetInt32(2);
                        DateTime dateofbirth = reader.GetDateTime(3);
                        bool sex = reader.GetBoolean(4);
                        string species = reader.GetString(5);
                        string speciesType = reader.GetString(6);
                        string diet = reader.GetString(7);
                        int feedingtimeID = reader.GetInt32(8);
                        int feedinginterval = reader.GetInt32(9);
                        int zoneid = reader.GetInt32(10);
                        int habitatid = reader.GetInt32(11);

                        animalDTO = new AnimalDTO
                        {
                            Id = animalid,
                            Name = name,
                            Age = age,
                            DateOfBirth = dateofbirth,
                            Sex = sex,
                            Species = species,
                            SpeciesType = speciesType,
                            Diet = diet,
                            FeedingTimeID = feedingtimeID,
                            FeedingInterval = feedinginterval,
                            ZoneID = zoneid,
                            HabitatID = habitatid,
                        };
                    }
                }
            }
            return animalDTO;
        }

        void IAnimalRepository.Insert(AnimalAddDTO dto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string Query = "INSERT INTO Animal VALUES (@Name,@Age,@DateOfBirth,@Sex,@Species,@SpeciesType,@Diet,@FeedingTimeID,@FeedingInterval,@ZoneID,@HabitatID)";

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
        }

        int IAnimalRepository.nextID()
        {
            int newID = 1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string Query = "SELECT MAX(AnimalID) FROM Animal";

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
            }
            return newID;
        }

        void IAnimalRepository.Update(AnimalDTO dto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string Query = "UPDATE Animal SET Name=@Name,Age=@Age,DateOfBirth=@DateOfBirth,Sex=@Sex,Species=@Species,SpeciesType=@SpeciesType,Diet=@Diet,FeedingTimeID=@FeedingTimeID,FeedingInterval=@FeedingInterval,ZoneID=@ZoneID,HabitatID=@HabitatID WHERE AnimalID=@AnimalID";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@AnimalID", dto.Id);
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
        }
    }
}
