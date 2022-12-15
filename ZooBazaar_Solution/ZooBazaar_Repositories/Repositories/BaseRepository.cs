using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar_Repositories.Repositories
{
    public class BaseRepository
    {
        public SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(AppConnection.connectionString);
            return connection;
        }

        public void Execute(string Query, List<SqlParameter>? sqlParameters)
        {
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
                    command.ExecuteNonQuery();
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
        }

        public int ExecuteNextID(string Query)
        {
            int id = 1;
            try
            {
                SqlConnection connection = GetConnection();
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        id = reader.GetInt32(0) + 1;
                    }
                }
            }
            catch (System.Data.SqlTypes.SqlNullValueException)
            {
                return id;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return id;
        }

        public int ExecuteLastID(string Query)
        {
            int id = 1;
            try
            {
                SqlConnection connection = GetConnection();
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        id = reader.GetInt32(0);
                    }
                }
            }
            catch (System.Data.SqlTypes.SqlNullValueException)
            {
                return id;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return id;
        }
    }
}
