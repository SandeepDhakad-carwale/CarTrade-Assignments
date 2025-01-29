using System.Data;
using Dapper;
using MySql.Data.MySqlClient;

namespace Cars.DAL.Data
{
    public class DatabaseContext
    {
        private readonly string _connectionString;

        public DatabaseContext(string? connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString), "Connection string cannot be null or empty");
            }

            _connectionString = connectionString;
        }

        public IDbConnection Connection => new MySqlConnection(_connectionString);

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? parameters = null)
        {
            try
            {
                using var connection = (MySqlConnection)Connection;
                await connection.OpenAsync(); 
                return await connection.QueryAsync<T>(sql, parameters);
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException("Error while executing SQL query.", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An unexpected error occurred while querying the database.", ex);
            }
        }

        public async Task<int> ExecuteAsync(string sql, object? parameters = null)
        {
            try
            {
                using var connection = (MySqlConnection)Connection;
                await connection.OpenAsync(); 
                return await connection.ExecuteAsync(sql, parameters);
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException("Error executing SQL command.", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An unexpected error occurred while executing the command.", ex);
            }
        }
    }
}