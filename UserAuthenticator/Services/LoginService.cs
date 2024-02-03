using FluentResults;
using Microsoft.AspNetCore.Identity;
using UserAuthenticator.Data.Requests;
using UserAuthenticator.Models;

namespace UserAuthenticator.Services
{
    public class LoginService(SignInManager<User> signInManager, TokenService tokenService)
    {
        private readonly SignInManager<User> _signInManager = signInManager;
        private readonly TokenService _tokenService = tokenService;

        public async Task<Result> LoginUser(LoginRequest request)
        {
            var resultIdentity = await _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);

            if (resultIdentity.Succeeded)
            {
                //var identityUser = 
                User identityUser = GetUserByUsername(request.Username)!;
                Token token = _tokenService.CreateToken(identityUser, _signInManager.UserManager.GetRolesAsync(identityUser).Result.FirstOrDefault());

                return Result.Ok().WithSuccess(token.Value);
            }

            return Result.Fail("Login falhou.");
        }

        public Result RequestResetPassword(RequestResetPasswordRequest request)
        {
            User? identityUser = GetUserByEmail(request.Email);

            if (identityUser is not null)
            {
                string resetToken = _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;

                return Result.Ok().WithSuccess(resetToken);
            }

            return Result.Fail("Falha ao solicitar a redefinição da senha.");
        }

        public Result ResetPassword(ResetPasswordRequest request)
        {
            User? identityUser = GetUserByEmail(request.Email);

            if (identityUser is not null)
            {
                IdentityResult identityResult = _signInManager.UserManager.ResetPasswordAsync(identityUser, request.Token, request.Password).Result;

                if (identityResult.Succeeded)
                {
                    return Result.Ok().WithSuccess("Senha redefinida com sucesso!");
                }
            }

            return Result.Fail("Falha ao redefinir a senha.");
        }

        private User? GetUserByUsername(string username)
        {
            return _signInManager.UserManager.Users.FirstOrDefault(_ => _.NormalizedUserName == username.ToUpper());
        }

        private User? GetUserByEmail(string email)
        {
            return _signInManager.UserManager.Users.FirstOrDefault(_ => _.NormalizedEmail == email.ToUpper());
        }
    }
}