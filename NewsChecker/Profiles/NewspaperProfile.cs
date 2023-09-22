using AutoMapper;
using NewsChecker.Data.DTO.Newspaper;
using NewsChecker.Models;

namespace NewsChecker.Profiles
{
    public class NewspaperProfile : Profile
    {
        public NewspaperProfile() 
        {
            CreateMap<CreateNewspaperDTO, Newspaper>();
            CreateMap<Newspaper, ReadNewspaperDTO>();
            CreateMap<UpdateNewspaperDTO, Newspaper>();
        }
    }
}
