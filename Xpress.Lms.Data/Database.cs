using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Xpress.Lms.Data
{
    public class Database : IDatabase
    {
        private readonly string _connectionString;
        public Database(IConfiguration configuration)
        {
             _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException("an exception occure");
        }

        public async Task<List<T>> Get<T>(string query)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var result = await connection.QueryAsync<T>(query);

            return result.ToList();
        }

        public async Task<T?> GetSingle<T>(string query)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var result = await connection.QueryFirstOrDefaultAsync<T>(query);

            return result;
        }

        public async Task ExecuteAsync(string sql, CommandType type, DynamicParameters? parameters = null)
        {
            using var connection = new SqlConnection(_connectionString);

            await connection.OpenAsync();

            await connection.ExecuteAsync(
                sql,
                parameters,
                commandType: type
            );
        }
    }
}
