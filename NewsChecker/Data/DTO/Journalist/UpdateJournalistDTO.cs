using System.ComponentModel.DataAnnotations;

namespace NewsChecker.Data.DTO.Journalist
{
    public class UpdateJournalistDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
