using Dapper;
using Xpress.Lms.Models.DTOs;
using Xpress.Lms.Repository.Interfaces;
using Xpress.Lms.Services.Interfaces;

namespace Xpress.Lms.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> GetUsers(int page, int pageSize)
        {
            var query = "SELECT Id, FirstName, LastName FROM Users ORDER BY FirstName,CreatedAt OFFSET @OffSet ROWS FETCH NEXT @PageSize ROWS ONLY;";
            var parameters = new DynamicParameters();
            parameters.Add("@OffSet", (page-1) *pageSize);
            parameters.Add("@PageSize",pageSize);
            return await _userRepository.GetUsers(query, parameters);
        }
    }
}
