using AutoMapper;
using NewsChecker.Data.DTO.JournalistNews;
using NewsChecker.Models;

namespace NewsChecker.Profiles
{
    public class JournalistNewsProfile : Profile
    {
        public JournalistNewsProfile()
        {
            CreateMap<CreateJournalistNewsDTO, JournalistNews>();
            CreateMap<JournalistNews, ReadJournalistNewsDTO>();
        }
    }
}
