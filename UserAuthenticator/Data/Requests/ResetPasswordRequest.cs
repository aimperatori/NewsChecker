﻿using System.ComponentModel.DataAnnotations;

namespace UserAuthenticator.Data.Requests
{
    public class ResetPasswordRequest
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string Repassword { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Token { get; set; }

    }
}
