using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using NewsChecker.Data;
using NewsChecker.Data.DTO.Journalist;
using NewsChecker.Data.DTO.News;
using NewsChecker.Models;

namespace NewsChecker.Services
{
    public class NewsService
    {
        private readonly NewsCheckerContext _context;
        private readonly IMapper _mapper;

        public NewsService(NewsCheckerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public DbSet<News> Get()
        {
            return _context.News;
        }

        public ReadNewsDTO? Get(int id)
        {
            News? news = _context.News.FirstOrDefault(news => news.Id == id);

            if (news != null)
            {
                ReadNewsDTO newsDTO = _mapper.Map<ReadNewsDTO>(news);

                var query =
                   from journalist in _context.Journalist
                   join jn in _context.JournalistNews on journalist.Id equals jn.JournalistId
                   where jn.NewsId == id
                   select new { Journalist = journalist };

                List<ReadJournalistDTO> journalistList = new();

                foreach (var journalist in query)
                {
                    ReadJournalistDTO journalistDTO = _mapper.Map<ReadJournalistDTO>(journalist.Journalist);

                    journalistList.Add(journalistDTO);
                }

                newsDTO.Journalist = journalistList;

                return newsDTO;
            }

            return null;
        }

        public ReadNewsDTO Post(CreateNewsDTO newsDTO)
        {
            News news = _mapper.Map<News>(newsDTO);
            _context.News.Add(news);
            _context.SaveChanges();

            return _mapper.Map<ReadNewsDTO>(news);
        }

        public Result Put(UpdateNewsDTO newsDTO, int id)
        {
            News? news = FindNews(id);

            if (news == null)
            {
                return Result.Fail("Noticia não encontrado.");
            }

            _mapper.Map(newsDTO, news);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result Delete(int id)
        {
            News? news = FindNews(id);

            if (news == null)
            {
                return Result.Fail("Noticia não encontrado.");
            }

            _context.Remove(news);
            _context.SaveChanges();
            return Result.Ok();
        }


        private News? FindNews(int id)
        {
            return _context.News.FirstOrDefault(_ => _.Id == id);
        }

    }
}
