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
        private IEnumerable<HabitatDTO> GetHabitats(string Query, List<SqlParameter>? sqlParameters)
        {
            List<HabitatDTO> habitats = new List<HabitatDTO>();
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
                        int habitatid = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        int capacity = reader.GetInt32(2);
                        int zoneid = reader.GetInt32(3);
                        string zonename = reader.GetString(4);
                        int zonecapacity = reader.GetInt32(5);

                        habitats.Add(new HabitatDTO
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
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return habitats;
        }


        void IHabitatRepository.Delete(int id)
        {
            string Query = "DELETE FROM Habitat WHERE HabitatID = @HabitatID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                sqlParameters.Add(new SqlParameter("@HabitatID", id));
                Execute(Query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        IEnumerable<HabitatDTO> IHabitatRepository.GetAll()
        {
            string Query = "SELECT H.*, Z.Name, Z.Capacity FROM Habitat H JOIN Zone Z ON H.ZoneID = Z.ZoneID";
            return GetHabitats(Query, null);
        }
        HabitatDTO IHabitatRepository.GetByHabitatId(int ID)
        {
            string Query = "SELECT H.*, Z.Name, Z.Capacity FROM Habitat H JOIN Zone Z ON H.ZoneID = Z.ZoneID WHERE HabitatID = @ID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                sqlParameters.Add(new SqlParameter("@ID", ID));
                return GetHabitats(Query, sqlParameters).First();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        void IHabitatRepository.Insert(HabitatAddDTO dto)
        {
            string Query = "INSERT INTO Habitat VALUES (@Name,@Capacity,@ZoneID)";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                sqlParameters.Add(new SqlParameter("@Name", dto.Name));
                sqlParameters.Add(new SqlParameter("@Capacity", dto.Capacity));
                sqlParameters.Add(new SqlParameter("@ZoneID", dto.ZoneID));
                Execute(Query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        int IHabitatRepository.nextID()
        {
            string Query = "SELECT MAX(HabitatID) FROM Habitat";
            return ExecuteNextID(Query);
        }

        void IHabitatRepository.Update(HabitatDTO dto)
        {
            string Query = "UPDATE Habitat SET Name=@Name,Capacity=@Capacity,ZoneID=@ZoneID WHERE HabitatID=@HabitatID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                sqlParameters.Add(new SqlParameter("@HabitatID", dto.HabitatID));
                sqlParameters.Add(new SqlParameter("@Name", dto.Name));
                sqlParameters.Add(new SqlParameter("@Capacity", dto.Capacity));
                sqlParameters.Add(new SqlParameter("@ZoneID", dto.ZoneDTO.ZoneID));
                Execute(Query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
