using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace NewsChecker.Authorization
{
    public class MinAgeHandler : AuthorizationHandler<MinAgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinAgeRequirement requirement)
        {
            if (!context.User.HasClaim(_ => _.Type == ClaimTypes.DateOfBirth))
            {
                return Task.CompletedTask;
            }

            DateTime birthDate = Convert.ToDateTime(context.User.FindFirst(_ => _.Type == ClaimTypes.DateOfBirth).Value);

            int age = DateTime.Today.Year - birthDate.Year;

            if (birthDate > DateTime.Today.AddYears(-age))
            {
                age--;
            }

            if (age >= requirement.MinAge)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
