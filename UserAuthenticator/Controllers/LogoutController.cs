using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UserAuthenticator.Services;

namespace UserAuthenticator.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class LogoutController : ControllerBase
    {
        private readonly LogoutService _service;

        public LogoutController(LogoutService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Logout()
        {
            Result result = _service.Logout();

            if (result.IsFailed)
            {
                return Unauthorized(result.Errors);
            }

            return Ok(result.Successes);
        }
    }
}
