using FluentResults;
using Microsoft.AspNetCore.Identity;
using UserAuthenticator.Data.Enums;

namespace UserAuthenticator.Services
{
    public class RoleService
    {
        private RoleManager<IdentityRole<int>> _roleManager;

        public RoleService(RoleManager<IdentityRole<int>> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<Result> CreateRole(RoleType roleType)
        {
            var createRoleResult = await _roleManager.CreateAsync(new IdentityRole<int>(roleType.ToString()));

            if (createRoleResult.Succeeded)
            {
                return Result.Ok().WithSuccess("Permissão criada com sucesso.");
            }

            List<IdentityError> errorList = createRoleResult.Errors.ToList();
            var errors = string.Join(", ", errorList.Select(e => e.Description));

            return Result.Fail(errors);
        }

        public async Task CreateRoleIfNotExists(RoleType user)
        {
            var role = _roleManager.Roles.FirstOrDefault(r => r.Name == user.ToString());

            if (role is null)
            {
                await CreateRole(user);
            }
        }
    }
}
