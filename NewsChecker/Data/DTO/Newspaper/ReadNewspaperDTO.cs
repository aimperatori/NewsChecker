using System.ComponentModel.DataAnnotations;

namespace NewsChecker.Data.DTO.Newspaper
{
    public class ReadNewspaperDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
