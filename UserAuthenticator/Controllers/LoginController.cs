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
        public IActionResult LoginUser(LoginRequest _loginRequest)
        {
            Result result = _service.LoginUser(_loginRequest);

            if (result.IsFailed)
            {
                return Unauthorized(result.Errors.FirstOrDefault());
            }

            return Ok(result.Successes.FirstOrDefault());
        }

        [HttpPost("/request-reset-password")]
        public IActionResult RequestResetPassword(RequestResetPasswordRequest request)
        {
            Result result = _service.RequestResetPassword(request);
            
            if (result.IsFailed)
            {
                return Unauthorized(result.Errors);
            }

            return Ok(result.Successes.FirstOrDefault());
        }

        [HttpPost("/reset-password")]
        public IActionResult ResetPassword(ResetPasswordRequest request)
        {
            Result result = _service.ResetPassword(request);

            if (result.IsFailed)
            {
                return Unauthorized(result.Errors);
            }

            return Ok(result.Successes.FirstOrDefault());
        }
    }
}
