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
    public class ZoneRepository : BaseRepository, IZoneRepository
    {
        void IZoneRepository.Delete(int id)
        {
            string Query = "DELETE FROM Zone WHERE ZoneID = @ZoneID";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@ZoneID", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        IEnumerable<ZoneDTO> IZoneRepository.GetAll()
        {
            List<ZoneDTO> zoneDTOs = new List<ZoneDTO>();
            string selectQuery = "SELECT * FROM Zone";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(selectQuery, connection))
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int zoneid = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    int capacity = reader.GetInt32(2);

                    zoneDTOs.Add(new ZoneDTO
                    {
                        ZoneID = zoneid,
                        Name = name,
                        Capacity = capacity
                    });
                }
            }
            return zoneDTOs;
        }

        ZoneDTO IZoneRepository.GetByZoneId(int ID)
        {
            ZoneDTO zoneDTO = new ZoneDTO();
            string selectQuery = "SELECT * FROM Zone WHERE ZoneID = @ID";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(selectQuery, connection))
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int zoneid = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    int capacity = reader.GetInt32(2);

                    zoneDTO = (new ZoneDTO
                    {
                        ZoneID = zoneid,
                        Name = name,
                        Capacity = capacity
                    });
                }
            }
            return zoneDTO;
        }

        void IZoneRepository.Insert(ZoneAddDTO dto)
        {
            string Query = "INSERT INTO Zone VALUES (@Name,@Capacity)";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@Name", dto.Name);
                command.Parameters.AddWithValue("@Capacity", dto.Capacity);
                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        int IZoneRepository.nextID()
        {
            int newID = 1;
            string Query = "SELECT MAX(ZoneID) FROM Zone";
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

        void IZoneRepository.Update(ZoneDTO dto)
        {
            string Query = "UPDATE Zone SET Name=@Name,Capacity=@Capacity WHERE ZoneID=@ZoneID";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@ZoneID", dto.ZoneID);
                command.Parameters.AddWithValue("@Name", dto.Name);
                command.Parameters.AddWithValue("@Capacity", dto.Capacity);

                connection.Open();
                command.ExecuteNonQuery();
            }

        }
    }
}
