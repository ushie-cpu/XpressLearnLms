using Dapper;
using System.Data;

namespace Xpress.Lms.Data
{
    public interface IDatabase
    {
        Task ExecuteAsync(string sql, CommandType type, DynamicParameters? parameters = null);
        Task<List<T>> Get<T>(string query);
        Task<T?> GetSingle<T>(string query);
    }
}
