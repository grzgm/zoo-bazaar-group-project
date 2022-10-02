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
    public class TaskRepository : ITaskRepository
    {
        private string connectionString = "Server=mssqlstud.fhict.local;Database=dbi463992;User Id=dbi463992;Password=gogotpilon;";

        void ITaskRepository.Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string Query = "DELETE FROM Task WHERE TaskID = @TaskID";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@TaskID", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        IEnumerable<TaskDTO> ITaskRepository.GetAll()
        {
            List<TaskDTO> taskDTOs = new List<TaskDTO>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT * FROM Task";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int taskid = reader.GetInt32(0);
                        string name = null;
                        if (!reader.IsDBNull(1))
                        {
                            name = reader.GetString(1);
                        }
                        int animalid = reader.GetInt32(2);
                        int habitatid = reader.GetInt32(3);
                        int zoneid = reader.GetInt32(4);

                        taskDTOs.Add(new TaskDTO
                        {
                            ID = taskid,
                            Name = name,
                            AnimalID = animalid,
                            HabitatID = habitatid,
                            ZoneID = zoneid
                        });
                    }
                }
            }
            return taskDTOs;
        }

        TaskDTO ITaskRepository.GetByTaskId(int ID)
        {
            TaskDTO taskDTO = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT * FROM Task WHERE TaskID = @ID";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int taskid = reader.GetInt32(0);
                        string name = null;
                        if (!reader.IsDBNull(1))
                        {
                            name = reader.GetString(1);
                        }
                        int animalid = reader.GetInt32(2);
                        int habitatid = reader.GetInt32(3);
                        int zoneid = reader.GetInt32(4);

                        taskDTO = new TaskDTO
                        {
                            ID = taskid,
                            Name = name,
                            AnimalID = animalid,
                            HabitatID = habitatid,
                            ZoneID = zoneid
                        };
                    }
                }
            }
            return taskDTO;
        }

        void ITaskRepository.Insert(TaskDTO dto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string Query = "INSERT INTO Task VALUES (@Name,@AnimalID,@HabitatID,@ZoneID)";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@Name", dto.Name);
                    command.Parameters.AddWithValue("@AnimalID", dto.AnimalID);
                    command.Parameters.AddWithValue("@HabitatID", dto.HabitatID);
                    command.Parameters.AddWithValue("@ZoneID", dto.ZoneID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        int ITaskRepository.nextID()
        {
            int newID = 1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string Query = "SELECT MAX(TaskID) FROM Task";

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

        void ITaskRepository.Update(TaskDTO dto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string Query = "UPDATE Task SET Name=@Name,AnimalID=@AnimalID,HabitatID=@HabitatID,ZoneID=@ZoneID WHERE TaskID=@TaskID";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@TaskID", dto.ID);
                    command.Parameters.AddWithValue("@Name", dto.Name);
                    command.Parameters.AddWithValue("@AnimalID", dto.AnimalID);
                    command.Parameters.AddWithValue("@HabitatID", dto.HabitatID);
                    command.Parameters.AddWithValue("@ZoneID", dto.ZoneID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
