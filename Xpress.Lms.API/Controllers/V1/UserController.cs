using Microsoft.AspNetCore.Mvc;
using Xpress.Lms.Services.Interfaces;

namespace Xpress.Lms.API.Controllers.V1
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers(int page = 1, int pageSize = 10)
        {
            var result = await _userService.GetUsers(page, pageSize);
            return Ok(result);
        }
    }
}
