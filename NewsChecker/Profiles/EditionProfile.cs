using AutoMapper;
using NewsChecker.Data.DTO.Edition;
using NewsChecker.Models;

namespace NewsChecker.Profiles
{
    public class EditionProfile : Profile
    {
        public EditionProfile() 
        {
            CreateMap<CreateEditionDTO, Edition>();
            CreateMap<Edition, ReadEditionDTO>();
            CreateMap<UpdateEditionDTO, Edition>();
        }
    }
}
