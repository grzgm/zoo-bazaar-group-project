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
        private IEnumerable<TaskDTO> GetTasks(string Query, List<SqlParameter>? sqlParameters)
        {
            List<TaskDTO> tasks = new List<TaskDTO>();
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
                        int taskid = reader.GetInt32(0);
                        string taskname = reader.GetString(1);

                        int habitatid = reader.GetInt32(15);
                        string habitatname = reader.GetString(16);
                        int habitatcapacity = reader.GetInt32(17);

                        int zoneid = reader.GetInt32(18);
                        string zonename = reader.GetString(19);
                        int zonecapacity = reader.GetInt32(20);

                        if (!reader.IsDBNull(2))
                        {
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
                            string animalspecialcare = reader.GetString(14);

                            tasks.Add(new TaskDTO
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
                                    SpecialCare = animalspecialcare,
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
                        else if(reader.IsDBNull(2))
                        {
                            tasks.Add(new TaskDTO
                            {
                                TaskID = taskid,
                                Name = taskname,
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

            return tasks;
        }

        void ITaskRepository.Delete(int id)
        {
            string Query = "DELETE FROM Task WHERE TaskID = @TaskID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                sqlParameters.Add(new SqlParameter("@TaskID", id));
                Execute(Query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        IEnumerable<TaskDTO> ITaskRepository.GetAll()
        {
            string Query = "SELECT T.TaskID, T.Name, T.AnimalID, A.Name, A.Age, A.DateOfBirth, A.Sex, A.Species, A.SpeciesType, A.Diet, A.FeedingTimeID, A.SpecialCare, TB.StartingTime, TB.EndingTime, A.FeedingInterval, T.HabitatID, H.Name, H.Capacity, H.ZoneID, Z.Name, Z.Capacity FROM Task T LEFT JOIN Animal A ON T.AnimalID = A.AnimalID LEFT JOIN Timeblock TB ON A.FeedingTimeID = TB.TimeblockID JOIN Zone Z ON T.ZoneID = Z.ZoneID JOIN Habitat H ON T.HabitatID = H.HabitatID";
            return GetTasks(Query, null);
        }

        TaskDTO ITaskRepository.GetByTaskId(int ID)
        {
            string Query = "SELECT T.TaskID, T.Name, T.AnimalID, A.Name, A.Age, A.DateOfBirth, A.Sex, A.Species, A.SpeciesType, A.Diet, A.FeedingTimeID, A.SpecialCare, TB.StartingTime, TB.EndingTime, A.FeedingInterval, T.HabitatID, H.Name, H.Capacity, H.ZoneID, Z.Name, Z.Capacity FROM Task T LEFT JOIN Animal A ON T.AnimalID = A.AnimalID LEFT JOIN Timeblock TB ON A.FeedingTimeID = TB.TimeblockID JOIN Zone Z ON T.ZoneID = Z.ZoneID JOIN Habitat H ON T.HabitatID = H.HabitatID WHERE TaskID = @ID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                sqlParameters.Add(new SqlParameter("@ID", ID));
                return GetTasks(Query, sqlParameters).First();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        void ITaskRepository.Insert(TaskAddDTO dto)
        {
            if(dto.AnimalID != null)
            {
                string Query = "INSERT INTO Task VALUES (@Name,@AnimalID,@HabitatID,@ZoneID)";
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                try
                {
                    sqlParameters.Add(new SqlParameter("@Name", dto.Name));
                    sqlParameters.Add(new SqlParameter("@AnimalID", dto.AnimalID));
                    sqlParameters.Add(new SqlParameter("@HabitatID", dto.HabitatID));
                    sqlParameters.Add(new SqlParameter("@ZoneID", dto.ZoneID));
                    Execute(Query, sqlParameters);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
            else
            {
                string Query = "INSERT INTO Task VALUES (@Name,Null,@HabitatID,@ZoneID)";
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                try
                {
                    sqlParameters.Add(new SqlParameter("@Name", dto.Name));
                    sqlParameters.Add(new SqlParameter("@HabitatID", dto.HabitatID));
                    sqlParameters.Add(new SqlParameter("@ZoneID", dto.ZoneID));
                    Execute(Query, sqlParameters);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }

        int ITaskRepository.nextID()
        {
            string Query = "SELECT MAX(TaskID) FROM Task";
            return ExecuteLastID(Query);
        }

        void ITaskRepository.Update(TaskDTO dto)
        {
            string Query = "UPDATE Task SET Name=@Name,AnimalID=@AnimalID,HabitatID=@HabitatID,ZoneID=@ZoneID WHERE TaskID=@TaskID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                sqlParameters.Add(new SqlParameter("@TaskID", dto.TaskID));
                sqlParameters.Add(new SqlParameter("@Name", dto.Name));
                sqlParameters.Add(new SqlParameter("@AnimalID", dto.AnimalDTO.AnimalId));
                sqlParameters.Add(new SqlParameter("@HabitatID", dto.HabitatDTO.HabitatID));
                sqlParameters.Add(new SqlParameter("@ZoneID", dto.HabitatDTO.ZoneDTO.ZoneID));
                Execute(Query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
