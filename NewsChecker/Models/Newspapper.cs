using System.ComponentModel.DataAnnotations;

namespace NewsChecker.Models
{
    public class Newspapper
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}
