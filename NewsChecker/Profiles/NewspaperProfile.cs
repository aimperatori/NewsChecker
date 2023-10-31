using AutoMapper;
using NewsChecker.Data.DTO.Newspapper;
using NewsChecker.Models;

namespace NewsChecker.Profiles
{
    public class NewspapperProfile : Profile
    {
        public NewspapperProfile() 
        {
            CreateMap<CreateNewspapperDTO, Newspapper>();
            CreateMap<Newspapper, ReadNewspapperDTO>();
            CreateMap<UpdateNewspapperDTO, Newspapper>();
        }
    }
}
