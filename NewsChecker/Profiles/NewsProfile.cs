using AutoMapper;
using NewsChecker.Data.DTO.News;
using NewsChecker.Models;

namespace NewsChecker.Profiles
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
            CreateMap<CreateNewsDTO, News>();
            CreateMap<News, ReadNewsDTO>();
            CreateMap<UpdateNewsDTO, News>();
        }
    }
}
