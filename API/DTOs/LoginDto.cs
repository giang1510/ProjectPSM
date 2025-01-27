using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

/// <summary>
/// Login data from client to server
/// </summary>
public class LoginDto
{
    [Required(AllowEmptyStrings = false)]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    public required string Username { get; set; }

    [Required(AllowEmptyStrings = false)]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    public required string Password { get; set; }
}
