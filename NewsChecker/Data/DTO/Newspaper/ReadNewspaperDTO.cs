using System.ComponentModel.DataAnnotations;

namespace NewsChecker.Data.DTO.Newspapper
{
    public class ReadNewspapperDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
