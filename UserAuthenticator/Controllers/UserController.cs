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
        readonly CreateUserService _service;
            
        public UserController(CreateUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserDTO createDTO)
        {
            Result result = _service.CreateUserAsync(createDTO);

            if (result.IsFailed)
            {
                
                return BadRequest(result.Reasons);
            }

            return Ok(result.Successes.FirstOrDefault());
        }

        [HttpGet("/active")]
        public IActionResult ActiveUser([FromQuery] ActiveUserRequest request)
        {
            Result result = _service.ActiveUser(request);

            if (result.IsFailed)
            {
                return StatusCode(500);
            }

            return Ok();
        }

    }
}
