using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class RegisterDto
{
    [StringLength(64, MinimumLength = 4)]
    public required string Username { get; set; }

    [StringLength(128, MinimumLength = 8)]
    public required string Password { get; set; }

    public required DateOnly DateOfBirth { get; set; }

    [EmailAddress]
    public required string EmailAddress { get; set; }
}
