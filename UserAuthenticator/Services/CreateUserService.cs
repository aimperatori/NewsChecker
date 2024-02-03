using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Web;
using UserAuthenticator.Data.DTO;
using UserAuthenticator.Data.Requests;
using UserAuthenticator.Models;

namespace UserAuthenticator.Services
{
    public class CreateUserService
    {
        private IMapper _mapper;
        private UserManager<User> _userManager;
        private EmailService _emailService;
        private RoleManager<IdentityRole<int>> _roleManager;

        public CreateUserService(IMapper mapper, UserManager<User> userManager, EmailService emailService, RoleManager<IdentityRole<int>> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
            _roleManager = roleManager;
        }

        public Result CreateUserAsync(CreateUserDTO createDTO)
        {
            User? user = _mapper.Map<User>(createDTO);

            var resultIdentity = _userManager.CreateAsync(user, createDTO.Password).Result;

            //var createRoleResult = _roleManager.CreateAsync(new IdentityRole<int>("admin")).Result;

            //var userRoleResult = _userManager.AddToRoleAsync(user, "regular").Result;

            if (resultIdentity.Succeeded)
            {
                var code = _userManager.GenerateEmailConfirmationTokenAsync(user).Result;
                var encodedCode = HttpUtility.HtmlEncode(code);

                Message message = new Message(new List<string>(), "", user.Id, encodedCode);

                /*_emailService.Send(new[] { userIdentity.Email },
                                   "Ativação de conta",
                                   userIdentity.Id,
                                   encodedCode);*/

                return Result.Ok().WithSuccess(message.Body);
            }

            List<IdentityError> errorList = resultIdentity.Errors.ToList();
            var errors = string.Join(", ", errorList.Select(e => e.Description));

            return Result.Fail(errors);
        }

        public Result ActiveUser(ActiveUserRequest request)
        {
            var identityUser = _userManager.Users.FirstOrDefault(_ => _.Id == request.Id);

            if (identityUser is null)
            {
                return Result.Fail("Usuário não encontrado.");
            }

            string decodedCode = HttpUtility.HtmlDecode(request.Code);

            var identityResult = _userManager.ConfirmEmailAsync(identityUser, decodedCode).Result;

            if (identityResult.Succeeded)
            {
                return Result.Ok();
            }

            return Result.Fail("Falha ao ativar conta de e-mail.");
        }
    }
}
