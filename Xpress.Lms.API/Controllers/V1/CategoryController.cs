using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xpress.Lms.Services.Implementation;
using Xpress.Lms.Services.Interfaces;

namespace Xpress.Lms.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            var result = await _categoryService.Get();
            return Ok(result);
        }
    }
}
