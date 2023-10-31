using NewsChecker.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace NewsChecker.Data.DTO.News
{
    public class CreateNewsDTO
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        [Required]
        public string Resume { get; set; } = string.Empty;
        [Required]
        public int EditionId { get; set; }
        [Required]
        public NewsType NewsType { get; set; }

        //[Required]
        //public ICollection<int>? JournalistsId { get; set; }
    }
}
