using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NewsChecker.Models
{
    public class JournalistNews
    {
        [Required]
        public int  NewsId { get; set; }
        [JsonIgnore]
        public virtual News? News { get; set; }

        [Required]
        public int JournalistId { get; set; }
        [JsonIgnore]
        public virtual Journalist? Journalist { get; set; }
    }
}
