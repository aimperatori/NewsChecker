using FluentResults;
using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Asn1.Ocsp;
using UserAuthenticator.Data.Requests;
using UserAuthenticator.Models;

namespace UserAuthenticator.Services
{
    public class LoginService
    {
        private SignInManager<User> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<User> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LoginUser(LoginRequest request)
        {
            var resultIdentity = _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);

            Console.WriteLine(resultIdentity.Result);

            if (resultIdentity.Result.Succeeded)
            {
                var identityUser = _signInManager.UserManager.Users.FirstOrDefault(_ => _.NormalizedUserName == request.Username.ToUpper());
                Token token = _tokenService.CreateToken(identityUser, _signInManager.UserManager.GetRolesAsync(identityUser).Result.FirstOrDefault());

                return Result.Ok().WithSuccess(token.Value);
            }

            return Result.Fail("Login falhou.");
        }

        public Result RequestResetPassword(RequestResetPasswordRequest request)
        {
            User identityUser = GetUserByEmail(request.Email);

            if (identityUser != null)
            {
                string resetToken = _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;

                return Result.Ok().WithSuccess(resetToken);
            }

            return Result.Fail("Falha ao solicitar a redefinição da senha.");
        }

        public Result ResetPassword(ResetPasswordRequest request)
        {
            User identityUser = GetUserByEmail(request.Email);

            if (identityUser != null)
            {
                IdentityResult identityResult = _signInManager.UserManager.ResetPasswordAsync(identityUser, request.Token, request.Password).Result;

                if (identityResult.Succeeded)
                {
                    return Result.Ok().WithSuccess("Senha redefinida com sucesso!");
                }
            }

            return Result.Fail("Falha ao redefinir a senha.");
        }

        private User GetUserByEmail(string email)
        {
            return _signInManager.UserManager.Users.FirstOrDefault(_ => _.NormalizedEmail == email.ToUpper());
        }
    }
}