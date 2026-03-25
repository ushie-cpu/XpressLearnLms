using Dapper;
using Xpress.Lms.Data;
using Xpress.Lms.Models.DTOs;
using Xpress.Lms.Repository.Interfaces;

namespace Xpress.Lms.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDatabase _database;

        public UserRepository(IDatabase database)
        {
            _database = database;
        }

        public async Task<List<UserDto>> GetUsers(string query, DynamicParameters parameters) 
        { 
            return await _database.Get<UserDto>(query, parameters);
        }
    }
}
