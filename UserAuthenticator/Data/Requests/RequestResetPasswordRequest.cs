using System.ComponentModel.DataAnnotations;

namespace UserAuthenticator.Data.Requests
{
    public class RequestResetPasswordRequest
    {
        [Required]
        public string Email { get; set; }
    }
}
