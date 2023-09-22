using System.ComponentModel.DataAnnotations;

namespace NewsChecker.Data.DTO.Journalist
{
    public class ReadJournalistDTO
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
