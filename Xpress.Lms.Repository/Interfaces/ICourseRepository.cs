using Microsoft.AspNetCore.Http;
using Xpress.Lms.Models.Entities;

namespace Xpress.Lms.Repository.Interfaces
{
    public interface ICourseRepository
    {
        Task Create(Courses course, IFormFile file);
    }
}
