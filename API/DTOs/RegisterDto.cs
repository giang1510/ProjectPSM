using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class RegisterDto
{
    public required string Username { get; set; }

    [StringLength(128, MinimumLength = 8)]
    public required string Password { get; set; }
}
