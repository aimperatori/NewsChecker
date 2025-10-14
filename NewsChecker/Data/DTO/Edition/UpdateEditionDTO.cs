using System.ComponentModel.DataAnnotations;

namespace NewsChecker.Data.DTO.Edition
{
    public class UpdateEditionDTO
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public DateOnly PublishDate { get; set; }
        [Required]
        public int NewspaperId { get; set; }
    }
}
