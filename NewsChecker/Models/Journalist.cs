using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NewsChecker.Models
{
    public class Journalist
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = "";
        [JsonIgnore]
        //public virtual List<Author>? Author { get; set; }
        public virtual ICollection<JournalistNews>? JournalistNews { get; set; }
    }
}
