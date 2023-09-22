using NewsChecker.Data.DTO.Edition;
using NewsChecker.Data.DTO.Journalist;
using NewsChecker.Data.DTO.JournalistNews;
using System.ComponentModel.DataAnnotations;

namespace NewsChecker.Data.DTO.News
{
    public class ReadNewsDTO
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        public string Resume { get; set; } = string.Empty;
        public ReadEditionDTO? Edition { get; set; }
        public ICollection<ReadJournalistDTO>? Journalist { get; set; }
    }
}
