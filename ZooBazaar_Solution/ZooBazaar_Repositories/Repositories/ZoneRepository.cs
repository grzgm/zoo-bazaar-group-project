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
        private IEnumerable<ZoneDTO> GetZones(string Query, List<SqlParameter>? sqlParameters)
        {
            List<ZoneDTO> zones = new List<ZoneDTO>();
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
                        int zoneid = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        int capacity = reader.GetInt32(2);

                        zones.Add(new ZoneDTO
                        {
                            ZoneID = zoneid,
                            Name = name,
                            Capacity = capacity
                        });
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

            return zones;
        }

        void IZoneRepository.Delete(int id)
        {
            string Query = "DELETE FROM Zone WHERE ZoneID = @ZoneID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@ZoneID", id));
            Execute(Query, sqlParameters);
        }

        IEnumerable<ZoneDTO> IZoneRepository.GetAll()
        {
            string Query = "SELECT * FROM Zone";
            return GetZones(Query, null);
        }

        ZoneDTO IZoneRepository.GetByZoneId(int ID)
        {
            string Query = "SELECT * FROM Zone WHERE ZoneID = @ID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@ID", ID));
            return GetZones(Query, sqlParameters).First();
        }

        void IZoneRepository.Insert(ZoneAddDTO dto)
        {
            string Query = "INSERT INTO Zone VALUES (@Name,@Capacity)";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@Name", dto.Name));
            sqlParameters.Add(new SqlParameter("@Capacity", dto.Capacity));
            Execute(Query, sqlParameters);
        }

        int IZoneRepository.nextID()
        {
            string Query = "SELECT MAX(ZoneID) FROM Zone";
            return ExecuteNextID(Query);
        }

        void IZoneRepository.Update(ZoneDTO dto)
        {
            string Query = "UPDATE Zone SET Name=@Name,Capacity=@Capacity WHERE ZoneID=@ZoneID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@ZoneID", dto.ZoneID));
            sqlParameters.Add(new SqlParameter("@Name", dto.Name));
            sqlParameters.Add(new SqlParameter("@Capacity", dto.Capacity));
            Execute(Query, sqlParameters);
        }
    }
}
