using Microsoft.AspNetCore.Authorization;

namespace NewsChecker.Authorization
{
    public class MinAgeRequirement : IAuthorizationRequirement
    {
        public int MinAge { get; set; }

        public MinAgeRequirement(int minAge)
        {
            MinAge = minAge;
        }
    }
}
