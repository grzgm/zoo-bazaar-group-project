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
    public class HabitatRepository : IHabitatRepository
    {
        private string connectionString = "Server=mssqlstud.fhict.local;Database=dbi463992;User Id=dbi463992;Password=gogotpilon;";

        void IHabitatRepository.Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string Query = "DELETE FROM Habitat WHERE HabitatID = @HabitatID";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@HabitatID", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        IEnumerable<HabitatDTO> IHabitatRepository.GetAll()
        {
            List<HabitatDTO> habitatDTOs = new List<HabitatDTO>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT * FROM Habitat";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int habitatid = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        int capacity = reader.GetInt32(2);
                        int zoneid = reader.GetInt32(3);

                        habitatDTOs.Add(new HabitatDTO
                        {
                            ID = habitatid,
                            Name = name,
                            Capacity = capacity,
                            ZoneID = zoneid
                        });
                    }
                }
            }
            return habitatDTOs;
        }

        HabitatDTO IHabitatRepository.GetByHabitatId(int ID)
        {
            HabitatDTO habitatDTO = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT * FROM Habitat WHERE HabitatID = @ID";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int habitatid = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        int capacity = reader.GetInt32(2);
                        int zoneid = reader.GetInt32(3);

                        habitatDTO = new HabitatDTO
                        {
                            ID = habitatid,
                            Name=name,
                            Capacity = capacity,
                            ZoneID=zoneid
                        };
                    }
                }
            }
            return habitatDTO;
        }

        void IHabitatRepository.Insert(HabitatDTO dto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string Query = "INSERT INTO Habitat VALUES (@Name,@Capacity,@ZoneID)";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@Name", dto.Name);
                    command.Parameters.AddWithValue("@Capacity", dto.Capacity);
                    command.Parameters.AddWithValue("@ZoneID", dto.ZoneID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        int IHabitatRepository.nextID()
        {
            int newID = 1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string Query = "SELECT MAX(HabitatID) FROM Habitat";

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

        void IHabitatRepository.Update(HabitatDTO dto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string Query = "UPDATE Habitat SET Name=@Name,Capacity=@Capacity,ZoneID=@ZoneID WHERE HabitatID=@HabitatID";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@HabitatID", dto.ID);
                    command.Parameters.AddWithValue("@Name", dto.Name);
                    command.Parameters.AddWithValue("@Capacity", dto.Capacity);
                    command.Parameters.AddWithValue("@ZoneID", dto.ZoneID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
