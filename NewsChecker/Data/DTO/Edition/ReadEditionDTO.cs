using NewsChecker.Data.DTO.Newspapper;
using System.ComponentModel.DataAnnotations;

namespace NewsChecker.Data.DTO.Edition
{
    public class ReadEditionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly PublishDate { get; set; }
        public ReadNewspapperDTO? Newspapper { get; set; }
    }
}
