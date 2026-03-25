using Xpress.Lms.Models.DTOs;

namespace Xpress.Lms.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetUsers(int page, int pageSize);
    }
}
