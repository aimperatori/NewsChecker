using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Web;
using UserAuthenticator.Data.DTO;
using UserAuthenticator.Data.Enums;
using UserAuthenticator.Data.Requests;
using UserAuthenticator.Models;

namespace UserAuthenticator.Services
{
    public class UserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly EmailService _emailService;
        private readonly RoleService _roleService;

        public UserService(IMapper mapper, UserManager<User> userManager, EmailService emailService, RoleService roleService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
            _roleService = roleService;
        }

        public async Task<Result> CreateUserAsync(CreateUserDTO createDTO)
        {
            User user = _mapper.Map<User>(createDTO);

            var resultIdentity = await _userManager.CreateAsync(user, createDTO.Password);

            await _roleService.CreateRoleIfNotExists(RoleType.User);

            await AddRoleToUser(user, RoleType.User);

            if (resultIdentity.Succeeded)
            {
                //var code = _userManager.GenerateEmailConfirmationTokenAsync(user).Result;
                //var encodedCode = HttpUtility.HtmlEncode(code);

                //Message message = new Message(new List<string>(), "", user.Id, encodedCode);

                /*_emailService.Send(new[] { userIdentity.Email },
                                   "Ativação de conta",
                                   userIdentity.Id,
                                   encodedCode);*/

                return Result.Ok().WithSuccess("Usuário criado com sucesso.");
            }

            List<IdentityError> errorList = resultIdentity.Errors.ToList();
            var errors = string.Join(", ", errorList.Select(e => e.Description));

            return Result.Fail(errors);
        }

        public async Task<Result> ActiveUserAsync(ActiveUserRequest request)
        {
            var identityUser = _userManager.Users.FirstOrDefault(_ => _.Id == request.Id);

            if (identityUser is null)
            {
                return Result.Fail("Usuário não encontrado.");
            }

            string decodedCode = HttpUtility.HtmlDecode(request.Code);

            var identityResult = await _userManager.ConfirmEmailAsync(identityUser, decodedCode);

            if (identityResult.Succeeded)
            {
                return Result.Ok();
            }

            return Result.Fail("Falha ao ativar conta de e-mail.");
        }

        public async Task<Result> AddRoleToUser(User user, RoleType roleType)
        {
            var userRoleResult = await _userManager.AddToRoleAsync(user, roleType.ToString());

            if (userRoleResult.Succeeded)
            {
                return Result.Ok().WithSuccess("Permissão adicionada com sucesso.");
            }

            List<IdentityError> errorList = userRoleResult.Errors.ToList();
            var errors = string.Join(", ", errorList.Select(e => e.Description));

            return Result.Fail(errors);
        }
    }
}
