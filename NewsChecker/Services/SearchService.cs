using Microsoft.EntityFrameworkCore;
using NewsChecker.Data;

namespace NewsChecker.Services
{
    public class SearchService
    {
        private readonly NewsCheckerContext _context;

        public SearchService(NewsCheckerContext context)
        {
            _context = context;
        }

        internal IQueryable BasicSearch(string text)
        {
            var searchWords = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            IQueryable query = _context.News.Select(_ => _);

            foreach (var word in searchWords)
            {
                query = _context.News.Where(_ => EF.Functions.Like(_.Title, $"%{word}%") ||
                                                 EF.Functions.Like(_.Subtitle, $"%{word}%") ||
                                                 EF.Functions.Like(_.Resume, $"%{word}%"));
            }

            return query;
        }
    }
}