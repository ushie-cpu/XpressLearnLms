using Xpress.Lms.Models.DTOs;
using Xpress.Lms.Models.Entities;
using Xpress.Lms.Repository.Interfaces;
using Xpress.Lms.Services.Interfaces;

namespace Xpress.Lms.Services.Implementation
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public async Task CreateCourse(CreateCourseRequest request)
        {
            await courseRepository.Create(new Courses
            {
                Title = request.Title,
                Description = request.Description,
                CategoryId = request.CategoryId,
                InstructorId = request.InstructorId
            }, request.Thumbnail);
        }
    }
}
