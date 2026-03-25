using Microsoft.AspNetCore.Http;

namespace Xpress.Lms.Models.DTOs
{
    public class CreateCourseRequest
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public Guid CategoryId { get; set; }
        public Guid InstructorId { get; set; }
        public IFormFile Thumbnail { get; set; } = default!;
    }
}
 