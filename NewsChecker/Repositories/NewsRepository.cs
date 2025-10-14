using Microsoft.EntityFrameworkCore;
using NewsChecker.Data;
using NewsChecker.Models;
using NewsChecker.Repositories.Interfaces;

namespace NewsChecker.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly NewsCheckerContext _context;

        public NewsRepository(NewsCheckerContext context)
        {
            _context = context;
        }

        public IEnumerable<News> BasicSearch(string text)
        {
            var searchWords = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            IQueryable query = _context.News.Select(_ => _);

            foreach (var word in searchWords)
            {
                query = _context.News.Where(_ => EF.Functions.Like(_.Title, $"%{word}%") ||
                                                 EF.Functions.Like(_.Subtitle, $"%{word}%") ||
                                                 EF.Functions.Like(_.Resume, $"%{word}%"));
            }

            return (IEnumerable<News>) query;
        }
    }
}
