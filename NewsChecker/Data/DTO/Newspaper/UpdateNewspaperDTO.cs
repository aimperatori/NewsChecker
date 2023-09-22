using System.ComponentModel.DataAnnotations;

namespace NewsChecker.Data.DTO.Newspaper
{
    public class UpdateNewspaperDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}
