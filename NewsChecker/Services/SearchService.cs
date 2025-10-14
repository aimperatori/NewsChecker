using AutoMapper;
using NewsChecker.Data.DTO.News;
using NewsChecker.Repositories.Interfaces;

namespace NewsChecker.Services
{
    public class SearchService
    {
        private readonly INewsRepository _newsRepository;
        private readonly IMapper _mapper;

        public SearchService(INewsRepository newsRepository, IMapper mapper)
        {
            _newsRepository = newsRepository;
            _mapper = mapper;
        }

        public List<ReadNewsDTO> BasicSearch(string text)
        {
            var findNews = _newsRepository.BasicSearch(text);

            var newsDto = _mapper.Map<List<ReadNewsDTO>>(findNews);

            return newsDto;
        }
    }
}
