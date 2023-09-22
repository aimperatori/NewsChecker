using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UserAuthenticator.Data.DTO;
using UserAuthenticator.Models;

namespace UserAuthenticator.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDTO, User>();
            CreateMap<User, IdentityUser<int>>();
        }
    }
}
