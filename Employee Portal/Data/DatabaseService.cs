using MySql.Data.MySqlClient;
using System.Data;

namespace Employee_Portal.Data
{
    public class DatabaseService : IDatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Executes a query and returns the result as a DataTable
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataTable ExecuteQuery(string query, MySqlParameter[]? parameters = null)
        {
            using var connection = new MySqlConnection(_connectionString);
            using var command = new MySqlCommand(query, connection);

            if (parameters != null)
                command.Parameters.AddRange(parameters);

            var dataTable = new DataTable();
            using var adapter = new MySqlDataAdapter(command);

            connection.Open();
            adapter.Fill(dataTable);
            return dataTable;
        }

        /// <summary>
        /// Executes a query that does not return a result
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        public void ExecuteNonQuery(string query, MySqlParameter[]? parameters = null)
        {
            using var connection = new MySqlConnection(_connectionString);
            using var command = new MySqlCommand(query, connection);

            if (parameters != null)
                command.Parameters.AddRange(parameters);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
