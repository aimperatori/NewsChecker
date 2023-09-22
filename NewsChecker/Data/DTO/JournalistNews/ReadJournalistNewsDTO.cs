using NewsChecker.Data.DTO.Journalist;
using NewsChecker.Data.DTO.News;

namespace NewsChecker.Data.DTO.JournalistNews
{
    public class ReadJournalistNewsDTO
    {
        public int NewsId { get; set; }
        public int JournalistId { get; set; }
        /*
        public List<ReadNewsDTO>? News { get; set; }
        public List<ReadJournalistDTO>? Journalists { get; set; }
        */
    }
}
