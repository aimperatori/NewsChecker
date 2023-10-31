using NewsChecker.Data.DTO.Newspapper;
using System.ComponentModel.DataAnnotations;

namespace NewsChecker.Data.DTO.Edition
{
    public class ReadEditionDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public DateOnly PublishDate { get; set; }
        public ReadNewspapperDTO? Newspapper { get; set; }
    }
}
