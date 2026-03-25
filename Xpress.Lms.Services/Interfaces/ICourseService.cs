using Xpress.Lms.Models.DTOs;

namespace Xpress.Lms.Services.Interfaces
{
    public interface ICourseService
    {
        Task CreateCourse(CreateCourseRequest request);
    }
}
