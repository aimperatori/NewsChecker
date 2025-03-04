using System.ComponentModel.DataAnnotations;

namespace UserAuthenticator.Data.DTO
{
    public class CreateUserDTO
    {

        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string Repassword { get; set; }
        [Required]
        public string Email { get; set; }

    }
}
