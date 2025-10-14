using NewsChecker.Models;

namespace NewsChecker.Repositories.Interfaces
{
    public interface INewsRepository
    {
        public IEnumerable<News> BasicSearch(string text);
    }
}
