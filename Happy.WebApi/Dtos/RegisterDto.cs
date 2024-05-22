using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Happy.WebApi.Dtos;

public class RegisterDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [PasswordPropertyText]
    public string Password { get; set; }

    [Required]  
    public string DisplayName { get; set; }

    [Required]
    public string Username { get; set; }
}
