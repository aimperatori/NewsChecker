using System.ComponentModel.DataAnnotations;

namespace NewsChecker.Data.DTO.Newspapper
{
    public class CreateNewspapperDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}
