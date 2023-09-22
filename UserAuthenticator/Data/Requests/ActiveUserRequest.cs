using System.ComponentModel.DataAnnotations;

namespace UserAuthenticator.Data.Requests
{
    public class ActiveUserRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        

    }
}
