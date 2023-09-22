using FluentResults;
using Microsoft.AspNetCore.Identity;
using UserAuthenticator.Models;

namespace UserAuthenticator.Services
{
    public class LogoutService
    {
        private SignInManager<User> _signinManager;

        public LogoutService(SignInManager<User> signinManager)
        {
            _signinManager = signinManager;
        }

        public Result Logout()
        {
            var resultIdentity = _signinManager.SignOutAsync();

            if (resultIdentity.IsCompletedSuccessfully)
            {
                return Result.Ok();
            }

            return Result.Fail("Logout falhou.");
        }


    }
}
