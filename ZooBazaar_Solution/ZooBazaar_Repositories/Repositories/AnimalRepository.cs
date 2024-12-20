﻿using System;
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
        private IEnumerable<AnimalDTO> GetAnimals(string Query, List<SqlParameter>? sqlParameters)
        {
            List<AnimalDTO> animals = new List<AnimalDTO>();
            try
            {
                SqlConnection connection = GetConnection();
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    connection.Open();
                    if (sqlParameters != null)
                    {
                        command.Parameters.AddRange(sqlParameters.ToArray());
                    }
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
                        string specialcare = reader.GetString(12);

                        int feedingtimeid = reader.GetInt32(8);
                        TimeSpan staringtime = reader.GetTimeSpan(9);
                        TimeSpan endingtime = reader.GetTimeSpan(10);

                        int zoneid = reader.GetInt32(13);
                        string zonename = reader.GetString(14);
                        int zonecapacity = reader.GetInt32(15);

                        int habitatid = reader.GetInt32(16);
                        string habitatname = reader.GetString(17);
                        int habitatcapacity = reader.GetInt32(18);

                        animals.Add(new AnimalDTO
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
                            SpecialCare = specialcare,

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
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return animals;
        }

        void IAnimalRepository.Delete(int id)
        {
            string Query = "DELETE FROM Animal WHERE AnimalID = @AnimalID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            try
            {
                sqlParameters.Add(new SqlParameter("@AnimalID", id));
                Execute(Query, sqlParameters);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        IEnumerable<AnimalDTO> IAnimalRepository.GetAll()
        {
            string Query = "SELECT A.AnimalID, A.Name, A.Age, A.DateOfBirth, A.Sex, A.Species, A.SpeciesType, A.Diet, A.FeedingTimeID, T.StartingTime,T.EndingTime, A.FeedingInterval, A.SpecialCare, A.ZoneID, Z.Name, Z.Capacity, A.HabitatID, H.Name, H.Capacity FROM Animal A JOIN Timeblock T ON A.FeedingTimeID = T.TimeblockID JOIN Zone Z ON A.ZoneID = Z.ZoneID JOIN Habitat H ON A.HabitatID = H.HabitatID";
            return GetAnimals(Query, null);
        }

        AnimalDTO IAnimalRepository.GetByAnimalId(int ID)
        {
            string Query = "SELECT A.AnimalID, A.Name, A.Age, A.DateOfBirth, A.Sex, A.Species, A.SpeciesType, A.Diet, A.FeedingTimeID, T.StartingTime,T.EndingTime, A.FeedingInterval, A.SpecialCare, A.ZoneID, Z.Name, Z.Capacity, A.HabitatID, H.Name, H.Capacity FROM Animal A JOIN Timeblock T ON A.FeedingTimeID = T.TimeblockID JOIN Zone Z ON A.ZoneID = Z.ZoneID JOIN Habitat H ON A.HabitatID = H.HabitatID WHERE AnimalID = @ID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            try
            {
                sqlParameters.Add(new SqlParameter("@ID", ID));
                return GetAnimals(Query, sqlParameters).First();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        void IAnimalRepository.Insert(AnimalAddDTO dto)
        {
            string Query = "INSERT INTO Animal VALUES (@Name,@Age,@DateOfBirth,@Sex,@Species,@SpeciesType,@Diet,@FeedingTimeID,@FeedingInterval,@ZoneID,@HabitatID,@SpecialCare)";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                sqlParameters.Add(new SqlParameter("@Name", dto.Name));
                sqlParameters.Add(new SqlParameter("@Age", dto.Age));
                sqlParameters.Add(new SqlParameter("@DateOfBirth", dto.DateOfBirth.ToString("MM-dd-yyyy")));
                sqlParameters.Add(new SqlParameter("@Sex", dto.Sex));
                sqlParameters.Add(new SqlParameter("@Species", dto.Species));
                sqlParameters.Add(new SqlParameter("@SpeciesType", dto.SpeciesType));
                sqlParameters.Add(new SqlParameter("@Diet", dto.Diet));
                sqlParameters.Add(new SqlParameter("@FeedingTimeID", dto.FeedingTimeID));
                sqlParameters.Add(new SqlParameter("@FeedingInterval", dto.FeedingInterval));
                sqlParameters.Add(new SqlParameter("@ZoneID", dto.ZoneID));
                sqlParameters.Add(new SqlParameter("@HabitatID", dto.HabitatID));
                sqlParameters.Add(new SqlParameter("@SpecialCare", dto.SpecialCare));
                Execute(Query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        int IAnimalRepository.nextID()
        {
            string Query = "SELECT MAX(AnimalID) FROM Animal";
            return ExecuteNextID(Query);
        }

        void IAnimalRepository.Update(AnimalDTO dto)
        {
            string Query = "UPDATE Animal SET Name=@Name,Age=@Age,DateOfBirth=@DateOfBirth,Sex=@Sex,Species=@Species,SpeciesType=@SpeciesType,Diet=@Diet,FeedingTimeID=@FeedingTimeID,FeedingInterval=@FeedingInterval,ZoneID=@ZoneID,HabitatID=@HabitatID,SpecialCare=@SpecialCare WHERE AnimalID=@AnimalID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                sqlParameters.Add(new SqlParameter("@AnimalID", dto.AnimalId));
                sqlParameters.Add(new SqlParameter("@Name", dto.Name));
                sqlParameters.Add(new SqlParameter("@Age", dto.Age));
                sqlParameters.Add(new SqlParameter("@DateOfBirth", dto.DateOfBirth.ToString("MM-dd-yyyy")));
                sqlParameters.Add(new SqlParameter("@Sex", dto.Sex));
                sqlParameters.Add(new SqlParameter("@Species", dto.Species));
                sqlParameters.Add(new SqlParameter("@SpeciesType", dto.SpeciesType));
                sqlParameters.Add(new SqlParameter("@Diet", dto.Diet));
                sqlParameters.Add(new SqlParameter("@FeedingTimeID", dto.TimeBlockDTO.TimeblockID));
                sqlParameters.Add(new SqlParameter("@FeedingInterval", dto.FeedingInterval));
                sqlParameters.Add(new SqlParameter("@ZoneID", dto.HabitatDTO.ZoneDTO.ZoneID));
                sqlParameters.Add(new SqlParameter("@HabitatID", dto.HabitatDTO.HabitatID));
                if(dto.SpecialCare != null)
                {
                    sqlParameters.Add(new SqlParameter("@SpecialCare", dto.SpecialCare));
                }
                else
                {
                    sqlParameters.Add(new SqlParameter("@SpecialCare", ""));
                }
                
                Execute(Query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AddSpecialCare(int id, string specialCare)
        {
            string Query = "UPDATE Animal SET SpecialCare=@SpecialCare WHERE AnimalID=@AnimalID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                sqlParameters.Add(new SqlParameter("@AnimalID", id));
                sqlParameters.Add(new SqlParameter("@SpecialCare", specialCare));
                Execute(Query, sqlParameters);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
