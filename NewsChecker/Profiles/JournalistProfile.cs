using AutoMapper;
using NewsChecker.Data.DTO.Journalist;
using NewsChecker.Models;

namespace NewsChecker.Profiles
{
    public class JournalistProfile : Profile
    {
        public JournalistProfile()
        {
            CreateMap<CreateJournalistDTO, Journalist>();
            CreateMap<Journalist, ReadJournalistDTO>();
            CreateMap<UpdateJournalistDTO, Journalist>();
        }
    }
}
