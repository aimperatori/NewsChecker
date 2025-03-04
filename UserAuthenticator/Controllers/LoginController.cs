using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UserAuthenticator.Data.Requests;
using UserAuthenticator.Services;

namespace UserAuthenticator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private LoginService _service;

        public LoginController(LoginService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> LoginUserAsync(LoginRequest _loginRequest)
        {
            Result result = await _service.LoginUser(_loginRequest);

            if (result.IsFailed)
            {
                return Unauthorized(result.Errors.FirstOrDefault());
            }

            return Ok(result.Successes.FirstOrDefault());
        }

        [HttpPost("/request-reset-password")]
        public async Task<IActionResult> RequestResetPasswordAsync(RequestResetPasswordRequest request)
        {
            Result result = await _service.RequestResetPasswordAsync(request);
            
            if (result.IsFailed)
            {
                return Unauthorized(result.Errors);
            }

            return Ok(result.Successes.FirstOrDefault());
        }

        [HttpPost("/reset-password")]
        public async Task<IActionResult> ResetPasswordAsync(ResetPasswordRequest request)
        {
            Result result = await _service.ResetPasswordAsync(request);

            if (result.IsFailed)
            {
                return Unauthorized(result.Errors);
            }

            return Ok(result.Successes.FirstOrDefault());
        }
    }
}
