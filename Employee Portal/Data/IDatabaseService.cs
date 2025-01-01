using MySql.Data.MySqlClient;
using System.Data;

namespace Employee_Portal.Data
{
    public interface IDatabaseService
    {
        DataTable ExecuteQuery(string query, MySqlParameter[]? parameters = null);
        void ExecuteNonQuery(string query, MySqlParameter[]? parameters = null);
    }
}
