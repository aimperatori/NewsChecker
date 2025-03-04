using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UserAuthenticator.Data.DTO;
using UserAuthenticator.Data.Requests;
using UserAuthenticator.Services;

namespace UserAuthenticator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;
            
        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDTO createDTO)
        {
            Result result = await _service.CreateUserAsync(createDTO);

            if (result.IsFailed)
            {                
                return BadRequest(result.Reasons);
            }

            return Ok(result.Successes.FirstOrDefault());
        }

        [HttpGet("/active")]
        public async Task<IActionResult> ActiveUser([FromQuery] ActiveUserRequest request)
        {
            Result result = await _service.ActiveUserAsync(request);

            if (result.IsFailed)
            {
                return BadRequest(result.Reasons);
            }

            return Ok();
        }

    }
}
