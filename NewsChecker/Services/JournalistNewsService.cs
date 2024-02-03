using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using NewsChecker.Data;
using NewsChecker.Data.DTO.Journalist;
using NewsChecker.Data.DTO.JournalistNews;
using NewsChecker.Models;

namespace NewsChecker.Services
{
    public class JournalistNewsService
    {
        private readonly NewsCheckerContext _context;
        private readonly IMapper _mapper;

        public JournalistNewsService(NewsCheckerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IList<JournalistNews> Get()
        {
            return _mapper.Map<List<JournalistNews>>(_context.JournalistNews);
        }

        public ReadJournalistNewsDTO? Get(int journalistId, int newsId)
        {
            JournalistNews? journalistNews = FindJournalistNews(journalistId, newsId);

            if (journalistNews != null)
            {
                return _mapper.Map<ReadJournalistNewsDTO>(journalistNews);
            }

            return null;
        }

        public IQueryable<JournalistNews> GetByNews(int newsId)
        {
            return _context.JournalistNews.Where(journalistNews => journalistNews.NewsId == newsId);
        }

        public ReadJournalistNewsDTO Post(CreateJournalistNewsDTO journalistNewsDTO)
        {
            JournalistNews journalistNews = _mapper.Map<JournalistNews>(journalistNewsDTO);
            _context.JournalistNews.Add(journalistNews);
            _context.SaveChanges();

            return _mapper.Map<ReadJournalistNewsDTO>(journalistNews);
        }

        public Result Delete(int journalistId, int newsId)
        {
            JournalistNews? journalistNews = FindJournalistNews(journalistId, newsId);

            if (journalistNews == null)
            {
                return Result.Fail("Registro não encontrado.");
            }

            _context.Remove(journalistNews);
            _context.SaveChanges();
            return Result.Ok();
        }


        private JournalistNews? FindJournalistNews(int journalistId, int newsId)
        {
            return _context.JournalistNews.FirstOrDefault(_ => _.JournalistId == journalistId && _.NewsId == newsId);
        }

    }
}
