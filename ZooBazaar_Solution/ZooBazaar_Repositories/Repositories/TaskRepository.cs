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
    public class TaskRepository : BaseRepository, ITaskRepository
    {
        void ITaskRepository.Delete(int id)
        {
            string Query = "DELETE FROM Task WHERE TaskID = @TaskID";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@TaskID", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        IEnumerable<TaskDTO> ITaskRepository.GetAll()
        {
            List<TaskDTO> taskDTOs = new List<TaskDTO>();
            string Query = "SELECT T.TaskID, T.Name, T.AnimalID, A.Name, A.Age, A.DateOfBirth, A.Sex, A.Species, A.SpeciesType, A.Diet, A.FeedingTimeID, TB.StartingTime, TB.EndingTime, A.FeedingInterval, T.HabitatID, H.Name, H.Capacity, H.ZoneID, Z.Name, Z.Capacity FROM Task T LEFT JOIN Animal A ON T.AnimalID = A.AnimalID JOIN Timeblock TB ON A.FeedingTimeID = TB.TimeblockID JOIN Zone Z ON T.ZoneID = Z.ZoneID JOIN Habitat H ON T.HabitatID = H.HabitatID";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int taskid = reader.GetInt32(0);
                    string taskname = reader.GetString(1);

                    int animalid = reader.GetInt32(2);
                    string animalname = reader.GetString(3);
                    int animalage = reader.GetInt32(4);
                    DateTime animaldateofbirth = reader.GetDateTime(5);
                    bool animalsex = reader.GetBoolean(6);
                    string animalspecies = reader.GetString(7);
                    string animalspeciestype = reader.GetString(8);
                    string animaldiet = reader.GetString(9);
                    int animalfeedingtimeid = reader.GetInt32(10);
                    TimeSpan animalstartingtime = reader.GetTimeSpan(11);
                    TimeSpan animalendingtime = reader.GetTimeSpan(12);
                    int animalfeedinginterval = reader.GetInt32(13);
                    
                    int habitatid = reader.GetInt32(14);
                    string habitatname = reader.GetString(15);
                    int habitatcapacity = reader.GetInt32(16);

                    int zoneid = reader.GetInt32(17);
                    string zonename = reader.GetString(18);
                    int zonecapacity = reader.GetInt32(19);


                    taskDTOs.Add(new TaskDTO
                    {
                        TaskID = taskid,
                        Name = taskname,
                        AnimalDTO = new AnimalDTO
                        {
                            AnimalId = animalid,
                            Name = animalname,
                            Age = animalage,
                            DateOfBirth = animaldateofbirth,
                            Sex = animalsex,
                            Species = animalspecies,
                            SpeciesType = animalspeciestype,
                            Diet = animaldiet,
                            FeedingInterval = animalfeedinginterval,
                            TimeBlockDTO = new TimeBlockDTO
                            {
                                TimeblockID = animalfeedingtimeid,
                                StartingTime = animalstartingtime,
                                EndingTime = animalendingtime
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
            return taskDTOs;
        }

        TaskDTO ITaskRepository.GetByTaskId(int ID)
        {
           TaskDTO taskDTO = new TaskDTO();
            string Query = "SELECT T.TaskID, T.Name, T.AnimalID, A.Name, A.Age, A.DateOfBirth, A.Sex, A.Species, A.SpeciesType, A.Diet, A.FeedingTimeID, TB.StartingTime, TB.EndingTime, A.FeedingInterval, T.HabitatID, H.Name, H.Capacity, H.ZoneID, Z.Name, Z.Capacity FROM Task T LEFT JOIN Animal A ON T.AnimalID = A.AnimalID JOIN Timeblock TB ON A.FeedingTimeID = TB.TimeblockID JOIN Zone Z ON T.ZoneID = Z.ZoneID JOIN Habitat H ON T.HabitatID = H.HabitatID WHERE TaskID = @ID";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int taskid = reader.GetInt32(0);
                    string taskname = reader.GetString(1);

                    int animalid = reader.GetInt32(2);
                    string animalname = reader.GetString(3);
                    int animalage = reader.GetInt32(4);
                    DateTime animaldateofbirth = reader.GetDateTime(5);
                    bool animalsex = reader.GetBoolean(6);
                    string animalspecies = reader.GetString(7);
                    string animalspeciestype = reader.GetString(8);
                    string animaldiet = reader.GetString(9);
                    int animalfeedingtimeid = reader.GetInt32(10);
                    TimeSpan animalstartingtime = reader.GetTimeSpan(11);
                    TimeSpan animalendingtime = reader.GetTimeSpan(12);
                    int animalfeedinginterval = reader.GetInt32(13);

                    int habitatid = reader.GetInt32(14);
                    string habitatname = reader.GetString(15);
                    int habitatcapacity = reader.GetInt32(16);

                    int zoneid = reader.GetInt32(17);
                    string zonename = reader.GetString(18);
                    int zonecapacity = reader.GetInt32(19);

                    taskDTO = (new TaskDTO
                    {
                        TaskID = taskid,
                        Name = taskname,
                        AnimalDTO = new AnimalDTO
                        {
                            AnimalId = animalid,
                            Name = animalname,
                            Age = animalage,
                            DateOfBirth = animaldateofbirth,
                            Sex = animalsex,
                            Species = animalspecies,
                            SpeciesType = animalspeciestype,
                            Diet = animaldiet,
                            FeedingInterval = animalfeedinginterval,
                            TimeBlockDTO = new TimeBlockDTO
                            {
                                TimeblockID = animalfeedingtimeid,
                                StartingTime = animalstartingtime,
                                EndingTime = animalendingtime
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
            return taskDTO;
        }

        void ITaskRepository.Insert(TaskDTO dto)
        {
            string Query = "INSERT INTO Task VALUES (@Name,@AnimalID,@HabitatID,@ZoneID)";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@Name", dto.Name);
                command.Parameters.AddWithValue("@AnimalID", dto.AnimalDTO.AnimalId);
                command.Parameters.AddWithValue("@HabitatID", dto.HabitatDTO.HabitatID);
                command.Parameters.AddWithValue("@ZoneID", dto.HabitatDTO.ZoneDTO.ZoneID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        int ITaskRepository.nextID()
        {
            int newID = 1;
            string Query = "SELECT MAX(TaskID) FROM Task";
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

        void ITaskRepository.Update(TaskDTO dto)
        {
            string Query = "UPDATE Task SET Name=@Name,AnimalID=@AnimalID,HabitatID=@HabitatID,ZoneID=@ZoneID WHERE TaskID=@TaskID";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@TaskID", dto.TaskID);
                command.Parameters.AddWithValue("@Name", dto.Name);
                command.Parameters.AddWithValue("@AnimalID", dto.AnimalDTO.AnimalId);
                command.Parameters.AddWithValue("@HabitatID", dto.HabitatDTO.HabitatID);
                command.Parameters.AddWithValue("@ZoneID", dto.HabitatDTO.ZoneDTO.ZoneID);

                connection.Open();
                command.ExecuteNonQuery();
            }

        }
    }
}
