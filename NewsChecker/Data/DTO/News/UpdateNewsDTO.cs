using System.ComponentModel.DataAnnotations;

namespace NewsChecker.Data.DTO.News
{
    public class UpdateNewsDTO
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        [Required]
        public string Resume { get; set; } = string.Empty;
        [Required]
        public int EditionId { get; set; }
    }
}
