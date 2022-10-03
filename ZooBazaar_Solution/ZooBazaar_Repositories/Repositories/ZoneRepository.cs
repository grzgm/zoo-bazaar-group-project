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
    public class ZoneRepository : IZoneRepository
    {
        private string connectionString = "Server=mssqlstud.fhict.local;Database=dbi463992;User Id=dbi463992;Password=gogotpilon;";

        void IZoneRepository.Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string Query = "DELETE FROM Zone WHERE ZoneID = @ZoneID";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@ZoneID", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        IEnumerable<ZoneDTO> IZoneRepository.GetAll()
        {
            List<ZoneDTO> zoneDTOs = new List<ZoneDTO>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT * FROM Zone";

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
                            ID = zoneid,
                            Name = name,
                            Capacity = capacity
                        });
                    }
                }
            }
            return zoneDTOs;
        }

        ZoneDTO IZoneRepository.GetByZoneId(int ID)
        {
            ZoneDTO zoneDTO = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT * FROM Zone WHERE ZoneID = @ID";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int zoneid = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        int capacity = reader.GetInt32(2);

                        zoneDTO = new ZoneDTO
                        {
                            ID = zoneid,
                            Name = name,
                            Capacity = capacity
                        };
                    }
                }
            }
            return zoneDTO;
        }

        void IZoneRepository.Insert(ZoneAddDTO dto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string Query = "INSERT INTO Zone VALUES (@Name,@Capacity)";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@Name", dto.Name);
                    command.Parameters.AddWithValue("@Capacity", dto.Capacity);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        int IZoneRepository.nextID()
        {
            int newID = 1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string Query = "SELECT MAX(ZoneID) FROM Zone";

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

        void IZoneRepository.Update(ZoneDTO dto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string Query = "UPDATE Zone SET Name=@Name,Capacity=@Capacity WHERE ZoneID=@ZoneID";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@ZoneID", dto.ID);
                    command.Parameters.AddWithValue("@Name", dto.Name);
                    command.Parameters.AddWithValue("@Capacity", dto.Capacity);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
