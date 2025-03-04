using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserAuthenticator.Models;

namespace UserAuthenticator.Services
{
    public class TokenService
    {
        public Token CreateToken(User user, string role)
        {
            Claim[] userRoles =
            [
                new Claim("UserName", user.UserName),
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimTypes.Role, role),
                //new Claim(ClaimTypes.DateOfBirth, user.Birthday.ToString())
            ];

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("8sfas9fg25as9f5a9sf5asfgaqsfuasfasfa"));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: userRoles, 
                signingCredentials: credentials, 
                expires: DateTime.UtcNow.AddHours(1)
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new Token(tokenString);
        }
    }
}
