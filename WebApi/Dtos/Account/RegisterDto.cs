using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos.Account
{
    public class RegisterDto
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        [EmailAddress]
        public string? EmailAddress { get; set; }
        [Required]
        [StringLength(50,MinimumLength =8)]
        public string? Password { get; set; }
    }
}
