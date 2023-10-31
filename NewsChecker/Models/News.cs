using NewsChecker.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NewsChecker.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = "";
        [StringLength(150)]
        public string Subtitle { get; set; } = "";
        [Required]
        [StringLength(1000)]
        public string Resume { get; set; } = "";
        [Required]
        public int EditionId { get; set; }
        public virtual Edition? Edition { get; set; }
        [Required]
        public NewsType NewsType { get; set; }
        //[JsonIgnore]
        //public virtual List<Author>? Author { get; set; }
        public virtual ICollection<JournalistNews>? JournalistNews { get; set; }
    }
}
