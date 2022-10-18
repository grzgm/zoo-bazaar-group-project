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
    }
}
