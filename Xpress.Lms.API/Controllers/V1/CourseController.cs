using Microsoft.AspNetCore.Mvc;
using Xpress.Lms.Models.DTOs;
using Xpress.Lms.Services.Interfaces;

namespace Xpress.Lms.API.Controllers.V1
{
    [Route("api/course")]
    [ApiController]

    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCourseRequest request)
        {
            await _courseService.CreateCourse(request);
            return Ok("Course created successfully");
        }

    }
}
