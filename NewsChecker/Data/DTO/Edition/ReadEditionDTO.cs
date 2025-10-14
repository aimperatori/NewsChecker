using NewsChecker.Data.DTO.Newspaper;

namespace NewsChecker.Data.DTO.Edition
{
    public class ReadEditionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly PublishDate { get; set; }
        public required ReadNewspaperDTO Newspaper { get; set; }
    }
}
