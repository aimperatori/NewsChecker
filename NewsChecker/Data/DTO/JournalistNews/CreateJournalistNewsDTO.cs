using System.ComponentModel.DataAnnotations;

namespace NewsChecker.Data.DTO.JournalistNews
{
    public class CreateJournalistNewsDTO
    {
        [Required]
        public int NewsId { get; set; }
        [Required]
        public int JournalistId { get; set;}
    }
}
