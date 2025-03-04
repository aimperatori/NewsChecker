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
                var identityUser = GetUserByUsername(request.Username);

                if (identityUser is null)
                {
                    return Result.Fail("Usuário não encontrado.");
                }

                var userRoles = await _signInManager.UserManager.GetRolesAsync(identityUser);
                var userRole = userRoles.FirstOrDefault();

                if (userRole is null)
                {
                    return Result.Fail("Usuário não possui permissões.");
                }

                Token token = _tokenService.CreateToken(identityUser, userRole);

                return Result.Ok().WithSuccess(token.Value);
            }

            return Result.Fail("Login falhou.");
        }

        public async Task<Result> RequestResetPasswordAsync(RequestResetPasswordRequest request)
        {
            User? identityUser = GetUserByEmail(request.Email);

            if (identityUser is not null)
            {
                string resetToken = await _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser);

                return Result.Ok().WithSuccess(resetToken);
            }

            return Result.Fail("Falha ao solicitar a redefinição da senha. Usuário não encontrado");
        }

        public async Task<Result> ResetPasswordAsync(ResetPasswordRequest request)
        {
            User? identityUser = GetUserByEmail(request.Email);

            if (identityUser is not null)
            {
                IdentityResult identityResult = await _signInManager.UserManager.ResetPasswordAsync(identityUser, request.Token, request.Password);

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