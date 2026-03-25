using Dapper;
using Xpress.Lms.Models.DTOs;

namespace Xpress.Lms.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserDto>> GetUsers(string query, DynamicParameters parameters);
    }
}
