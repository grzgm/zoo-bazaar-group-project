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
    public class HabitatRepository : BaseRepository, IHabitatRepository
    {

        void IHabitatRepository.Delete(int id)
        {
            string Query = "DELETE FROM Habitat WHERE HabitatID = @HabitatID";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@HabitatID", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        IEnumerable<HabitatDTO> IHabitatRepository.GetAll()
        {
            List<HabitatDTO> habitatDTOs = new List<HabitatDTO>();
            string selectQuery = "SELECT H.*, Z.Name, Z.Capacity FROM Habitat H JOIN Zone Z ON H.ZoneID = Z.ZoneID";
            SqlConnection connection = GetConnection();
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
                    string zonename = reader.GetString(4);
                    int zonecapacity = reader.GetInt32(5);

                    habitatDTOs.Add(new HabitatDTO
                    {
                        HabitatID = habitatid,
                        Name = name,
                        Capacity = capacity,
                        ZoneDTO = new ZoneDTO
                        {
                            ZoneID = zoneid,
                            Name = zonename,
                            Capacity = zonecapacity,
                        }
                    });
                }
            }
            return habitatDTOs;
        }
        HabitatDTO IHabitatRepository.GetByHabitatId(int ID)
        {
            HabitatDTO habitatDTO = new HabitatDTO();
            string selectQuery = "SELECT H.*, Z.Name, Z.Capacity FROM Habitat H JOIN Zone Z ON H.ZoneID = Z.ZoneID WHERE HabitatID = @ID";
            SqlConnection connection = GetConnection();
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
                    string zonename = reader.GetString(4);
                    int zonecapacity = reader.GetInt32(5);

                    habitatDTO = (new HabitatDTO
                    {
                        HabitatID = habitatid,
                        Name = name,
                        Capacity = capacity,
                        ZoneDTO = new ZoneDTO
                        {
                            ZoneID = zoneid,
                            Name = zonename,
                            Capacity = zonecapacity,
                        }
                    });
                }
            }
            return habitatDTO;
        }

        void IHabitatRepository.Insert(HabitatAddDTO dto)
        {
            string Query = "INSERT INTO Habitat VALUES (@Name,@Capacity,@ZoneID)";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@Name", dto.Name);
                command.Parameters.AddWithValue("@Capacity", dto.Capacity);
                command.Parameters.AddWithValue("@ZoneID", dto.ZoneID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        int IHabitatRepository.nextID()
        {
            int newID = 1;
            string Query = "SELECT MAX(HabitatID) FROM Habitat";
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

        void IHabitatRepository.Update(HabitatDTO dto)
        {
            string Query = "UPDATE Habitat SET Name=@Name,Capacity=@Capacity,ZoneID=@ZoneID WHERE HabitatID=@HabitatID";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@HabitatID", dto.HabitatID);
                command.Parameters.AddWithValue("@Name", dto.Name);
                command.Parameters.AddWithValue("@Capacity", dto.Capacity);
                command.Parameters.AddWithValue("@ZoneID", dto.ZoneDTO.ZoneID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
