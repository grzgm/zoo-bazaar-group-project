using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ZooBazaar_Repositories.Repositories
{
    public class DapperBaseRepository
    {
        public void Execute(string query, object parameters = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(AppConnection.connectionString))
                {
                    conn.Execute(query, parameters);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public T QuerySingle<T>(string query, object parameters = null)
        {
            try
            {
                using (SqlConnection conn
                       = new SqlConnection(AppConnection.connectionString))
                {
                    return conn.QuerySingle<T>(query, parameters);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }

        public List<T> Query<T>(string query, object parameters = null)
        {
            try
            {
                using (SqlConnection conn
                       = new SqlConnection(AppConnection.connectionString))
                {
                    return conn.Query<T>(query, parameters).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<T>();
            }
        }
    }
}
