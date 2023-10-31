using System.ComponentModel.DataAnnotations;

namespace NewsChecker.Models
{
    public class Edition
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public DateOnly PublishDate { get; set; }
        [Required]
        public int NewspapperId { get; set; }
        public virtual Newspapper? Newspapper { get; set; }
    }
}
