using Xpress.Lms.Models.DTOs;

namespace Xpress.Lms.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> Get();
    }
}
